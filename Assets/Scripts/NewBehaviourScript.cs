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

        List<AssetBundle> list=  findScenes();
        
        loadScene(list[0]);
    }

    private List<AssetBundle> findScenes()
    {
        return this.bundleLoader.getLoadedAssetBundles()
            .Where(bundle => bundle != null)
            .Where(bundle => {
                if (bundle.isStreamedSceneAssetBundle)
                    Debug.Log(bundle.name);
                return bundle.isStreamedSceneAssetBundle;
            })
            .Where(bundle => bundle.name.Contains("arag"))
            .ToList();
    }

    private void OnSceneButtonClicked()
    {
       
    }

    private void loadScene(AssetBundle assetBundle)
    {
     
        string[] scenePaths = assetBundle.GetAllScenePaths();
        foreach(string scenePath in scenePaths)
        {
            Debug.Log(scenePath);
        }

        string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePaths[0]);
        SceneManager.LoadScene(sceneName);
    }

   
}
 

