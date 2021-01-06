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

public class MapViewer : MonoBehaviour
{
    private BundleLoader bundleLoader;
    private SceneLoader sceneLoader;

    public Dropdown Dropdown;
    List<string> scenePatchs;

    private void Start()
    {
        this.bundleLoader = new BundleLoader();
        this.bundleLoader.Init();
        this.sceneLoader = new SceneLoader(this.bundleLoader);
        this.scenePatchs = this.sceneLoader.GetScenePatchs();
        this.scenePatchs.ForEach(scenePatch => this.Dropdown.AddOptions(
            new List<Dropdown.OptionData> { new Dropdown.OptionData(System.IO.Path.GetFileNameWithoutExtension(scenePatch)) }
        ));
    }
    public void DropdownValueChanged() {
        Destroy(GameObject.Find("Map"));
        this.sceneLoader.LoadScene(this.scenePatchs[this.Dropdown.value]);
        StartCoroutine(myC());


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
    IEnumerator myC() {
        yield return null;
        GameObject.FindGameObjectsWithTag("MainCamera")
           .ToList()
           .ForEach(camera => {
               camera.AddComponent<FreeCamera>();
           });
    }
}
 

