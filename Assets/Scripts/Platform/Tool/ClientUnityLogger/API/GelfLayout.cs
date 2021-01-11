using System;
using System.Collections.Generic;
using System.Text;
using log4net.Layout;

namespace Platform.Tool.ClientUnityLogger.API
{
	public class GelfLayout : PatternLayout
	{
		private const string GELF_VERSION = "1.1";

		private Dictionary<string, string> gelfLayoutPrototype = new Dictionary<string, string>
		{
			{
				"version",
				"1.1"
			},
			{
				"host",
				Environment.MachineName
			},
			{
				"short_message",
				"%escapedMessage"
			},
			{
				"level",
				"%syslogLevel"
			},
			{
				"_exception",
				"%escapedException"
			},
			{
				"_device_id",
				"%deviceId"
			},
			{
				"_ecs_session_id",
				"%ECSSessionId"
			},
			{
				"_user",
				"%UserUID"
			},
			{
				"_client_version",
				"%ClientVersion"
			},
			{
				"_server_url",
				"%InitUrl"
			}
		};

		public GelfLayout()
		{
			base.ConversionPattern = GetLayoutPattern();
			AddConverter("escapedMessage", typeof(MessageEscapeConvertor));
			AddConverter("syslogLevel", typeof(SyslogLevelConverter));
			AddConverter("escapedException", typeof(ExceptionEscapeConverter));
			AddConverter("deviceId", typeof(DeviceIdConverter));
			AddConverter("ECSSessionId", typeof(ECSSessionIdConverter));
			AddConverter("UserUID", typeof(UserUIDConverter));
			AddConverter("ClientVersion", typeof(ClientVersionConverter));
			AddConverter("InitUrl", typeof(ServerUrlConverter));
			AddConverter("deviceModel", typeof(DeviceModelConverter));
			AddConverter("deviceName", typeof(DeviceNameConverter));
			AddConverter("buildGUID", typeof(BuildGuidConverter));
			AddConverter("operatingSystem", typeof(OperatingSystemConverter));
			ActivateOptions();
		}

		private string GetLayoutPattern()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{").AppendLine();
			foreach (KeyValuePair<string, string> item in gelfLayoutPrototype)
			{
				stringBuilder.AppendFormat("\"{0}\": \"{1}\",\n", item.Key, item.Value);
			}
			stringBuilder.Remove(stringBuilder.Length - 2, 1);
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}
	}
}
