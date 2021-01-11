using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Battle.ClientCore.Impl
{
	[Shared]
	[SerialVersionUID(635890736905417870L)]
	public class BattleInfoForLabelLoadedEvent : Event
	{
		private Entity map;

		private long battleId;

		private string battleMode;

		public Entity Map
		{
			get
			{
				return map;
			}
			set
			{
				map = value;
			}
		}

		public long BattleId
		{
			get
			{
				return battleId;
			}
			set
			{
				battleId = value;
			}
		}

		public string BattleMode
		{
			get
			{
				return battleMode;
			}
			set
			{
				battleMode = value;
			}
		}
	}
}
