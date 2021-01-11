using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class CartridgeCaseComponent : BehaviourComponent
	{
		public float lifeTime = 5f;

		private Collider collider;

		private bool _selfDestructionStarted;

		private void OnEnable()
		{
			collider = GetComponent<Collider>();
		}

		public void StartSelfDestruction()
		{
			if (!_selfDestructionStarted)
			{
				_selfDestructionStarted = true;
				Invoke("DestroyCase", lifeTime);
				collider = GetComponent<Collider>();
				collider.isTrigger = false;
			}
		}

		private void DestroyCase()
		{
			base.gameObject.RecycleObject();
			_selfDestructionStarted = false;
		}
	}
}
