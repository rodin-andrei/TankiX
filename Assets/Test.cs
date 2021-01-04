using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
	private static readonly string dbPath = "/../../tankix_Data/db.json";

	private static readonly string bDirPath = "/../../tankix_Data/AssetBundlesCache/StandaloneWindows";

	public GameObject buttonPrefab;

	public GameObject contentRoot;

	public GameObject mapSelectorView;

	public Text statusText;

	private BundleDb db;

	private readonly Dictionary<BundleInfo, AssetBundle> loadedBundles = new Dictionary<BundleInfo, AssetBundle>();

	private int missingBundles;

	private void Awake()
	{
		Screen.SetResolution(Screen.currentResolution.width / 4, Screen.currentResolution.height / 2, false);
	}

	private void Start()
	{
		try
		{
			this.db = JsonUtility.FromJson<BundleDb>(File.ReadAllText(UnityEngine.Application.dataPath + Loader.dbPath));
		}
		catch
		{
			UnityEngine.Object.Destroy(this.contentRoot);
			this.statusText.text = "Error: Asset database not found.";
			this.statusText.gameObject.SetActive(true);
			return;
		}
		float num = 0f;
		BundleInfo[] bundles = this.db.bundles;
		for (int i = 0; i < bundles.Length; i++)
		{
			BundleInfo bundleInfo = bundles[i];
			if (bundleInfo.assets != null)
			{
				AssetInfo[] assets = bundleInfo.assets;
				for (int j = 0; j < assets.Length; j++)
				{
					AssetInfo assetInfo = assets[j];
					if (assetInfo.objectName.EndsWith(".unity"))
					{
						GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.buttonPrefab, this.mapSelectorView.transform);
						gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text = bundleInfo.bundleName;
						gameObject.GetComponent<Button>().onClick.AddListener(new UnityAction(this.OnSceneButtonClicked));
						num += 30f;
					}
				}
			}
		}
		float num2 = this.mapSelectorView.transform.GetChild(0).position.y;
		this.mapSelectorView.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, num);
		IEnumerator enumerator = this.mapSelectorView.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Transform transform = (Transform)enumerator.Current;
				Vector3 position = transform.position;
				position.y = num2;
				transform.position = position;
				num2 -= 30f;
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
	}

	private void OnSceneButtonClicked()
	{
		this.contentRoot.SetActive(false);
		this.statusText.gameObject.SetActive(true);
	}


	private void SetupCamera()
	{
		GameObject gameObject = GameObject.FindGameObjectWithTag("MainCamera");
		base.gameObject.transform.SetPositionAndRotation(gameObject.transform.position, gameObject.transform.rotation);
		UnityEngine.Object.Destroy(gameObject);
	}

	private void LoadSkybox()
	{
		GameObject gameObject = GameObject.Find("/Map");
		if (gameObject == null)
		{
			return;
		}
		//LazySkyboxComponet componentInChildren = gameObject.GetComponentInChildren<LazySkyboxComponet>();
		/*if (componentInChildren == null)
		{
			return;
		}
		string assetGuid = componentInChildren.SkyBoxReference.AssetGuid;
		AssetInfo skyboxAsset = this.FindAssetByGuid(assetGuid);
		AssetBundle assetBundle = this.LoadBundleFromInfo(this.FindBundleByAssetGuid(assetGuid));
		if (assetBundle == null)
		{
			return;
		}
		base.gameObject.GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;
		RenderSettings.skybox = (Material)assetBundle.LoadAllAssets()[Array.FindIndex<string>(assetBundle.GetAllAssetNames(), (string asset) => asset.Equals(skyboxAsset.objectName, StringComparison.OrdinalIgnoreCase))];*/
	}

	private BundleInfo FindBundle(string name)
	{
		BundleInfo[] bundles = this.db.bundles;
		for (int i = 0; i < bundles.Length; i++)
		{
			BundleInfo bundleInfo = bundles[i];
			if (bundleInfo.bundleName == name)
			{
				return bundleInfo;
			}
		}
		throw new KeyNotFoundException();
	}

	private BundleInfo FindBundleByAssetGuid(string guid)
	{
		BundleInfo[] bundles = this.db.bundles;
		for (int i = 0; i < bundles.Length; i++)
		{
			BundleInfo bundleInfo = bundles[i];
			if (bundleInfo.assets != null)
			{
				AssetInfo[] assets = bundleInfo.assets;
				for (int j = 0; j < assets.Length; j++)
				{
					AssetInfo assetInfo = assets[j];
					if (assetInfo.guid == guid)
					{
						return bundleInfo;
					}
				}
			}
		}
		throw new KeyNotFoundException();
	}

	private AssetInfo FindAssetByGuid(string guid)
	{
		BundleInfo[] bundles = this.db.bundles;
		for (int i = 0; i < bundles.Length; i++)
		{
			BundleInfo bundleInfo = bundles[i];
			if (bundleInfo.assets != null)
			{
				AssetInfo[] assets = bundleInfo.assets;
				for (int j = 0; j < assets.Length; j++)
				{
					AssetInfo assetInfo = assets[j];
					if (assetInfo.guid == guid)
					{
						return assetInfo;
					}
				}
			}
		}
		throw new KeyNotFoundException();
	}

	private AssetBundle LoadBundleFromInfo(BundleInfo bundle)
	{
		if (!this.loadedBundles.ContainsKey(bundle))
		{
			try
			{
				this.loadedBundles.Add(bundle, AssetBundle.LoadFromMemory(File.ReadAllBytes(string.Format("{0}/{1}_{2}.bundle", Application.dataPath + Loader.bDirPath, bundle.bundleName, bundle.crc.ToString("x8")))));
			}
			catch (Exception message)
			{
				Debug.LogError(message);
				this.loadedBundles.Add(bundle, null);
				this.missingBundles++;
				return null;
			}
			string[] dependenciesNames = bundle.dependenciesNames;
			for (int i = 0; i < dependenciesNames.Length; i++)
			{
				string name = dependenciesNames[i];
				this.LoadBundleFromInfo(this.FindBundle(name));
			}
		}
		return this.loadedBundles[bundle];
	}
}
