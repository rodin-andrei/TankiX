using System;
using UnityEngine;

namespace Tanks.Lobby.ClientSettings.API
{
	public class Quality
	{
		public enum QualityLevel
		{
			Fastest,
			Minimum,
			Meduim,
			High,
			Maximum,
			Ultra
		}

		private readonly string name;

		private readonly int level;

		public static Quality fastest = new Quality("Fastest", 0);

		public static Quality ultra = new Quality("Ultra", 5);

		public static Quality high = new Quality("High", 3);

		public static Quality maximum = new Quality("Maximum", 4);

		public static Quality medium = new Quality("Medium", 2);

		public static Quality mininum = new Quality("Minimum", 1);

		private static readonly Quality[] qualities = new Quality[6]
		{
			fastest,
			mininum,
			medium,
			high,
			maximum,
			ultra
		};

		public string Name
		{
			get
			{
				return name;
			}
		}

		public int Level
		{
			get
			{
				return level;
			}
		}

		public Quality(string name, int level)
		{
			this.name = name;
			this.level = level;
		}

		public static void ValidateQualities()
		{
			for (int i = 0; i < QualitySettings.names.Length; i++)
			{
				for (int j = 0; j < qualities.Length; j++)
				{
					Quality quality = qualities[i];
					if (!quality.Name.Equals(QualitySettings.names[i]) || i != quality.Level)
					{
						throw new Exception(string.Format("There is no quality {0} with level {1}", quality.Name, quality.Level));
					}
				}
			}
		}

		public static Quality GetQualityByName(string qualityName)
		{
			qualityName = qualityName.ToLower();
			for (int i = 0; i < qualities.Length; i++)
			{
				Quality quality = qualities[i];
				if (quality.Name.ToLower().Equals(qualityName))
				{
					return quality;
				}
			}
			throw new ArgumentException("Quality with name " + qualityName + " was not found.");
		}
	}
}
