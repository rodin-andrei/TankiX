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
	
    
    public GameObject buttonPrefab;
    public GameObject mapSelectorView;

    private BundleLoader bundleLoader;

	private void Start()
    {
        this.bundleLoader = new BundleLoader();
        this.bundleLoader.init();

        List<AssetBundle> sceneAssetBundles=  findSceneAssetBundles();
        
        loadScene(sceneAssetBundles[0]);

        List<AssetBundle> hunts= findHunt("m0_0d4b2553");
        hunts[0].GetAllAssetNames()
            .ToList()
            .ForEach(assetName => Debug.Log("AssetName= " + assetName));
      
        GameObject gameObject1 = hunts[0].LoadAsset<GameObject>("TitanM0");
        Instantiate(gameObject1, this.GetComponent<Transform>());
        List<AssetBundle> turrets = findHunt("m0_13f9648e");
        turrets[0].GetAllAssetNames()
            .ToList()
            .ForEach(assetName => Debug.Log("AssetName= " + assetName));
         
        GameObject gameObject2 = turrets[0].LoadAsset<GameObject>("FreezeM0_new");
        Instantiate(gameObject2, this.GetComponent<Transform>());

    }

    private List<AssetBundle> findSceneAssetBundles()
    {
        return this.bundleLoader.getLoadedAssetBundles()
            .Where(bundle => bundle != null)
            .Where(bundle => {
                if (bundle.isStreamedSceneAssetBundle)
                    Debug.Log(bundle.name  + " bundle is StreamedSceneAssetBundle ");
                return bundle.isStreamedSceneAssetBundle;
            })
            .Where(bundle => bundle.name.Contains("ran"))
            .ToList();
    }

    private List<AssetBundle> findHunt(String name) {
        return this.bundleLoader.getLoadedAssetBundles()
            .Where(bundle => bundle != null)
            .Where(bundle => {
                return !bundle.isStreamedSceneAssetBundle;
            })
            .Where(bundle => bundle.name.Contains(name))
            .ToList();
    }

    private void OnSceneButtonClicked()
    {
       
    }

    private void loadScene(AssetBundle assetBundle)
    {
        string[] scenePaths = assetBundle.GetAllScenePaths();
        string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePaths[0]);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
}
 

