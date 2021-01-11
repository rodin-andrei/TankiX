using System;
using System.Collections.Generic;
using System.IO;
using log4net;
using Platform.Library.ClientLogger.API;
using Platform.Library.ClientResources.API;
using Platform.Library.ClientUnityIntegration.API;
using Platform.Library.ClientUnityIntegration.Impl;
using UnityEngine;

namespace Platform.Library.ClientResources.Impl
{
	public class AssetBundleDiskCacheTask : IDisposable
	{
		private struct TaskRunner
		{
			public Action runner;

			public Action error;

			public Action timeOut;

			public float timeOutValue;
		}

		public static readonly int RELOAD_FROM_HTTP_ATTEMPTS = 2;

		public static readonly int CRC_RELOAD_ATTEMPS = 2;

		public static readonly int BUNDLE_RECRATION_ATTEMPS = 2;

		public static Crc32 CRC32 = new Crc32();

		private AssetBundleDiskCache assetBundleDiskCache;

		private Dictionary<AssetBundleDiskCacheState, Action> state2action = new Dictionary<AssetBundleDiskCacheState, Action>(10);

		private WWWLoader wwwLoader;

		private AssetBundleCreateRequest createRequest;

		private DiskCacheWriterRequest writeRequest;

		private int loadFromHttpAttempts = RELOAD_FROM_HTTP_ATTEMPTS;

		private int crcReloadAttempts = CRC_RELOAD_ATTEMPS;

		private int bundleCreationAttempts = BUNDLE_RECRATION_ATTEMPS;

		private float taskNextRunTime;

		private byte[] buffer;

		private string url;

		public AssetBundleDiskCacheRequest AssetBundleDiskCacheRequest
		{
			get;
			private set;
		}

		public bool IsDone
		{
			get;
			private set;
		}

		public AssetBundleInfo AssetBundleInfo
		{
			get;
			private set;
		}

		public AssetBundle AssetBundle
		{
			get;
			private set;
		}

		public string Error
		{
			get;
			private set;
		}

		public float Progress
		{
			get;
			private set;
		}

		public AssetBundleDiskCacheState State
		{
			get;
			private set;
		}

		private ILog Log
		{
			get;
			set;
		}

		public AssetBundleDiskCacheTask(AssetBundleDiskCache _assetBundleDiskCache)
		{
			assetBundleDiskCache = _assetBundleDiskCache;
			state2action.Add(AssetBundleDiskCacheState.INIT, Initialize);
			state2action.Add(AssetBundleDiskCacheState.START_LOAD_FROM_HTTP, StartLoadFromHTTP);
			state2action.Add(AssetBundleDiskCacheState.LOADING_FROM_HTTP, LoadingFromHTTP);
			state2action.Add(AssetBundleDiskCacheState.START_LOAD_FROM_DISK, StartLoadFromDisk);
			state2action.Add(AssetBundleDiskCacheState.START_WRITE_TO_DISK, StartWriteToDisk);
			state2action.Add(AssetBundleDiskCacheState.WRITE_TO_DISK, WriteToDisk);
			state2action.Add(AssetBundleDiskCacheState.CREATE_ASSETBUNDLE, CreateAssetBundle);
			state2action.Add(AssetBundleDiskCacheState.COMPLETE, Complete);
			Log = LoggerProvider.GetLogger(this);
		}

		public AssetBundleDiskCacheTask Init(AssetBundleDiskCacheRequest request)
		{
			AssetBundleInfo = request.AssetBundleInfo;
			AssetBundleDiskCacheRequest = request;
			return this;
		}

		public bool Run()
		{
			AssetBundleDiskCacheState state;
			do
			{
				if (Time.realtimeSinceStartup < taskNextRunTime)
				{
					return IsDone;
				}
				state = State;
				UnityProfiler.OnBeginSample("Invoke " + State);
				state2action[State]();
				UnityProfiler.OnEndSample();
			}
			while (state != State);
			UpdateRequest();
			return IsDone;
		}

		private void Initialize()
		{
			if (assetBundleDiskCache.IsCached(AssetBundleInfo))
			{
				State = AssetBundleDiskCacheState.START_LOAD_FROM_DISK;
			}
			else
			{
				State = AssetBundleDiskCacheState.START_LOAD_FROM_HTTP;
			}
		}

		public void Complete()
		{
			if (wwwLoader != null)
			{
				wwwLoader.Dispose();
				wwwLoader = null;
			}
			Progress = 1f;
			IsDone = true;
		}

		private void StartLoadFromHTTP()
		{
			url = AssetBundleNaming.GetAssetBundleUrl(assetBundleDiskCache.BaseUrl, AssetBundleInfo.Filename);
			if (loadFromHttpAttempts < RELOAD_FROM_HTTP_ATTEMPTS)
			{
				url = string.Format("{0}?rnd={1}", url, UnityEngine.Random.value);
			}
			Console.WriteLine("Start download url: {0}", url);
			wwwLoader = new WWWLoader(new WWW(url));
			wwwLoader.MaxRestartAttempts = 0;
			State = AssetBundleDiskCacheState.LOADING_FROM_HTTP;
		}

