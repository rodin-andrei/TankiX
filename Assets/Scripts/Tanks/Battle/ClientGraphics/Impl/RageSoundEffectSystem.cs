using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class RageSoundEffectSystem : ECSSystem
	{
		public class SelfTankNode : Node
		{
			public SelfTankComponent selfTank;

			public AssembledTankActivatedStateComponent assembledTankActivatedState;

			public RageSoundEffectComponent rageSoundEffect;
		}

		[OnEventFire]
		public void PlayRageEffect(TriggerEffectExecuteEvent e, SingleNode<RageEffectComponent> effect, [JoinByTank] SelfTankNode tank, [JoinByTank] ICollection<SingleNode<InventoryCooldownStateComponent>> inventorySlots)
		{
			if (inventorySlots.Count != 0)
			{
				RageSoundEffectBehaviour.CreateRageSound(tank.rageSoundEffect.Asset);
			}
		}
	}
}
