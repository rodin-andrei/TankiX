using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class LoadGearComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Animator animator;

		[SerializeField]
		private ProgressBar gearProgressBar;

		public Animator Animator
		{
			get
			{
				return animator;
			}
		}

		public ProgressBar GearProgressBar
		{
			get
			{
				return gearProgressBar;
			}
		}

		private void Hide()
		{
			base.gameObject.SetActive(false);
		}
	}
}
