using System;
using System.IO;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientLogger.API;
using Platform.Library.ClientResources.API;
using Platform.Library.ClientUnityIntegration;
using Platform.Library.ClientUnityIntegration.API;
using Platform.System.Data.Statics.ClientYaml.API;
using Tanks.ClientLauncher.API;
using UnityEngine;

namespace Platform.Library.ClientResources.Impl
{
	public class InitConfigurationActivator : UnityAwareActivator<ManuallyCompleting>
	{
		private WWWLoader wwwLoader;

		[Inject]
		public static YamlService yamlService
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

		public static bool LauncherPassed
		{
			get;
			set;
		}

		protected override void Activate()
		{
			if (LauncherPassed)
			{
				Complete();
				return;
			}
			wwwLoader = new WWWLoader(new WWW(getInitUrl()));
			wwwLoader.MaxRestartAttempts = 0;
		}

		private string getInitUrl()
		{
			CommandLineParser commandLineParser = new CommandLineParser(Environment.GetCommandLineArgs());
			string paramValue;
			string text = ((!commandLineParser.TryGetValue(LauncherConstants.TEST_SERVER, out paramValue)) ? StartupConfiguration.Config.InitUrl : ("http://" + paramValue + ".test.tankix.com/config/init.yml"));
			return text + "?rnd=" + new global::System.Random().NextDouble();
		}

		private void Update()
		{
			if (wwwLoader == null || !wwwLoader.IsDone)
			{
				return;
			}
			if (!string.IsNullOrEmpty(wwwLoader.Error))
			{
				int responseCode = WWWLoader.GetResponseCode(wwwLoader.WWW);
				if (responseCode >= 400)
				{
					HandleError<TechnicalWorkEvent>();
				}
				else
				{
					HandleError<NoServerConnectionEvent>(string.Format("Initial config loading was failed. URL: {0}, Error: {1}", wwwLoader.URL, wwwLoader.Error));
				}
				return;
			}
			if (wwwLoader.Bytes == null || wwwLoader.Bytes.Length == 0)
			{
				HandleError<GameDataLoadErrorEvent>("Initial config is empty. URL: " + wwwLoader.URL);
				return;
			}
			try
			{
				using (MemoryStream stream = new MemoryStream(wwwLoader.Bytes))
				{
					StreamReader reader = new StreamReader(stream);
					InitConfiguration initConfiguration2 = (InitConfiguration.Config = yamlService.Load<InitConfiguration>(reader));
				}
			}
			catch (Exception ex)
			{
				HandleError<GameDataLoadErrorEvent>(string.Format("Invalid initial config. URL: {0}, Error: {1}", wwwLoader.URL, ex.Message), ex);
				return;
			}
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
			Engine engine = EngineService.Engine;
			Entity entity = engine.CreateEntity("InitConfigLoading");
			engine.ScheduleEvent<T>(entity);
		}

		private void DisposeWWWLoader()
		{
			if (wwwLoader != null)
			{
				wwwLoader.Dispose();
				wwwLoader = null;
			}
		}
	}
}
