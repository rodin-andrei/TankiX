using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientDataStructures.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using Tanks.Lobby.ClientEntrance.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ParticleSystemEffectsSystem : ECSSystem
	{
		public class TankActiveStateNode : Node
		{
			public TankGroupComponent tankGroup;

			public TankActiveStateComponent tankActiveState;
		}

		public class TankDeadStateNode : Node
		{
			public TankGroupComponent tankGroup;

			public TankDeadStateComponent tankDeadState;
		}

		public class TankParticleNode : Node
		{
			public TankGroupComponent tankGroup;

			public ParticleSystemEffectsComponent particleSystemEffects;
		}

		public class TankWithParticleActiveStateNode : TankParticleNode
		{
			public TankActiveStateComponent tankActiveState;
		}

		public class TankWithParticleDeadStateNode : TankParticleNode
		{
			public TankDeadStateComponent tankDeadState;
		}

		public class ShaftAimingWorkingStateNode : Node
		{
			public ShaftAimingWorkingStateComponent shaftAimingWorkingState;

			public ShaftAimingAnimationReadyComponent shaftAimingAnimationReady;

			public SelfComponent self;
		}

		public class SkinParticleNode : Node
		{
			public TankGroupComponent tankGroup;

			public SkinParticleSystemEffectsComponent skinParticleSystemEffects;
		}

		[OnEventFire]
		public void TankActive(NodeAddedEvent e, TankWithParticleActiveStateNode tankActiveStateNode)
		{
			tankActiveStateNode.particleSystemEffects.StartEmission();
		}

		[OnEventFire]
		public void TankDead(NodeAddedEvent e, TankWithParticleDeadStateNode tankDeadStateNode)
		{
			tankDeadStateNode.particleSystemEffects.StopEmission();
		}

		[OnEventFire]
		public void TankVisible(DeactivateTankInvisibilityEffectEvent e, TankParticleNode tankWithEffectNode)
		{
			tankWithEffectNode.particleSystemEffects.StartEmission();
		}

		[OnEventFire]
		public void TankInvisible(ActivateTankInvisibilityEffectEvent e, TankParticleNode tankWithEffectNode)
		{
			tankWithEffectNode.particleSystemEffects.StopEmission();
		}

		[OnEventFire]
		public void StartAiming(NodeAddedEvent evt, ShaftAimingWorkingStateNode weapon, [Combine] TankParticleNode tankWithEffectNode)
		{
			tankWithEffectNode.particleSystemEffects.StopEmission();
		}

		[OnEventFire]
		public void StopAiming(NodeRemoveEvent evt, ShaftAimingWorkingStateNode weapon, [Combine] TankParticleNode tankWithEffectNode)
		{
			tankWithEffectNode.particleSystemEffects.StartEmission();
		}

		[OnEventFire]
		public void TankActive(NodeAddedEvent e, TankActiveStateNode tankActiveStateNode, [JoinByTank] ICollection<SkinParticleNode> skins)
		{
			skins.ForEach(delegate(SkinParticleNode skin)
			{
				skin.skinParticleSystemEffects.StartEmission();
			});
		}

		[OnEventFire]
		public void TankDead(NodeAddedEvent e, TankDeadStateNode tankDeadStateNode, [JoinByTank] ICollection<SkinParticleNode> skins)
		{
			skins.ForEach(delegate(SkinParticleNode skin)
			{
				skin.skinParticleSystemEffects.StopEmission();
			});
		}

		[OnEventFire]
		public void TankVisible(DeactivateTankInvisibilityEffectEvent e, TankActiveStateNode tank, [JoinByTank] ICollection<SkinParticleNode> skins)
		{
			skins.ForEach(delegate(SkinParticleNode skin)
			{
				skin.skinParticleSystemEffects.StartEmission();
			});
		}

		[OnEventFire]
		public void TankInvisible(ActivateTankInvisibilityEffectEvent e, TankActiveStateNode tank, [JoinByTank] ICollection<SkinParticleNode> skins)
		{
			skins.ForEach(delegate(SkinParticleNode skin)
			{
				skin.skinParticleSystemEffects.StopEmission();
			});
		}

		[OnEventFire]
		public void StartAiming(NodeAddedEvent evt, ShaftAimingWorkingStateNode weapon, [JoinByTank] ICollection<SkinParticleNode> skins)
		{
			skins.ForEach(delegate(SkinParticleNode skin)
			{
				skin.skinParticleSystemEffects.StopEmission();
			});
		}

		[OnEventFire]
		public void StopAiming(NodeRemoveEvent evt, ShaftAimingWorkingStateNode weapon, [JoinByTank] ICollection<SkinParticleNode> skins)
		{
			skins.ForEach(delegate(SkinParticleNode skin)
			{
				skin.skinParticleSystemEffects.StartEmission();
			});
		}
	}
}
