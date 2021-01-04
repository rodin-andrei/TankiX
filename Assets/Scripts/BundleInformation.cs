using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BundleInformation : MonoBehaviour {

	// Use this for initialization
	void Start () {
        BundleLoader bundleLoader = new BundleLoader();
		bundleLoader.init();

        bool v = bundleLoader.db.bundles.Length== bundleLoader.loadedBundles.Keys.Count;
		Debug.Log(v);
        List<AssetBundle> list = bundleLoader.loadedBundles.Values
			.Where(bundle => bundle != null)
			.Where(bundle =>
			{
				return bundle.AllAssetNames().Length == 0 || bundle.isStreamedSceneAssetBundle;
            })
			.ToList();
		Debug.Log(list.Count);
        foreach  (AssetBundle assetBundle in list)
        {
            Debug.Log(assetBundle.name);
        }
		foreach (AssetBundle assetBundle in list)
		{
			Debug.Log(assetBundle.isStreamedSceneAssetBundle);
		}


	}
	
	
}
