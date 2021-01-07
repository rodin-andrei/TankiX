
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class BundleLoader
{
    private readonly string dbPath = "/../../tankix_Data/db.json";
    private readonly string bDirPath = "/../../tankix_Data/AssetBundlesCache/StandaloneWindows/";

    public  BundleDb db;
    public readonly Dictionary<string, AssetBundle> loadedBundles = new Dictionary<string, AssetBundle>();

    public void Init()
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
            AssetBundle assetBundle = AssetBundle.LoadFromFile(Application.dataPath
               + this.bDirPath
               + bundleInfo.bundleName
                + "_" + Utils.longToHex(bundleInfo.crc)
                + ".bundle"); ;
            
            this.loadedBundles.Add(bundleInfo.bundleName, assetBundle);
        }
    }
 
    public List<AssetBundle> GetLoadedAssetBundles()
    {
        return this.loadedBundles.Values.ToList<AssetBundle>();
    }

    public AssetBundle getLoadedBundleByName(string name) {
        return this.loadedBundles[name];
    }
}