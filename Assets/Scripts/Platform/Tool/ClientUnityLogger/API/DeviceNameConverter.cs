using System.IO;
using log4net.Util;
using UnityEngine;

namespace Platform.Tool.ClientUnityLogger.API
{
	public class DeviceNameConverter : PatternConverter
	{
		public const string KEY = "deviceName";

		protected override void Convert(TextWriter writer, object state)
		{
			writer.Write(UnityEngine.SystemInfo.deviceName);
		}
	}
}
