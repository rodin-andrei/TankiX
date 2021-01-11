using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Platform.Library.ClientDataStructures.API;
using Platform.Library.ClientResources.API;
using Tanks.ClientLauncher.API;
using UnityEngine;

namespace Tanks.ClientLauncher.Impl
{
	public static class ClientUpdater
	{
		private static readonly int PROCESS_STOP_TIMEOUT = 15000;

		private static readonly int FILE_WAIT_TIMEOUT = 80000;

		private static readonly int FILE_WAIT_BEFORE_KILL_CONCURRENT_PROCESS = 10000;

		public static bool IsApplicationRunInUpdateMode()
		{
			CommandLineParser commandLineParser = new CommandLineParser(Environment.GetCommandLineArgs());
			string paramValue;
			if (commandLineParser.TryGetValue(LauncherConstants.UPDATE_PROCESS_COMMAND, out paramValue))
			{
				return true;
			}
			return false;
		}

		public static bool IsUpdaterRunning()
		{
			string appRootPath = ApplicationUtils.GetAppRootPath();
			string path = appRootPath + "/update.lock";
			if (!File.Exists(path))
			{
				return false;
			}
			try
			{
				using (File.Open(path, FileMode.Open, FileAccess.Read))
				{
				}
			}
			catch (Exception)
			{
				return true;
			}
			return false;
		}

		public static void Update()
		{
			UpdateReport updateReport = new UpdateReport();
			FileBackupTransaction fileBackupTransaction = new FileBackupTransaction();
			string path = null;
			string text = null;
			string updateVersion = "unknown";
			string text2 = null;
			try
			{
				string appRootPath = ApplicationUtils.GetAppRootPath();
				CommandLineParser commandLineParser = new CommandLineParser(Environment.GetCommandLineArgs());
				int value = Convert.ToInt32(commandLineParser.GetValue(LauncherConstants.UPDATE_PROCESS_COMMAND));
				text = commandLineParser.GetValue(LauncherConstants.PARENT_PATH_COMMAND);
				updateVersion = commandLineParser.GetValue(LauncherConstants.VERSION_COMMAND);
				text2 = text + "/update.lock";
				using (File.Open(text2, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
				{
					string processName = Process.GetCurrentProcess().ProcessName;
					path = text + "/" + ApplicationUtils.GetExecutableRelativePathByName(processName);
					WaitForProccessStop(Convert.ToInt32(value), PROCESS_STOP_TIMEOUT);
					WaitForDropParentExecutable(fileBackupTransaction, path);
					ReplaceProjectFiles(fileBackupTransaction, appRootPath, text, processName);
					fileBackupTransaction.Commit();
				}
			}
			catch (Exception ex)
			{
				updateReport.IsSuccess = false;
				updateReport.Error = ex.Message;
				updateReport.StackTrace = ex.StackTrace;
				fileBackupTransaction.Rollback();
			}
			finally
			{
				try
				{
					updateReport.UpdateVersion = updateVersion;
					WriteReport(text + "/" + LauncherConstants.REPORT_FILE_NAME, updateReport);
					if (!string.IsNullOrEmpty(text2) && File.Exists(text2))
					{
						File.Delete(text2);
					}
					ApplicationUtils.StartProcess(path, LauncherConstants.UPDATE_REPORT_COMMAND);
				}
				finally
				{
					Application.Quit();
				}
			}
		}

		private static void WriteReport(string path, UpdateReport report)
		{
			try
			{
				using (FileStream stream = new FileStream(path, FileMode.Create))
				{
					report.Write(stream);
				}
			}
			catch (Exception message)
			{
				UnityEngine.Debug.LogError(message);
			}
		}

		private static bool WaitForProccessStop(int parentProcessId, int timeout)
		{
			Process processById;
			try
			{
				processById = Process.GetProcessById(parentProcessId);
			}
			catch (ArgumentException)
			{
				return true;
			}
			processById.WaitForExit(timeout);
			return processById.HasExited;
		}

		private static void WaitForDropParentExecutable(FileBackupTransaction transaction, string path)
		{
			if (!File.Exists(path))
			{
				return;
			}
			int num = 0;
			bool flag = false;
			bool flag2;
			do
			{
				flag2 = true;
				try
				{
					Console.WriteLine("Try drop executable file " + path);
					transaction.DeleteFile(path);
					Console.WriteLine("Executable file droped");
				}
				catch (Exception)
				{
					flag2 = false;
					if (num > FILE_WAIT_TIMEOUT)
					{
						throw;
					}
					if (num > FILE_WAIT_BEFORE_KILL_CONCURRENT_PROCESS && !flag)
					{
						flag = true;
						TryKillOtherTankixProcesses();
					}
					num += 1000;
					Thread.Sleep(1000);
				}
			}
			while (!flag2);
		}

		private static void TryKillOtherTankixProcesses()
		{
			try
			{
				Process currentProcess = Process.GetCurrentProcess();
				Process[] processesByName = Process.GetProcessesByName(currentProcess.ProcessName);
				foreach (Process process in processesByName)
				{
					if (currentProcess.Id != process.Id)
					{
						process.Kill();
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Kill process exception " + ex.Message);
			}
		}

		private static void ReplaceProjectFiles(FileBackupTransaction transaction, string from, string to, string executableWithoutExtension)
		{
			string[] files = Directory.GetFiles(from, "*", SearchOption.AllDirectories);
			List<Pair<string, string>> list = new List<Pair<string, string>>();
			List<Pair<string, string>> list2 = new List<Pair<string, string>>();
			string[] array = files;
			foreach (string text in array)
			{
				string text2 = text.Replace(from, to);
				if (Path.GetFileNameWithoutExtension(text2).Equals(executableWithoutExtension, StringComparison.OrdinalIgnoreCase))
				{
					list2.Add(new Pair<string, string>(text, text2));
				}
				else
				{
					list.Add(new Pair<string, string>(text, text2));
				}
			}
			foreach (Pair<string, string> item in list)
			{
				Console.WriteLine("Copy project file from " + item.Key + " to " + item.Value);
				transaction.ReplaceFile(item.Key, item.Value);
			}
			foreach (Pair<string, string> item2 in list2)
			{
				Console.WriteLine("Copy executable file from " + item2.Key + " to " + item2.Value);
				transaction.ReplaceFile(item2.Key, item2.Value);
			}
		}
	}
}
