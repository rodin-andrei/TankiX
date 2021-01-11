using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientLogger.API;
using Platform.Library.ClientResources.API;
using Platform.Library.ClientUnityIntegration;
using Platform.Library.ClientUnityIntegration.API;
using Platform.System.Data.Statics.ClientConfigurator.API;
using Platform.System.Data.Statics.ClientConfigurator.Impl;
using SharpCompress.Compressor;
using SharpCompress.Compressor.Deflate;
using UnityEngine;

namespace Platform.Library.ClientResources.Impl
{
	public class ConfigurationActivator : UnityAwareActivator<ManuallyCompleting>
	{
		private WWWLoader wwwLoader;

		[Inject]
		public static ConfigurationService ConfigurationService
		{
			get;
			set;
		}

		[Inject]
		public new static EngineService EngineService
		{
			get;
			set;
		}

		protected override void Activate()
		{
			StartCoroutine(Load());
		}

		private IEnumerator Load()
		{
			string configsUrl = InitConfiguration.Config.ConfigsUrl;
			string url = AddProfileToUrl(configsUrl);
			LoggerProvider.GetLogger(this).Debug("Load configs:" + url);
			string urlWithRandom = url + "?rnd=" + new global::System.Random().NextDouble();
			wwwLoader = new WWWLoader(new WWW(urlWithRandom));
			while (!wwwLoader.IsDone)
			{
				yield return null;
			}
			if (!string.IsNullOrEmpty(wwwLoader.Error))
			{
				string errorMessage = string.Format("Configuration loading was failed. URL: {0}, Error: {1}", wwwLoader.URL, wwwLoader.Error);
				if (wwwLoader.Progress > 0f && wwwLoader.Progress < 1f)
				{
					HandleError<ServerDisconnectedEvent>(errorMessage);
				}
				else
				{
					HandleError<NoServerConnectionEvent>(errorMessage);
				}
				yield break;
			}
			if (wwwLoader.Bytes == null || wwwLoader.Bytes.Length == 0)
			{
				HandleError<GameDataLoadErrorEvent>("Empty configuration data. URL: " + wwwLoader.URL);
				yield break;
			}
			ConfigTreeNodeImpl configTreeNode;
			try
			{
				using (GZipStream inputStream = new GZipStream(new MemoryStream(wwwLoader.Bytes), CompressionMode.Decompress))
				{
					TarImporter tarImporter = new TarImporter();
					configTreeNode = tarImporter.ImportAll<ConfigTreeNodeImpl>(inputStream);
				}
			}
			catch (Exception ex)
			{
				HandleError<GameDataLoadErrorEvent>(string.Format("Invalid configuration data. URL: {0}, Error: {1}", wwwLoader.URL, ex.Message), ex);
				yield break;
			}
			ConfigTreeNodeImpl rootConfigNode = LocalConfiguration.rootConfigNode;
			rootConfigNode.Add(configTreeNode);
			((ConfigurationServiceImpl)ConfigurationService).SetRootConfigNode(rootConfigNode);
			DisposeWWWLoader();
			Complete();
		}

		private void HandleError<T>(string errorMessage) where T : Platform.Kernel.ECS.ClientEntitySystem.API.Event, new()
		{
			LoggerProvider.GetLogger(this).Error(errorMessage);
			HandleError<T>();
		}

		private void HandleError<T>(string errorMessage, Exception e) where T : Platform.Kernel.ECS.ClientEntitySystem.API.Event, new()
		{
			LoggerProvider.GetLogger(this).Error(errorMessage, e);
			HandleError<T>();
		}

		private void HandleError<T>() where T : Platform.Kernel.ECS.ClientEntitySystem.API.Event, new()
		{
			DisposeWWWLoader();
			Entity entity = EngineService.Engine.CreateEntity("RemoteConfigLoading");
			EngineService.Engine.ScheduleEvent<T>(entity);
		}

		private void DisposeWWWLoader()
		{
			wwwLoader.Dispose();
			wwwLoader = null;
		}

		private string AddProfileToUrl(string url)
		{
			List<string> list = new List<string>();
			ConfigurationProfileElement[] components = GetComponents<ConfigurationProfileElement>();
			foreach (ConfigurationProfileElement configurationProfileElement in components)
			{
				list.Add(configurationProfileElement.ProfileElement);
			}
			list.Sort();
			string currentClientVersion = StartupConfiguration.Config.CurrentClientVersion;
			string text = (currentClientVersion.Contains("-compatible") ? currentClientVersion.Substring(0, currentClientVersion.IndexOf("-compatible", StringComparison.Ordinal)) : currentClientVersion);
			url = url + "/" + text + "/";
			foreach (string item in list)
			{
				url = url + item + "/";
			}
			url += "config.tar.gz";
			return url;
		}
	}
}
