using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Lobby.ClientBattleSelect.API;
using Tanks.Lobby.ClientGarage.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class RoundUserEquipmentSystem : ECSSystem
	{
		public class RoundUserNode : Node
		{
			public RoundUserComponent roundUser;

			public UserGroupComponent userGroup;
		}

		public class HullNode : Node
		{
			public UserGroupComponent userGroup;

			public TankComponent tank;

			public MarketItemGroupComponent marketItemGroup;

			public TankPartComponent tankPart;
		}

		public class TurretNode : Node
		{
			public UserGroupComponent userGroup;

			public WeaponComponent weapon;

			public MarketItemGroupComponent marketItemGroup;

			public TankPartComponent tankPart;
		}

		[OnEventFire]
		public void SaveEquipment(NodeAddedEvent e, [Combine] RoundUserNode user, [Context][JoinByUser] HullNode hull, [Context][JoinByUser] TurretNode turret)
		{
			if (user.Entity.HasComponent<RoundUserEquipmentComponent>())
			{
				RoundUserEquipmentComponent component = user.Entity.GetComponent<RoundUserEquipmentComponent>();
				component.HullId = hull.marketItemGroup.Key;
				component.WeaponId = turret.marketItemGroup.Key;
			}
			else
			{
				RoundUserEquipmentComponent roundUserEquipmentComponent = new RoundUserEquipmentComponent();
				roundUserEquipmentComponent.HullId = hull.marketItemGroup.Key;
				roundUserEquipmentComponent.WeaponId = turret.marketItemGroup.Key;
				RoundUserEquipmentComponent component2 = roundUserEquipmentComponent;
				user.Entity.AddComponent(component2);
			}
		}
	}
}
