using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class HolyshieldSoundEffectSystem : ECSSystem
	{
		public class InitTankNode : Node
		{
			public TankComponent tank;

			public AssembledTankActivatedStateComponent assembledTankActivatedState;

			public HolyshieldSoundEffectAssetComponent holyshieldSoundEffectAsset;

			public TankSoundRootComponent tankSoundRoot;

			public TankGroupComponent tankGroup;
		}

		public class ReadyTankNode : InitTankNode
		{
			public HolyshieldSoundEffectInstanceComponent holyshieldSoundEffectInstance;
		}

		public class HolyshieldEffectNode : Node
		{
			public InvulnerabilityEffectComponent invulnerabilityEffect;

			public HolyshieldEffectComponent holyshieldEffect;

			public TankGroupComponent tankGroup;
		}

		[OnEventFire]
		public void CreateHolyshieldSound(NodeAddedEvent e, InitTankNode tank)
		{
			Transform soundRootTransform = tank.tankSoundRoot.SoundRootTransform;
			SoundController instance = Object.Instantiate(tank.holyshieldSoundEffectAsset.Asset, soundRootTransform.position, soundRootTransform.rotation, soundRootTransform);
			tank.Entity.AddComponent(new HolyshieldSoundEffectInstanceComponent(instance));
		}

		[OnEventFire]
		public void Play(NodeAddedEvent e, HolyshieldEffectNode effect, [JoinByTank][Context] ReadyTankNode tank)
		{
			tank.holyshieldSoundEffectInstance.Instance.FadeIn();
		}

		[OnEventFire]
		public void Stop(NodeRemoveEvent e, HolyshieldEffectNode effect, [JoinByTank] ReadyTankNode tank)
		{
			tank.holyshieldSoundEffectInstance.Instance.FadeOut();
		}
	}
}
