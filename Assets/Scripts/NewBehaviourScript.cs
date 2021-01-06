using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    private BundleLoader bundleLoader;
    private SceneLoader sceneLoader;

	private void Start()
    {
        this.bundleLoader = new BundleLoader();
        this.bundleLoader.Init();
        this.sceneLoader = new SceneLoader(this.bundleLoader);
        List<string> scenePatchs = this.sceneLoader.GetScenePatchs();
        this.sceneLoader.LoadScene(scenePatchs[0]);
     
        


        /* List<AssetBundle> hunts= findHunt("m0_0d4b2553");
         hunts[0].GetAllAssetNames()
             .ToList()
             .ForEach(assetName => Debug.Log("AssetName= " + assetName));

         GameObject gameObject1 = hunts[0].LoadAsset<GameObject>("TitanM0");
         Instantiate(gameObject1, this.GetComponent<Transform>());
         List<AssetBundle> turrets = findHunt("thunder_xt_cf86d645");
         turrets[0].GetAllAssetNames()
             .ToList()
             .ForEach(assetName => Debug.Log("AssetName= " + assetName));

         GameObject gameObject2 = turrets[0].LoadAsset<GameObject>("Thunder_XT");
         Instantiate(gameObject2, this.GetComponent<Transform>());*/

    }
    public void Update() {
        GameObject tankPoint = GameObject.Find("Tank");
        Debug.LogError(tankPoint == null);
    }

    private List<AssetBundle> findHunt(String name) {
        return this.bundleLoader.GetLoadedAssetBundles()
            .Where(bundle => bundle != null)
            .Where(bundle => {
                return !bundle.isStreamedSceneAssetBundle;
            })
            .Where(bundle => bundle.name.Contains(name))
            .ToList();
    }   
}
 

