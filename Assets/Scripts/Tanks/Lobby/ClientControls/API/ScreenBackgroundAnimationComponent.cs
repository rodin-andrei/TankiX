using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class ScreenBackgroundAnimationComponent : MonoBehaviour
	{
		[SerializeField]
		private int layerId;
		[SerializeField]
		private string state;
		[SerializeField]
		private string speedMultiplicatorName;
		[SerializeField]
		private Animator animator;
	}
}
