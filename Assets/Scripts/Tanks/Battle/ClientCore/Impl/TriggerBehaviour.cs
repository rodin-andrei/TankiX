using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public abstract class TriggerBehaviour<T> : ECSBehaviour where T : Platform.Kernel.ECS.ClientEntitySystem.API.Event, new()
	{
		private GameObject collisionGameObject;

		public Entity TriggerEntity
		{
			get;
			set;
		}

		protected void SendEventByCollision(Collider other)
		{
			collisionGameObject = other.gameObject;
			SendEvent();
		}

		private void SendEvent()
		{
			TargetBehaviour componentInParent = collisionGameObject.GetComponentInParent<TargetBehaviour>();
			if ((bool)componentInParent)
			{
				NewEvent<T>().Attach(TriggerEntity).Attach(componentInParent.TargetEntity).Schedule();
			}
		}
	}
}
