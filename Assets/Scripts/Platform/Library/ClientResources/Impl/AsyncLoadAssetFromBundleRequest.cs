using System;
using System.Collections.Generic;
using log4net;
using Platform.Library.ClientLogger.API;
using Platform.Library.ClientResources.API;
using UnityEngine;

namespace Platform.Library.ClientResources.Impl
{
	public class AsyncLoadAssetFromBundleRequest : LoadAssetFromBundleRequest
	{
		private readonly AssetBundle bundle;

		private readonly string objectName;

		private readonly Type objectType;

		private AssetBundleRequest assetBundleRequest;

		private static ILog log;

		private static List<AssetBundleRequest> assetBundleRequestList = new List<AssetBundleRequest>();

		private bool isStreamedSceneAssetBundle;

		public AssetBundle Bundle
		{
			get
			{
				return bundle;
			}
		}

		public string ObjectName
		{
			get
			{
				return objectName;
			}
		}

		public Type ObjectType
		{
			get
			{
				return objectType;
			}
		}

		public bool IsStarted
		{
			get;
			private set;
		}

		public bool IsDone
		{
			get
			{
				if (!IsStarted)
				{
					return false;
				}
				if (isStreamedSceneAssetBundle)
				{
					return true;
				}
				if (assetBundleRequest == null)
				{
					return false;
				}
				return assetBundleRequest.isDone;
			}
		}

		public UnityEngine.Object Asset
		{
			get
			{
				if (isStreamedSceneAssetBundle)
				{
					return null;
				}
				if (!IsDone)
				{
					return null;
				}
				assetBundleRequestList.Remove(assetBundleRequest);
				return assetBundleRequest.asset;
			}
		}

		public AsyncLoadAssetFromBundleRequest(AssetBundle bundle, string objectName, Type objectType)
		{
			this.bundle = bundle;
			this.objectName = objectName;
			this.objectType = objectType;
		}

		public void StartExecute()
		{
			IsStarted = true;
			GetLogger().InfoFormat("LoadAssetAsync objectName={0} objectType={1}", objectName, objectType);
			if (bundle.isStreamedSceneAssetBundle)
			{
				isStreamedSceneAssetBundle = true;
				return;
			}
			assetBundleRequest = bundle.LoadAssetAsync(objectName, objectType);
			assetBundleRequestList.Add(assetBundleRequest);
		}

		private ILog GetLogger()
		{
			if (log == null)
			{
				log = LoggerProvider.GetLogger(this);
			}
			return log;
		}
	}
}
