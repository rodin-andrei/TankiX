using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using log4net;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientLogger.API;
using Platform.Library.ClientResources.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientControls.API;
using Tanks.ClientLauncher.API;
using UnityEngine;

namespace Tanks.ClientLauncher.Impl
{
	public class ClientDownloadBehaviour : MonoBehaviour
	{
		private string version;

		private string url;

		private string executable;

		private string updatePath;

		private ProgressBarComponent progressBar;

		private WWWLoader www;

		[Inject]
		public static EngineServiceInternal EngineService
		{
			get;
			set;
		}

		public void Init(string version, string url, string executable)
		{
			updatePath = Path.GetTempPath() + "/" + LauncherConstants.UPDATE_PATH;
			this.url = url;
			this.version = version;
			this.executable = executable;
		}

		private void Start()
		{
			StartCoroutine(WaitAndStartDownLoad(0.5f));
		}

		private IEnumerator WaitAndStartDownLoad(float waitTime)
		{
			yield return new WaitForSeconds(waitTime);
			EngineService.Engine.NewEvent<StartDownloadEvent>().Attach(EngineService.EntityStub).Schedule();
			progressBar = GetComponentInChildren<ProgressBarComponent>();
			progressBar.ProgressValue = 0f;
			www = new WWWLoader(new WWW(url));
		}

		private void Update()
		{
			if (www != null)
			{
				progressBar.ProgressValue = www.Progress;
				if (www.IsDone)
				{
					progressBar.ProgressValue = 1f;
					CompleteDownloading();
					www.Dispose();
					www = null;
				}
			}
		}

		private void CompleteDownloading()
		{
			if (string.IsNullOrEmpty(www.Error))
			{
				try
				{
					ExtractFiles();
					Reboot();
				}
				catch (Exception ex)
				{
					Log(ex.Message, ex);
					SendErrorEvent();
				}
			}
			else
			{
				base.enabled = false;
				Log(string.Format("Loading failed. URL: {0}, Error: {1}", www.URL, www.Error), null);
				SendErrorEvent();
			}
		}

		private void ExtractFiles()
		{
			try
			{
				if (Directory.Exists(updatePath))
				{
					FileUtils.DeleteDirectory(updatePath);
				}
			}
			catch (Exception)
			{
				updatePath += "_alt";
			}
			try
			{
				if (Directory.Exists(updatePath))
				{
					FileUtils.DeleteDirectory(updatePath);
				}
			}
			catch (Exception ex2)
			{
				Log(ex2.Message, ex2);
			}
			using (MemoryStream stream = new MemoryStream(www.Bytes))
			{
				TarUtility.Extract(stream, updatePath);
			}
		}

		private void Reboot()
		{
			EngineService.Engine.NewEvent<StartRebootEvent>().Attach(EngineService.EntityStub).Schedule();
			CommandLineParser commandLineParser = new CommandLineParser(Environment.GetCommandLineArgs());
			string appRootPath = ApplicationUtils.GetAppRootPath();
			string subLine = commandLineParser.GetSubLine(LauncherConstants.PASS_THROUGH);
			string args = string.Format("-batchmode -nographics {0}={1} {2}={3} {4}={5} {6}", LauncherConstants.UPDATE_PROCESS_COMMAND, Process.GetCurrentProcess().Id, LauncherConstants.VERSION_COMMAND, version, LauncherConstants.PARENT_PATH_COMMAND, ApplicationUtils.WrapPath(appRootPath), subLine);
			try
			{
				ApplicationUtils.StartProcessAsAdmin(updatePath + "/" + ApplicationUtils.GetExecutablePathByName(executable), args);
			}
			catch
			{
				ApplicationUtils.StartProcess(updatePath + "/" + ApplicationUtils.GetExecutablePathByName(executable), args);
			}
			StartCoroutine(WaitAndReboot(2f));
		}

		private IEnumerator WaitAndReboot(float waitTime)
		{
			yield return new WaitForSeconds(waitTime);
			Application.Quit();
			Process.GetCurrentProcess().Kill();
		}

		private void SendErrorEvent()
		{
			EngineService.Engine.NewEvent<ClientUpdateErrorEvent>().Schedule();
		}

		private void Log(string message, Exception e)
		{
			string message2 = "ClientUpdateError: " + message;
			ILog logger = LoggerProvider.GetLogger(this);
			if (e == null)
			{
				logger.Error(message2);
			}
			else
			{
				logger.Error(message2, e);
			}
		}
	}
}
