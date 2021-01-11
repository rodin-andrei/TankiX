using Lobby.ClientUserProfile.API;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using Tanks.Lobby.ClientGarage.API;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class RageHUDEffectSystem : ECSSystem
	{
		public class TankNode : Node
		{
			public TankComponent tank;

			public AssembledTankActivatedStateComponent assembledTankActivatedState;

			public TankGroupComponent tankGroup;
		}

		[Not(typeof(EffectsFreeSlotComponent))]
		public class SlotCooldownStateNode : Node
		{
			public SlotUserItemInfoComponent slotUserItemInfo;

			public ModuleGroupComponent moduleGroup;

			public InventoryCooldownStateComponent inventoryCooldownState;
		}

		public class PlayRageHUDEffectEvent : Event
		{
		}

		[OnEventFire]
		public void PlayRageEffect(TriggerEffectExecuteEvent e, SingleNode<RageEffectComponent> effect, [JoinByTank] TankNode tank)
		{
			ScheduleEvent<PlayRageHUDEffectEvent>(tank);
		}

		[OnEventFire]
		public void PlayRageHUDEffect(PlayRageHUDEffectEvent e, TankNode tank, [JoinByUser][Combine] SlotCooldownStateNode slot, [JoinByModule] SingleNode<ItemButtonComponent> hud)
		{
			float cutTime = (float)slot.inventoryCooldownState.CooldownTime / 1000f - (Date.Now.UnityTime - slot.inventoryCooldownState.CooldownStartTime.UnityTime);
			hud.component.CutCooldown(cutTime);
		}
	}
}
