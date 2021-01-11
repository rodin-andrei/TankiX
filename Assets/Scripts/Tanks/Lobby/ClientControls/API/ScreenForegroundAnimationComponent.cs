using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class ScreenForegroundAnimationComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Animator animator;

		public Animator Animator
		{
			get
			{
				return animator;
			}
		}

		public float Alpha
		{
			get
			{
				return GetComponent<CanvasGroup>().alpha;
			}
			set
			{
				GetComponent<CanvasGroup>().alpha = value;
			}
		}
	}
}
