using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientGraphics.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class MuzzleFlashSystem : ECSSystem
	{
		public class MuzzlePointNode : Node
		{
			public MuzzlePointComponent muzzlePoint;
		}

		public class MuzzleFlashNode : MuzzlePointNode
		{
			public MuzzleFlashComponent muzzleFlash;

			public WeaponUnblockedComponent weaponUnblocked;
		}

		public class ShaftMuzzleFlashNode : MuzzlePointNode
		{
			public ShaftMuzzleFlashComponent shaftMuzzleFlash;

			public WeaponUnblockedComponent weaponUnblocked;
		}

		[OnEventFire]
		public void CreateMuzzleFlash(BaseShotEvent evt, MuzzleFlashNode muzzle)
		{
			InstantiateMuzzleEffect(muzzle.muzzleFlash.muzzleFlashPrefab, muzzle, muzzle.muzzleFlash.duration);
		}

		[OnEventFire]
		public void CreateShaftMuzzleFlashOnAnyRemoteShot(RemoteShotEvent evt, ShaftMuzzleFlashNode muzzle)
		{
			InstantiateMuzzleEffect(muzzle.shaftMuzzleFlash.muzzleFlashPrefab, muzzle, muzzle.shaftMuzzleFlash.duration);
		}

		[OnEventFire]
		public void CreateShaftMuzzleFlashOnSelfQuickShot(ShotPrepareEvent evt, ShaftMuzzleFlashNode muzzle)
		{
			InstantiateMuzzleEffect(muzzle.shaftMuzzleFlash.muzzleFlashPrefab, muzzle, muzzle.shaftMuzzleFlash.duration);
		}

		private void InstantiateMuzzleEffect(GameObject prefab, MuzzlePointNode muzzlePointNode, float duration)
		{
			GetInstanceFromPoolEvent getInstanceFromPoolEvent = new GetInstanceFromPoolEvent();
			getInstanceFromPoolEvent.Prefab = prefab;
			getInstanceFromPoolEvent.AutoRecycleTime = duration;
			GetInstanceFromPoolEvent getInstanceFromPoolEvent2 = getInstanceFromPoolEvent;
			ScheduleEvent(getInstanceFromPoolEvent2, muzzlePointNode);
			Transform instance = getInstanceFromPoolEvent2.Instance;
			GameObject gameObject = instance.gameObject;
			UnityUtil.InheritAndEmplace(gameObject.transform, muzzlePointNode.muzzlePoint.Current);
			CustomRenderQueue.SetQueue(gameObject, 3150);
			gameObject.gameObject.SetActive(true);
		}
	}
}
