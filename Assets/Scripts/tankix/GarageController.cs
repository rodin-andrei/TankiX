using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GarageController : MonoBehaviour {

	private BundleLoader bundleLoader;
	private SceneLoader sceneLoader;

	public UnityEngine.UI.Dropdown hullDropDown;
	public UnityEngine.UI.Dropdown TurretDropDown;

	private Dictionary<string, string> hullMap = new Dictionary<string, string>();
	private List<string> hullKeys = new List<string>();
	
	private Dictionary<string, string> turretMap = new Dictionary<string, string>();
	private List<string> turretKeys = new List<string>();

	private Transform tankMainContainer;

    void Start () {

		this.bundleLoader = new BundleLoader();
		this.bundleLoader.Init();
		this.sceneLoader = new SceneLoader(this.bundleLoader);
        this.sceneLoader.LoadScene("Garage");

		this.InitHullDb();
		this.StartCoroutine(this.AwaitLoadMap());
	}
	
	IEnumerator AwaitLoadMap() {
        yield return null;

        GameObject tankController = GameObject.Find("Tank");
		this.tankMainContainer = tankController.GetComponent<Transform>();

		fixCamera(tankController);
     

		
	 
        
    }
	public void onDropDownSelect() {

		setTank(this.hullMap[this.hullKeys[this.hullDropDown.value]],
			this.hullKeys[this.hullDropDown.value],
		/*	"railgunxt_78e41ffb",
			"RailgunXT");*/
		this.turretMap[this.turretKeys[this.TurretDropDown.value]],
		this.turretKeys[this.TurretDropDown.value]);
		/*Debug.Log(this.turretMap[this.turretKeys[this.TurretDropDown.value]]+"-------"+
			this.turretKeys[this.TurretDropDown.value]);*/
		//this.turretMap[this.turretKeys[this.TurretDropDown.value]],
		//this.turretKeys[this.TurretDropDown.value]);
	}
	private void setTank(string hullAssetBundleName, string hullAssetName, string turretAssetBundleName, string turretAssetName) {
		foreach (Transform child in this.tankMainContainer) Destroy(child.gameObject);

		GameObject hull = this.CretePerfab(hullAssetBundleName, hullAssetName, this.tankMainContainer);

		Transform mountPoint = hull.GetComponentsInChildren<Transform>()
			.Where(transform => transform.gameObject.name.Contains("mount_point"))
			.First();

		if (mountPoint == null) return;

		GameObject turret = this.CretePerfab(turretAssetBundleName, turretAssetName, mountPoint);
	}

    private GameObject CretePerfab(string bundleNam, string assetName, Transform tankMain) {
        GameObject hullPrefab = this.bundleLoader.getLoadedBundleByName(bundleNam).LoadAsset<GameObject>(assetName);
        GameObject hull = Instantiate(hullPrefab, tankMain);
        hull.GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);
        return hull;
    }

    private static void fixCamera(GameObject tankController) {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        camera.GetComponent<Camera>().cullingMask = 1073743877;
		CameraTargetOrientationScript script = camera.AddComponent<CameraTargetOrientationScript>();
        script.target = tankController.GetComponent<Transform>();
    }

    private void InitHullDb() {
		this.bundleLoader.GetLoadedAssetBundles()
			.ForEach(assetBundle => {
				assetBundle.GetAllAssetNames()
					.Where(assetName => assetName.Contains("assets/tanks/clientresources/content/tank/hull"))
					.Where(assetName => assetName.EndsWith(".prefab"))
					.ToList()
					.ForEach(assetName => {
						assetName = System.IO.Path.GetFileNameWithoutExtension(assetName);
                        this.hullMap.Add(assetName, assetBundle.name);
						this.hullKeys.Add(assetName);
						this.hullDropDown
							.AddOptions(new List<string> {assetName});
					});
			});

		this.bundleLoader.GetLoadedAssetBundles()
			.ForEach(assetBundle => {
				assetBundle.GetAllAssetNames()
					.Where(assetName => assetName.Contains("assets/tanks/clientresources/content/weapon"))
					.Where(assetName => assetName.EndsWith(".prefab"))
					.ToList()
					.ForEach(assetName => {
						assetName = System.IO.Path.GetFileNameWithoutExtension(assetName);
						Debug.Log(assetName+"----"+ assetBundle.name);
						if (this.turretMap.ContainsKey(assetName)) return;

						this.turretMap.Add(assetName, assetBundle.name);
						this.turretKeys.Add(assetName);
						this.TurretDropDown
							.AddOptions(new List<string> { assetName });
					});
			});
	}
	
}
