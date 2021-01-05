using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BundleInformation : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        BundleLoader bundleLoader = new BundleLoader();
        bundleLoader.init();
        //checkAssetsInScreamBundle(bundleLoader);
        //checkValidJsonData(bundleLoader);

    }

    private static void checkValidJsonData(BundleLoader bundleLoader)
    {
        int count = bundleLoader.getLoadedAssetBundles()
            .Where(assetBundle => assetBundle != null)
            .Where(assetBundle =>
            {
                List<BundleInfo> bunleList = bundleLoader.db.bundles
                   .Where(bundleInfo => bundleInfo.bundleName == assetBundle.name)
                   .ToList();
                if (assetBundle.isStreamedSceneAssetBundle)
                    Debug.Log(bunleList[0].assets.Length == assetBundle.GetAllScenePaths().Length);
                else
                    Debug.Log(bunleList[0].assets.Length == assetBundle.GetAllAssetNames().Length);

                return true;
            }).ToList().Count;
        Debug.Log(count);
    }

    private static void checkAssetsInScreamBundle(BundleLoader bundleLoader)
    {
        bool v = bundleLoader.db.bundles.Length == bundleLoader.loadedBundles.Keys.Count;
        Debug.Log(v);
        List<AssetBundle> list = bundleLoader.loadedBundles.Values
            .Where(bundle => bundle != null)
            .Where(bundle =>
            {
                return bundle.AllAssetNames().Length == 0
                || bundle.isStreamedSceneAssetBundle;
            })
            .ToList();
        Debug.Log(list.Count);
        foreach (AssetBundle assetBundle in list)
        {
            Debug.Log(assetBundle.name);
        }
        foreach (AssetBundle assetBundle in list)
        {
            Debug.Log(assetBundle.isStreamedSceneAssetBundle);
        }
    }
}
