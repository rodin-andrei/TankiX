using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public static class TeamColorExtensions
	{
		public static TeamColor GetOposite(this TeamColor color)
		{
			switch (color)
			{
			case TeamColor.BLUE:
				return TeamColor.RED;
			case TeamColor.RED:
				return TeamColor.BLUE;
			default:
				return GetRandom();
			}
		}

		private static TeamColor GetRandom()
		{
			return ((double)Random.value > 0.5) ? TeamColor.RED : TeamColor.BLUE;
		}
	}
}
