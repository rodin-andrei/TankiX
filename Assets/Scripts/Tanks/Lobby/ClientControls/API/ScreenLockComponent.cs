using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class ScreenLockComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Animator animator;

		public void Lock()
		{
			animator.gameObject.SetActive(false);
			animator.gameObject.SetActive(true);
		}

		public void Unlock()
		{
			if (animator.gameObject.activeSelf)
			{
				animator.SetTrigger("Unlock");
			}
		}
	}
}
