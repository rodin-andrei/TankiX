using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GarageController : MonoBehaviour {

	private BundleLoader bundleLoader;
	private SceneLoader sceneLoader;

	void Start () {
		this.bundleLoader = new BundleLoader();
		this.bundleLoader.Init();
		this.sceneLoader = new SceneLoader(this.bundleLoader);
		this.sceneLoader.LoadScene("Garage");
        this.StartCoroutine(this.AwaitLoadMap());

	}
	GameObject turret;
	IEnumerator AwaitLoadMap() {
		yield return null;
        GameObject tankController = GameObject.Find("Tank");

        GameObject hullPrefab = this.bundleLoader.getLoadedBundleByName("hornetxt_t_83b36847").LoadAsset<GameObject>("HornetXT_Thor");
        GameObject hull = Instantiate(hullPrefab, tankController.GetComponent<Transform>());
		hull.GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);

        Transform transform1 = hull.GetComponentsInChildren<Transform>()
			.Where(transform => transform.gameObject.name.Contains("mount_point"))
			.First();


        GameObject turretPrefab = this.bundleLoader.getLoadedBundleByName("m1_b0cfd896").LoadAsset<GameObject>("FlamethrowerM1");
        this.turret =Instantiate(turretPrefab, transform1);
		this.turret.GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);

        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
		camera.GetComponent<Camera>().cullingMask = 1073743877;
		MouseOrbitCamera script =camera.AddComponent<MouseOrbitCamera>();
		script.target = tankController.GetComponent<Transform>();
	}
	
}
