using System.IO;
using log4net.Util;
using UnityEngine;

namespace Platform.Tool.ClientUnityLogger.API
{
	public class DeviceModelConverter : PatternConverter
	{
		public const string KEY = "deviceModel";

		protected override void Convert(TextWriter writer, object state)
		{
			writer.Write(UnityEngine.SystemInfo.deviceModel);
		}
	}
}