		private void LoadingFromHTTP()
		{
			if (!string.IsNullOrEmpty(wwwLoader.Error))
			{
				if (loadFromHttpAttempts-- > 0)
				{
					int num = RELOAD_FROM_HTTP_ATTEMPTS - loadFromHttpAttempts + 2;
					LoggerProvider.GetLogger(this).WarnFormat("AssetBundle download failed, try attempt {0}, URL: {1}, ERROR: {2}", num, url, wwwLoader.Error);
					wwwLoader.Dispose();
					State = AssetBundleDiskCacheState.START_LOAD_FROM_HTTP;
				}
				else
				{
					Error = string.Format("{0}, url: {1}", wwwLoader.Error, url);
					State = AssetBundleDiskCacheState.COMPLETE;
				}
				return;
			}
			Progress = wwwLoader.Progress;
			if (wwwLoader.IsDone)
			{
				buffer = wwwLoader.Bytes;
				if (!AssetBundleDiskCacheRequest.UseCrcCheck || CheckCrc())
				{
					wwwLoader.Dispose();
					State = AssetBundleDiskCacheState.START_WRITE_TO_DISK;
				}
			}
		}

		private bool CheckCrc()
		{
			if (CRC32.Compute(buffer) != AssetBundleInfo.CacheCRC)
			{
				if (crcReloadAttempts-- > 0)
				{
					LoggerProvider.GetLogger(this).WarnFormat("Crc mismatch while loading {0}, try to download it agan ", AssetBundleInfo.BundleName);
					buffer = null;
					State = AssetBundleDiskCacheState.START_LOAD_FROM_HTTP;
					return false;
				}
				Error = string.Format("Crc mismatch while loading {0}", AssetBundleInfo.BundleName);
				State = AssetBundleDiskCacheState.COMPLETE;
				return false;
			}
			return true;
		}

		private void StartWriteToDisk()
		{
			writeRequest = assetBundleDiskCache.WriteToDiskCache(assetBundleDiskCache.GetAssetBundleCachePath(AssetBundleInfo), buffer);
			State = AssetBundleDiskCacheState.WRITE_TO_DISK;
		}

		private void WriteToDisk()
		{
			if (writeRequest.IsDone)
			{
				if (!string.IsNullOrEmpty(writeRequest.Error))
				{
					Error = writeRequest.Error;
					State = AssetBundleDiskCacheState.COMPLETE;
				}
				else
				{
					buffer = null;
					State = AssetBundleDiskCacheState.START_LOAD_FROM_DISK;
				}
			}
		}

		private void StartLoadFromDisk()
		{
			string assetBundleCachePath = assetBundleDiskCache.GetAssetBundleCachePath(AssetBundleInfo);
			if (!CheckFileIsValid(assetBundleCachePath))
			{
				if (!HandleRestartOnBundleCreationFail())
				{
					Error = string.Format("Can't load assetbundle {0}, file is corrupted {1}", AssetBundleInfo.BundleName, assetBundleCachePath);
					State = AssetBundleDiskCacheState.COMPLETE;
				}
			}
			else
			{
				createRequest = AssetBundle.LoadFromFileAsync(assetBundleCachePath);
				State = AssetBundleDiskCacheState.CREATE_ASSETBUNDLE;
			}
		}

		private bool CheckFileIsValid(string path)
		{
			try
			{
				FileInfo fileInfo = new FileInfo(path);
				if (fileInfo.Length != AssetBundleInfo.Size)
				{
					return false;
				}
			}
			catch (IOException)
			{
				return false;
			}
			return true;
		}

		private void CreateAssetBundle()
		{
			if (!createRequest.isDone)
			{
				return;
			}
			AssetBundle = createRequest.assetBundle;
			if (AssetBundle == null)
			{
				if (HandleRestartOnBundleCreationFail())
				{
					return;
				}
				Error = string.Format("failed to create assetbundle {0}", AssetBundleInfo.BundleName);
			}
			State = AssetBundleDiskCacheState.COMPLETE;
		}

		private bool HandleRestartOnBundleCreationFail()
		{
			if (bundleCreationAttempts-- > 0)
			{
				Sleep(0.5f);
				LoggerProvider.GetLogger(this).WarnFormat("Failed to create assetBundle {0}, try to create it agan ", AssetBundleInfo.BundleName);
				State = AssetBundleDiskCacheState.START_LOAD_FROM_DISK;
				return true;
			}
			if (loadFromHttpAttempts-- > 0)
			{
				LoggerProvider.GetLogger(this).WarnFormat("Failed to create assetBundle {0}, try to download it agan ", AssetBundleInfo.BundleName);
				if (assetBundleDiskCache.CleanCache(AssetBundleInfo))
				{
					State = AssetBundleDiskCacheState.START_LOAD_FROM_HTTP;
					return true;
				}
			}
			return false;
		}

		private void UpdateRequest()
		{
			AssetBundleDiskCacheRequest.IsDone = IsDone;
			AssetBundleDiskCacheRequest.AssetBundle = AssetBundle;
			AssetBundleDiskCacheRequest.Progress = Progress;
			AssetBundleDiskCacheRequest.Error = Error;
		}

		public void Dispose()
		{
			if (wwwLoader != null)
			{
				wwwLoader.Dispose();
				wwwLoader = null;
			}
			buffer = null;
		}

		public void Sleep(float seconds)
		{
			taskNextRunTime = Time.realtimeSinceStartup + seconds;
		}
	}
}
