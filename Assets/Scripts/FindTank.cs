using Assets.Scripts.extractor.impl;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FindTank : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Dictionary<string, HashSet<string>> map = new Dictionary<string, HashSet<string>>();

        BundleLoader bundleLoader = new BundleLoader();
        bundleLoader.init();
        getStatistic(map, bundleLoader);
        extraxt(map, bundleLoader);
    }

    private static void extraxt(Dictionary<string, HashSet<string>> map, BundleLoader bundleLoader) {
        bundleLoader.getLoadedAssetBundles()
                    .Where(bundle => bundle != null && !bundle.isStreamedSceneAssetBundle)
                    .Take(40)
                    .ToList()
                    .ForEach(bundle => {
                        bundle.GetAllAssetNames()
                        .ToList()
                        .ForEach(assetName => {
                            Object asset = bundle.LoadAsset(assetName);
                            if (assetName.Split('.').Last().Equals("png")&& asset as UnityEngine.Texture2D) {
                                new Texture2DToPngExtractorRecourses().extraxt(asset, assetName);
                            }
                        });
                    });
    }
        private static void getStatistic(Dictionary<string, HashSet<string>> map, BundleLoader bundleLoader) {
        bundleLoader.getLoadedAssetBundles()
                    .Where(bundle => bundle != null && !bundle.isStreamedSceneAssetBundle)
                    .Take(40)
                    .ToList()
                    .ForEach(bundle => {
                        bundle.GetAllAssetNames()
                        .ToList()
                        .ForEach(assetName => {
                            Object asset = bundle.LoadAsset(assetName);
                            if (asset == null) {
                                Debug.LogError(assetName);
                                return;
                            }
                            if (!map.ContainsKey(assetName.Split('.').Last())) {
                                map.Add(assetName.Split('.').Last(), new HashSet<string>());
                            }
                            map[assetName.Split('.').Last()].Add(asset.GetType() + "");
                        });
                    });

        string t = "";
        map.Keys.ToList()
            .ForEach(key => {
                t += key + "\n";
                map[key].ToList()
                .ForEach(value => {
                    t += ("----" + value + "\n");

                });
            });
        Debug.LogError(t);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
