using System;
using System.IO;
using System.Linq;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientLogger.API;
using Platform.Library.ClientResources.API;
using Platform.Library.ClientUnityIntegration;
using Platform.Library.ClientUnityIntegration.API;
using Platform.System.Data.Statics.ClientConfigurator.API;
using Platform.System.Data.Statics.ClientConfigurator.Impl;
using Platform.System.Data.Statics.ClientYaml.API;
using UnityEngine;

namespace Platform.Library.ClientResources.Impl
{
	public class LocalConfigurationActivator : UnityAwareActivator<ManuallyCompleting>
	{
		private WWWLoader wwwLoader;

		private ConfigurationProfileImpl configurationProfile;

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
			LoadConfigs();
		}

		private void LoadConfigs()
		{
			string text = Application.dataPath + "/" + ConfigPath.CONFIG;
			if (!Directory.Exists(text))
			{
				HandleError(string.Format("Local configuration folder '{0}' was not found", text));
				return;
			}
			try
			{
				FileSystemConfigsImporter fileSystemConfigsImporter = new FileSystemConfigsImporter();
				configurationProfile = new ConfigurationProfileImpl();
				ConfigTreeNodeImpl rootConfigNode = fileSystemConfigsImporter.Import<ConfigTreeNodeImpl>(text, configurationProfile);
				((ConfigurationServiceImpl)ConfigurationService).SetRootConfigNode(rootConfigNode);
				configurationProfile = new ConfigurationProfileImpl(GetProfiles());
				rootConfigNode = fileSystemConfigsImporter.Import<ConfigTreeNodeImpl>(text, configurationProfile);
				((ConfigurationServiceImpl)ConfigurationService).SetRootConfigNode(rootConfigNode);
				LocalConfiguration.rootConfigNode = rootConfigNode;
				SetLoadingStopTimeout();
				Complete();
			}
			catch (Exception ex)
			{
				HandleError(string.Format("Invalid local configuration data. Path: {0}, Error: {1}", text, ex.Message), ex);
			}
		}

		private void SetLoadingStopTimeout()
		{
			try
			{
				YamlNode config = ConfigurationService.GetConfig(ConfigPath.LOADING_STOP_TIMEOUT);
				WWWLoader.DEFAULT_TIMEOUT_SECONDS = int.Parse(config.GetStringValue("timeoutInSec"));
			}
			catch (Exception ex)
			{
				LoggerProvider.GetLogger(this).Error(ex.Message, ex);
			}
		}

		private void HandleError(string errorMessage)
		{
			LoggerProvider.GetLogger(this).Error(errorMessage);
			HandleError();
		}

		private void HandleError(string errorMessage, Exception e)
		{
			LoggerProvider.GetLogger(this).Error(errorMessage, e);
			HandleError();
		}

		private void HandleError()
		{
			Engine engine = EngineService.Engine;
			Entity entity = engine.CreateEntity("LocalConfigurationLoadingError");
			engine.ScheduleEvent<InvalidLocalConfigurationErrorEvent>(entity);
		}

		private string[] GetProfiles()
		{
			ConfigurationProfileElement[] components = GetComponents<ConfigurationProfileElement>();
			if (components.Count() == 0)
			{
				return null;
			}
			string[] array = new string[components.Count()];
			for (int i = 0; i < components.Count(); i++)
			{
				array[i] = components[i].ProfileElement;
			}
			return array;
		}
	}
}
