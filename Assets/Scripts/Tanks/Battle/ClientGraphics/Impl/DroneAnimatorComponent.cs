using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[RequireComponent(typeof(Animator))]
	public class DroneAnimatorComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private string idleStateName = "idle";

		[SerializeField]
		private string shootStateName = "shot";

		private int idleStateIndex;

		private int shootStateIndex;

		private Animator vulcanAnimator;

		private void Awake()
		{
			vulcanAnimator = GetComponent<Animator>();
			idleStateIndex = Animator.StringToHash(idleStateName);
			shootStateIndex = Animator.StringToHash(shootStateName);
		}

		public void StartIdle()
		{
			vulcanAnimator.SetTrigger(idleStateIndex);
		}

		public void StartShoot()
		{
			vulcanAnimator.SetTrigger(shootStateIndex);
		}
	}
}
