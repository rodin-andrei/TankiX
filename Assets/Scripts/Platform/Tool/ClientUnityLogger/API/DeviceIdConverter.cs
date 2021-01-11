using System.IO;
using log4net.Util;
using UnityEngine;

namespace Platform.Tool.ClientUnityLogger.API
{
	public class DeviceIdConverter : PatternConverter
	{
		public const string KEY = "deviceId";

		protected override void Convert(TextWriter writer, object state)
		{
			writer.Write(UnityEngine.SystemInfo.deviceUniqueIdentifier);
		}
	}
}
