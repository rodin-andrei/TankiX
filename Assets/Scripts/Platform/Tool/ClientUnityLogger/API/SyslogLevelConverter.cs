using System.Collections.Generic;
using System.IO;
using log4net.Core;
using log4net.Layout.Pattern;

namespace Platform.Tool.ClientUnityLogger.API
{
	public class SyslogLevelConverter : PatternLayoutConverter
	{
		private enum SyslogSeverity : byte
		{
			Emergency,
			Alert,
			Critical,
			Error,
			Warning,
			Notice,
			Informational,
			Debug
		}

		private Dictionary<Level, SyslogSeverity> log4net2SyslogLevelMap = new Dictionary<Level, SyslogSeverity>
		{
			{
				Level.Alert,
				SyslogSeverity.Alert
			},
			{
				Level.Critical,
				SyslogSeverity.Critical
			},
			{
				Level.Fatal,
				SyslogSeverity.Critical
			},
			{
				Level.Debug,
				SyslogSeverity.Debug
			},
			{
				Level.Emergency,
				SyslogSeverity.Emergency
			},
			{
				Level.Error,
				SyslogSeverity.Error
			},
			{
				Level.Info,
				SyslogSeverity.Informational
			},
			{
				Level.Off,
				SyslogSeverity.Informational
			},
			{
				Level.Notice,
				SyslogSeverity.Notice
			},
			{
				Level.Verbose,
				SyslogSeverity.Notice
			},
			{
				Level.Trace,
				SyslogSeverity.Notice
			},
			{
				Level.Severe,
				SyslogSeverity.Emergency
			},
			{
				Level.Warn,
				SyslogSeverity.Warning
			}
		};

		public const string KEY = "syslogLevel";

		protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
		{
			writer.Write(GetSyslogSeverity(loggingEvent.Level));
		}

		private byte GetSyslogSeverity(Level level)
		{
			SyslogSeverity value;
			if (log4net2SyslogLevelMap.TryGetValue(level, out value))
			{
				return (byte)value;
			}
			return 7;
		}
	}
}
