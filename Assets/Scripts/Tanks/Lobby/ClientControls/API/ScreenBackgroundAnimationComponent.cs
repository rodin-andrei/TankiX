using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class ScreenBackgroundAnimationComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private int layerId;

		[SerializeField]
		private string state = "Show";

		[SerializeField]
		private string speedMultiplicatorName = "showSpeed";

		[SerializeField]
		private Animator animator;

		public int LayerId
		{
			get
			{
				return layerId;
			}
		}

		public int State
		{
			get;
			private set;
		}

		public int SpeedMultiplicatorId
		{
			get;
			private set;
		}

		public Animator Animator
		{
			get
			{
				return animator;
			}
		}

		public ScreenBackgroundAnimationComponent()
		{
			State = Animator.StringToHash(state);
			SpeedMultiplicatorId = Animator.StringToHash(speedMultiplicatorName);
		}
	}
}
