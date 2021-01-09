using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AllPrefabsViewController : MonoBehaviour {

	Dictionary<string, List<string>> hulls = new Dictionary<string, List<string>>();
	Dictionary<string, List<string>> turrets = new Dictionary<string, List<string>>();
	BundleLoader bundleLoader;
	private int i=-1;
	private int j=0;
	private List<string> names = new List<string>();
	void Start () {
        this.bundleLoader = new BundleLoader();
        this.bundleLoader.Init();
	}
	
	public void onNext() {
        Transform transform1 = this.gameObject.GetComponent<Transform>();
		foreach (Transform child in transform) Destroy(child.gameObject);
        GameObject p = Instantiate(nextPrefab(), this.GetComponent<Transform>());
		p.GetComponent<Transform>().localPosition = new Vector3();
    }

	public void onSave() {
		Debug.Log(MyDictionaryToJson(this.hulls));
		Debug.Log(MyDictionaryToJson(this.turrets));
    }
	string MyDictionaryToJson(Dictionary<string, List<string>> dict) {
		string json= "{";
		dict.Keys.ToList()
			.ForEach(key => {
				
                json += "\"" + key + "\":[";
				dict[key].ForEach(value => {
					json += "\"" + value + "\",";
				});
				json = json.Remove(json.Length - 1);
				json += "],";
			}
		);
		json = json.Remove(json.Length - 1);
		json += "}";
		return json;	
	}

	bool first = true;
	private GameObject nextPrefab() {
       if(j >= this.names.Count) {
			i++;
			this.names = this.bundleLoader.loadedBundles[this.bundleLoader.loadedBundles.Keys.ToList()[i]].AllAssetNames()
				.Where(name => name.EndsWith(".prefab"))
				.ToList();
			if (names.Count == 0) return nextPrefab();
			Debug.Log("Update names count" + this.names.Count);
			j = 0;
        }
		Debug.Log(i + "-" + j);
		return this.bundleLoader.loadedBundles[this.bundleLoader.loadedBundles.Keys.ToList()[i]].LoadAsset<GameObject>(this.names[j++]);

    }
}
