using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader{
    private readonly BundleLoader bundleLoader;
    private readonly Dictionary<string, string> scenes = new Dictionary<string, string>();

    public SceneLoader(BundleLoader bundleLoader) {
        this.bundleLoader = bundleLoader;

        this.bundleLoader.loadedBundles.Values
            .Where(assetBundle => assetBundle != null)
            .Where(assetBundle => assetBundle.isStreamedSceneAssetBundle)
            .ToList()
            .ForEach(assetBundle => {
                assetBundle.GetAllScenePaths()
                    .ToList()
                    .ForEach(scenePath => {
                        this.scenes.Add(scenePath, assetBundle.name);
                        Debug.Log(scenePath + "------" + assetBundle.name);
                    });
            });
    }

    internal void LoadScene(string scenePath) {

        string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public List<string> GetScenePatchs() {
        return this.scenes.Keys.ToList();
    }
}
