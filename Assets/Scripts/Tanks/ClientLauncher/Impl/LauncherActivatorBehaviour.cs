using System;
using System.Collections.Generic;
using System.Linq;
using Platform.Common.ClientECSCommon.src.main.csharp.Impl;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientLogger.API;
using Platform.Library.ClientLogger.Impl;
using Platform.Library.ClientProtocol.Impl;
using Platform.Library.ClientResources.API;
using Platform.Library.ClientUnityIntegration.Impl;
using Platform.System.Data.Statics.ClientConfigurator.Impl;
using Platform.System.Data.Statics.ClientYaml.Impl;
using Platform.Tool.ClientUnityLogger.Impl;
using Tanks.ClientLauncher.API;
using Tanks.Lobby.ClientNavigation.API;
using Tanks.Lobby.ClientNavigation.Impl;
using UnityEngine;

namespace Tanks.ClientLauncher.Impl
{
	public class LauncherActivatorBehaviour : MonoBehaviour
	{
		private readonly Type[] environmentActivators = new Type[7]
		{
			typeof(ClientLoggerActivator),
			typeof(ClientUnityLoggerActivator),
			typeof(ClientProtocolActivator),
			typeof(YamlActivator),
			typeof(ConfigurationServiceActivator),
			typeof(EntitySystemActivator),
			typeof(ClientECSCommonActivator)
		};

		public void Awake()
		{
			ProcessAdditionalClientCommands();
			if (ClientUpdater.IsUpdaterRunning())
			{
				Application.Quit();
				return;
			}
			SceneSwitcher.Clean();
			if (!TryUpdateVersion())
			{
				LaunchActivators();
			}
		}

		private bool TryUpdateVersion()
		{
			if (ClientUpdater.IsApplicationRunInUpdateMode())
			{
				ClientUpdater.Update();
				return true;
			}
			return false;
		}

		private void LaunchActivators()
		{
			try
			{
				ActivatorsLauncher activatorsLauncher = new ActivatorsLauncher(environmentActivators.Select((Type t) => (Platform.Kernel.OSGi.ClientCore.API.Activator)System.Activator.CreateInstance(t)));
				activatorsLauncher.LaunchAll(delegate
				{
					new ActivatorsLauncher(GetActivatorsAddedInUnityEditor()).LaunchAll(OnAllActivatorsLaunched);
				});
			}
			catch (Exception ex)
			{
				LoggerProvider.GetLogger<LauncherActivatorBehaviour>().Error(ex.Message, ex);
				FatalErrorHandler.ShowFatalErrorScreen();
			}
		}

		private void OnAllActivatorsLaunched()
		{
			base.gameObject.AddComponent<PreciseTimeBehaviour>();
			base.gameObject.AddComponent<EngineBehaviour>();
			GetComponent<LauncherBehaviour>().Launch();
		}

		private IEnumerable<Platform.Kernel.OSGi.ClientCore.API.Activator> GetActivatorsAddedInUnityEditor()
		{
			return from a in base.gameObject.GetComponentsInChildren<Platform.Kernel.OSGi.ClientCore.API.Activator>()
				where ((MonoBehaviour)a).enabled
				select a;
		}

		private void ProcessAdditionalClientCommands()
		{
			CommandLineParser commandLineParser = new CommandLineParser(Environment.GetCommandLineArgs());
			string paramValue;
			if (commandLineParser.TryGetValue(LauncherConstants.CLEAN_PREFS, out paramValue))
			{
				PlayerPrefs.DeleteAll();
			}
		}
	}
}
