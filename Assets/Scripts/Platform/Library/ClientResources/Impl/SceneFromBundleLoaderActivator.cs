using System.Collections.Generic;
using System.Linq;
using log4net;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientLogger.API;
using Platform.Library.ClientResources.API;
using Platform.Library.ClientUnityIntegration;
using Platform.Library.ClientUnityIntegration.API;
using Platform.Library.ClientUnityIntegration.Impl;
using UnityEngine;

namespace Platform.Library.ClientResources.Impl
{
	public class SceneFromBundleLoaderActivator : UnityAwareActivator<ManuallyCompleting>, ECSActivator, Activator
	{
		public class SceneLoaderComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
		{
			public string sceneName;
		}

		public class LoadedSceneNode : Node
		{
			public SceneLoaderComponent sceneLoader;

			public ResourceDataComponent resourceData;
		}

		public class SceneLoaderNode : Node
		{
			public SceneLoaderComponent sceneLoader;

			public ResourceLoadStatComponent resourceLoadStat;
		}

		public GameObject progressBar;

		public AssetReference sceneListRef;

		private ILog logger;

		private bool startedLoading;

		private int loadingCount;

		private bool instantiating;

		[Inject]
		public new static EngineServiceInternal EngineService
		{
			get;
			set;
		}

		public SceneFromBundleLoaderActivator()
		{
			logger = LoggerProvider.GetLogger<SceneLoaderActivator>();
		}

		public void RegisterSystemsAndTemplates()
		{
			EngineService.SystemRegistry.RegisterNode<LoadedSceneNode>();
			EngineService.SystemRegistry.RegisterNode<SceneLoaderNode>();
		}

		protected override void Activate()
		{
			StartLoading();
		}

		private void Update()
		{
			SceneList sceneList = null;
			if (startedLoading)
			{
				IEnumerable<LoadedSceneNode> source = from n in EngineService.Engine.SelectAll<LoadedSceneNode>()
					where n.sceneLoader.sceneName.Equals(GetInstanceID().ToString())
					select n;
				if (source.Any())
				{
					sceneList = (SceneList)source.First().resourceData.Data;
				}
			}
			if (instantiating)
			{
				base.enabled = false;
				logger.Info("Complete");
				Complete();
			}
			else
			{
				if (!startedLoading || !(sceneList != null))
				{
					return;
				}
				logger.InfoFormat("Finished downloading scenes, instantiating...");
				instantiating = true;
				for (int i = 0; i < sceneList.scenes.Length; i++)
				{
					if (sceneList.scenes[i].initAfterLoading)
					{
						string sceneName = sceneList.scenes[i].sceneName;
						logger.InfoFormat("LoadScene {0}", sceneName);
						UnityUtil.LoadScene(sceneList.scenes[i].scene, sceneName, true);
					}
				}
			}
		}

		private void StartLoading()
		{
			startedLoading = true;
			if (progressBar != null)
			{
				progressBar.SetActive(true);
			}
			Entity entity = EngineService.Engine.CreateEntity("ScenesLoader");
			entity.AddComponent(new AssetReferenceComponent(sceneListRef));
			entity.AddComponent(new AssetRequestComponent
			{
				AssetStoreLevel = AssetStoreLevel.MANAGED
			});
			entity.AddComponent(new SceneLoaderComponent
			{
				sceneName = string.Empty + GetInstanceID()
			});
		}
	}
}
