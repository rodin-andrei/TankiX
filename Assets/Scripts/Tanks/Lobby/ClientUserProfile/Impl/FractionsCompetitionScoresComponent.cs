using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class FractionsCompetitionScoresComponent : Component
	{
		public long TotalCryFund;

		public Dictionary<long, long> Scores;
	}
}
