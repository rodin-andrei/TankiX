using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class MapAnimatorTriggerComponent : MonoBehaviour
	{
		public Transform animator;

		private Animator animatorController;

		public string triggerEnable;

		public string triggerDisable;

		private int count;

		private void Start()
		{
			animatorController = animator.GetComponent<Animator>();
		}

		private void OnTriggerEnter()
		{
			if (count == 0)
			{
				animatorController.SetBool(triggerEnable, true);
			}
			count++;
		}

		private void OnTriggerExit()
		{
			if (count == 1)
			{
				animatorController.SetBool(triggerEnable, false);
			}
			count--;
		}
	}
}
