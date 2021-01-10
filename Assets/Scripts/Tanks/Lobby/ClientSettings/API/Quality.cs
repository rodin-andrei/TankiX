namespace Tanks.Lobby.ClientSettings.API
{
	public class Quality
	{
		public enum QualityLevel
		{
			Fastest = 0,
			Minimum = 1,
			Meduim = 2,
			High = 3,
			Maximum = 4,
			Ultra = 5,
		}

		public Quality(string name, int level)
		{
		}

	}
}
