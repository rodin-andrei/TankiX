using System;
using System.Collections.Generic;
using System.Linq;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.System.Data.Statics.ClientConfigurator.API;
using Platform.System.Data.Statics.ClientYaml.API;
using Tanks.Lobby.ClientSettings.API;
using UnityEngine;

namespace Tanks.Lobby.ClientProfile.Impl
{
	public class TanksGraphicsSettingsAnalyzer : GraphicsSettingsAnalyzer
	{
		private const string SPACE = " ";

		private const string UNSUPPORTED_QUALITY_NAME = "Unsupported";

		[SerializeField]
		private string configPath;

		private Quality maxDefaultQuality = Quality.maximum;

		private Quality defaultQualityForUnknownDevice = Quality.maximum;

		private Quality minQuality = Quality.fastest;

		private bool unsupportedDevice;

		private Quality defaultQuality;

		[Inject]
		public static ConfigurationService Configuration
		{
			get;
			set;
		}

		public override void Init()
		{
			Dictionary<string, string> configData = GetConfigData();
			string text = PrepareDeviceName(SystemInfo.graphicsDeviceName);
			if (!configData.ContainsKey(text))
			{
				Console.WriteLine("Unknown device {0}! Default Quality Level = {1}", text, defaultQualityForUnknownDevice.Name);
				defaultQuality = defaultQualityForUnknownDevice;
				return;
			}
			string text2 = configData[text];
			if (text2.Equals("Unsupported"))
			{
				unsupportedDevice = true;
				defaultQuality = minQuality;
				Console.WriteLine("Unsupported device! Default Quality Level = " + minQuality.Name);
			}
			else
			{
				Quality qualityByName = Quality.GetQualityByName(text2);
				defaultQuality = ((qualityByName.Level <= maxDefaultQuality.Level) ? qualityByName : maxDefaultQuality);
			}
		}

		public override Quality GetDefaultQuality()
		{
			return defaultQuality;
		}

		public override Resolution GetDefaultResolution(List<Resolution> resolutions)
		{
			Func<Resolution, int> keySelector = (Resolution r) => r.width + r.height;
			return (!unsupportedDevice) ? resolutions.OrderByDescending(keySelector).First() : resolutions.OrderBy(keySelector).First();
		}

		private Dictionary<string, string> GetConfigData()
		{
			YamlNode config = Configuration.GetConfig(configPath);
			Dictionary<string, string> source = config.ConvertTo<Dictionary<string, string>>();
			return source.ToDictionary((KeyValuePair<string, string> k) => PrepareDeviceName(k.Key), (KeyValuePair<string, string> k) => k.Value);
		}

		private static string PrepareDeviceName(string currentDeviceName)
		{
			return currentDeviceName.Replace(" ", string.Empty).Trim().ToUpperInvariant();
		}
	}
}
