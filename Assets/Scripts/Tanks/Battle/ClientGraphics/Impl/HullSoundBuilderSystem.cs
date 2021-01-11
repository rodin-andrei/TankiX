using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class HullSoundBuilderSystem : ECSSystem
	{
		public class TankNode : Node
		{
			public TankVisualRootComponent tankVisualRoot;

			public TankCommonInstanceComponent tankCommonInstance;

			public TankDeathExplosionPrefabsComponent tankDeathExplosionPrefabs;

			public AssembledTankComponent assembledTank;
		}

		[OnEventFire]
		public void CreateCommonTankSounds(NodeAddedEvent evt, TankNode tank)
		{
			Transform soundRoot = CreateTankSoundRoot(tank);
			CreateTankExplosionSound(tank, soundRoot);
		}

		private void CreateTankExplosionSound(TankNode tank, Transform soundRoot)
		{
			GameObject soundPrefab = tank.tankDeathExplosionPrefabs.SoundPrefab;
			GameObject gameObject = Object.Instantiate(soundPrefab);
			Transform transform = gameObject.transform;
			Entity entity = tank.Entity;
			transform.SetParent(soundRoot);
			transform.localPosition = Vector3.zero;
			AudioSource component = gameObject.GetComponent<AudioSource>();
			entity.AddComponent(new TankExplosionSoundComponent(component));
		}

		private Transform CreateTankSoundRoot(TankNode tank)
		{
			Transform transform = tank.tankVisualRoot.transform;
			Transform transform2 = transform.gameObject.GetComponentsInChildren<TankSoundRootBehaviour>(true)[0].gameObject.transform;
			tank.Entity.AddComponent(new TankSoundRootComponent(transform2));
			return transform2;
		}
	}
}
