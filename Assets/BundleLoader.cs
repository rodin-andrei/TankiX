
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class BundleLoader
{
    private  readonly string dbPath = "/../../tankix_Data/db.json";
    private  readonly string bDirPath = "/../../tankix_Data/AssetBundlesCache/StandaloneWindows/";

    private BundleDb db;
    private readonly Dictionary<BundleInfo, AssetBundle> loadedBundles = new Dictionary<BundleInfo, AssetBundle>();

    public void init()
    {
        try
        {
            this.db = JsonUtility.FromJson<BundleDb>(File.ReadAllText(Application.dataPath + this.dbPath));
        }
        catch
        {
            UnityEngine.Debug.LogError("Can`t load db json");
        }

        foreach (BundleInfo bundleInfo in this.db.bundles)
        {
            AssetBundle assetBundle = loadAssetBundle(bundleInfo);
            this.loadedBundles.Add(bundleInfo, assetBundle);
        }
    }
   
    private  AssetBundle loadAssetBundle(BundleInfo bundleInfo)
    {
        return AssetBundle.LoadFromFile(Application.dataPath + bDirPath
            + bundleInfo.bundleName + "_" + Utils.longToHex(bundleInfo.crc) + ".bundle");
    }

    public void loadDependencies(BundleInfo _bundleInfo)
    {
        string[] dependenciesNames = _bundleInfo.dependenciesNames;
        foreach (string depenedencyName in dependenciesNames)
        {
            foreach (BundleInfo bundleInfo in this.db.bundles)
            {
                if (bundleInfo.bundleName == depenedencyName)
                {
                    AssetBundle assetBundle = this.loadedBundles[bundleInfo];
                    if (assetBundle == null)
                    {
                        UnityEngine.Debug.LogError("Bundle null");
                        continue;
                    }

                    UnityEngine.Object[] objects = assetBundle.LoadAllAssets();
                }
            }
        }
    }

    public List<AssetBundle> getLoadedAssetBundles()
    {
        return loadedBundles.Values.ToList<AssetBundle>();
    }
}