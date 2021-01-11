using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Tanks.Lobby.ClientBattleSelect.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientGarage.Impl;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class UserEquipmentSystem : ECSSystem
	{
		public class UserInMatchMakingLobby : Node
		{
			public UserComponent user;

			public SelfUserComponent selfUser;

			public BattleLobbyGroupComponent battleLobbyGroup;
		}

		public class UserInMatchMakingLobbyPrototype : UserInMatchMakingLobby
		{
			public InitUserEquipmentComponent initUserEquipment;

			public UserUseItemsPrototypeComponent userUseItemsPrototype;
		}

		public class Weapon : Node
		{
			public WeaponItemComponent weaponItem;

			public MountedItemComponent mountedItem;

			public MarketItemGroupComponent marketItemGroup;
		}

		public class Hull : Node
		{
			public TankItemComponent tankItem;

			public MountedItemComponent mountedItem;

			public MarketItemGroupComponent marketItemGroup;
		}

		public class InitUserEquipmentComponent : Component
		{
		}

		[OnEventFire]
		public void sendUserEquipmentOnEnterLobby(NodeAddedEvent e, UserInMatchMakingLobby user, [Context][JoinByUser] Weapon weapon, [Context][JoinByUser] Hull hull, [JoinByUser] UserInMatchMakingLobby user2Lobby, [JoinByBattleLobby] SingleNode<BattleLobbyComponent> lobby)
		{
			SetEquipmentEvent setEquipmentEvent = new SetEquipmentEvent();
			setEquipmentEvent.WeaponId = weapon.marketItemGroup.Key;
			setEquipmentEvent.HullId = hull.marketItemGroup.Key;
			ScheduleEvent(setEquipmentEvent, lobby);
			user.Entity.RemoveComponentIfPresent<InitUserEquipmentComponent>();
			user.Entity.AddComponent<InitUserEquipmentComponent>();
		}

		[OnEventFire]
		public void sendUserEquipmentOnEnterLobby(NodeAddedEvent e, UserInMatchMakingLobbyPrototype user, [Context][JoinByUser] Weapon weapon, [Context][JoinByUser] Hull hull, [JoinByUser] UserInMatchMakingLobby user2Lobby, [JoinByBattleLobby] SingleNode<BattleLobbyComponent> lobby)
		{
			SetEquipmentEvent setEquipmentEvent = new SetEquipmentEvent();
			if (user.userUseItemsPrototype.Preset.HasComponent<PresetEquipmentComponent>())
			{
				PresetEquipmentComponent component = user.userUseItemsPrototype.Preset.GetComponent<PresetEquipmentComponent>();
				setEquipmentEvent.WeaponId = Flow.Current.EntityRegistry.GetEntity(component.WeaponId).GetComponent<MarketItemGroupComponent>().Key;
				setEquipmentEvent.HullId = Flow.Current.EntityRegistry.GetEntity(component.HullId).GetComponent<MarketItemGroupComponent>().Key;
				ScheduleEvent(setEquipmentEvent, lobby);
			}
		}
	}
}
