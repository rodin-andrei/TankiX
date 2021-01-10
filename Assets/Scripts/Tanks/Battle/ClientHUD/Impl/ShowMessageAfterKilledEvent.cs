using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class ShowMessageAfterKilledEvent : Event
	{
		public int killerRank;
		public TeamColor killerTeam;
		public long killerItem;
	}
}
