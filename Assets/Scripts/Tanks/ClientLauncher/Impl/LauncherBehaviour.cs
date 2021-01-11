using System;
using System.IO;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientLogger.API;
using Platform.Library.ClientResources.API;
using Platform.Library.ClientResources.Impl;
using Platform.System.Data.Statics.ClientConfigurator.API;
using Tanks.ClientLauncher.API;
using Tanks.Lobby.ClientNavigation.API;
using Tanks.Lobby.ClientNavigation.Impl;
using UnityEngine;

namespace Tanks.ClientLauncher.Impl
{
	public class LauncherBehaviour : MonoBehaviour
	{
		[SerializeField]
		private GameObject downloadScreen;

		[SerializeField]
		private GameObject errorDialogScreen;

		private static LauncherBehaviour instance;

		private string currentVersion;

		private string remoteVersion;

		private string distributionUrl;

		private string executable;

		[Inject]
		public static ConfigurationService ConfigurationService
		{
			get;
			set;
		}

		[Inject]
		public static EngineServiceInternal EngineService
		{
			get;
			set;
		}

		private void Awake()
		{
			instance = this;
		}

		public void Launch()
		{
			ReadConfigs();
			if (CheckUpdateReport())
			{
				UpdateClientOrStartGame();
			}
		}

		public static void RetryUpdate()
		{
			instance.UpdateClientOrStartGame();
		}

		private void UpdateClientOrStartGame()
		{
			if (new CommandLineParser(Environment.GetCommandLineArgs()).IsExist(LauncherConstants.NO_UPDATE_COMMAND))
			{
				StartGame();
			}
			else if (IsCurrentVersionNeedsUpdate())
			{
				StartClientDownload();
			}
			else
			{
				StartGame();
			}
		}

		private bool IsCurrentVersionNeedsUpdate()
		{
			if (remoteVersion == currentVersion)
			{
				return false;
			}
			if (string.IsNullOrEmpty(currentVersion) || string.IsNullOrEmpty(remoteVersion))
			{
				return true;
			}
			string text = (currentVersion.Contains("-compatible") ? currentVersion.Substring(0, currentVersion.IndexOf("-compatible", StringComparison.Ordinal)) : currentVersion);
			string text2 = (remoteVersion.Contains("-compatible") ? remoteVersion.Substring(0, remoteVersion.IndexOf("-compatible", StringComparison.Ordinal)) : remoteVersion);
			return text != text2;
		}

		private void ReadConfigs()
		{
			currentVersion = ConfigurationService.GetConfig(ConfigPath.STARTUP).GetStringValue("currentClientVersion");
			remoteVersion = UpdateConfiguration.Config.LastClientVersion;
			distributionUrl = UpdateConfiguration.Config.DistributionUrl;
			executable = UpdateConfiguration.Config.Executable;
		}

		private bool CheckUpdateReport()
		{
			CommandLineParser commandLineParser = new CommandLineParser(Environment.GetCommandLineArgs());
			if (!commandLineParser.IsExist(LauncherConstants.UPDATE_REPORT_COMMAND))
			{
				return true;
			}
			UpdateReport updateReport = new UpdateReport();
			string arg = string.Empty;
			string empty = string.Empty;
			bool flag;
			try
			{
				using (FileStream stream = new FileStream(ApplicationUtils.GetAppRootPath() + "/" + LauncherConstants.REPORT_FILE_NAME, FileMode.Open))
				{
					updateReport.Read(stream);
					flag = updateReport.IsSuccess;
					arg = updateReport.Error + updateReport.StackTrace;
					empty = updateReport.UpdateVersion;
				}
			}
			catch (Exception ex)
			{
				flag = false;
				arg = ex.ToString();
			}
			if (!flag)
			{
				LoggerProvider.GetLogger(this).ErrorFormat("ClientUpdateError: {0}", arg);
				EngineService.Engine.NewEvent<ClientUpdateErrorEvent>().Schedule();
				return false;
			}
			if (IsCurrentVersionNeedsUpdate())
			{
				LoggerProvider.GetLogger(this).ErrorFormat("ClientUpdateError: Updated version is not correct, update version = {0}, currentVersion = {1}", updateReport.UpdateVersion, currentVersion);
				EngineService.Engine.NewEvent<ClientUpdateErrorEvent>().Schedule();
				return false;
			}
			return true;
		}

		private void StartClientDownload()
		{
			downloadScreen.SetActive(true);
			ClientDownloadBehaviour component = downloadScreen.GetComponent<ClientDownloadBehaviour>();
			component.Init(remoteVersion, distributionUrl, executable);
		}

		private void StartGame()
		{
			Entity entity = EngineService.Engine.CreateEntity("StartGame");
			SceneSwitcher.CleanAndSwitch(SceneNames.ENTRANCE);
			InitConfigurationActivator.LauncherPassed = true;
		}
	}
}
