using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientGarage.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class PremiumMoneyBonusSystem : ECSSystem
	{
		public class MoneyBonusNode : Node
		{
			public UserGroupComponent userGroup;

			public MoneyBonusComponent moneyBonus;
		}

		[OnEventFire]
		public void RegisterBonus(NodeAddedEvent e, MoneyBonusNode bonus)
		{
		}
	}
}
