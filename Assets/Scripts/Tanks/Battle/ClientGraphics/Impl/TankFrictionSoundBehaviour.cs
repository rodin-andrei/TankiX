using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TankFrictionSoundBehaviour : ECSBehaviour
	{
		private Entity tankEntity;

		public bool TriggerStay
		{
			get;
			set;
		}

		public Collider FrictionCollider
		{
			get;
			set;
		}

		private void Awake()
		{
			base.enabled = false;
		}

		private void OnTriggerEnter(Collider other)
		{
			UpdateCollisionStay(other);
		}

		private void OnTriggerStay(Collider other)
		{
			UpdateCollisionStay(other);
		}

		private void OnTriggerExit(Collider other)
		{
			DisableCollisionStay();
			SendTankFrictionExitEvent();
		}

		private void SendTankFrictionExitEvent()
		{
			TankFrictionExitEvent eventInstance = new TankFrictionExitEvent();
			NewEvent(eventInstance).Attach(tankEntity).Schedule();
		}

		private void UpdateCollisionStay(Collider collider)
		{
			TriggerStay = true;
			FrictionCollider = collider;
		}

		private void DisableCollisionStay()
		{
			TriggerStay = false;
		}

		public void Init(Entity tankEntity)
		{
			this.tankEntity = tankEntity;
		}
	}
}
