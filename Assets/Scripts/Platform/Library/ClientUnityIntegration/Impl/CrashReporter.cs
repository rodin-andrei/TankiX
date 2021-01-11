using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using log4net;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientLogger.API;
using UnityEngine;

namespace Platform.Library.ClientUnityIntegration.Impl
{
	public class CrashReporter : DefaultActivator<AutoCompleting>
	{
		private const string OUTPUT_LOG_FILENAME = "output_log.txt";

		private const string ERROR_LOG_FILENAME = "error.log";

		private const string CRASH_DUMP_FILENAME = "crash.dmp";

		private const string REPORTED_FILENAME = "ReportedToServer.txt";

		private static ILog log;

		protected override void Activate()
		{
			SendCrashReports();
		}

		public static void SendCrashReports()
		{
			List<string> crashReportDirs = GetCrashReportDirs();
			foreach (string item in crashReportDirs)
			{
				ProcessDirectory(item);
			}
		}

		private static void ProcessDirectory(string dir)
		{
			try
			{
				GetLog().InfoFormat("Processing {0}", dir);
				string dirWithSeparator = dir + Path.DirectorySeparatorChar;
				DateTime parsedDate;
				if (!IsNameFormattedWithDate(dir, out parsedDate))
				{
					GetLog().InfoFormat("Skip IsNameFormattedWithDate {0}", dir);
				}
				else if (IsOutdated(parsedDate))
				{
					GetLog().InfoFormat("Skip IsOutdated {0}", dir);
				}
				else if (!ContainsCrashReportFiles(dirWithSeparator))
				{
					GetLog().InfoFormat("Skip ContainsCrashReportFiles {0}", dir);
				}
				else if (ContainsReportedFile(dirWithSeparator))
				{
					GetLog().InfoFormat("Skip ContainsReportedFile {0}", dir);
				}
				else
				{
					Report(dirWithSeparator, parsedDate);
				}
			}
			catch (IOException arg)
			{
				GetLog().WarnFormat("ProcessDirectory {0}", arg);
			}
		}

		private static List<string> GetCrashReportDirs()
		{
			string path = Application.dataPath + "/..";
			try
			{
				return new List<string>(Directory.GetDirectories(path, "????-??-??_??????", SearchOption.TopDirectoryOnly));
			}
			catch (IOException arg)
			{
				GetLog().WarnFormat("GetCrashReportDirs {0}", arg);
				return new List<string>();
			}
		}

		private static bool IsNameFormattedWithDate(string dir, out DateTime parsedDate)
		{
			return DateTime.TryParseExact(new FileInfo(dir).Name, new string[1]
			{
				"yyyy-MM-dd_HHmmss"
			}, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
		}

		private static bool IsOutdated(DateTime dateTime)
		{
			return (DateTime.Now - dateTime).TotalDays >= 7.0;
		}

		private static bool ContainsCrashReportFiles(string dirWithSeparator)
		{
			return File.Exists(dirWithSeparator + "output_log.txt") && File.Exists(dirWithSeparator + "error.log") && File.Exists(dirWithSeparator + "crash.dmp");
		}

		private static bool ContainsReportedFile(string dirWithSeparator)
		{
			return File.Exists(dirWithSeparator + "ReportedToServer.txt");
		}

		private static void Report(string dirWithSeparator, DateTime date)
		{
			string arg = File.ReadAllText(dirWithSeparator + "output_log.txt", new UTF8Encoding(false, false));
			GetLog().ErrorFormat("CrashReport {0:yyyy-MM-dd HH:mm:ss} UTC\n{1}", date.ToUniversalTime(), arg);
			File.Create(dirWithSeparator + "ReportedToServer.txt");
		}

		private static ILog GetLog()
		{
			if (log == null)
			{
				log = LoggerProvider.GetLogger(typeof(CrashReporter));
			}
			return log;
		}
	}
}
