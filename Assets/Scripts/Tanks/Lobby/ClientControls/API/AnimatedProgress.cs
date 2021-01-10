using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class AnimatedProgress : MonoBehaviour
	{
		[SerializeField]
		private AnimationCurve curve;
		[SerializeField]
		private UIRectClipper fill;
		[SerializeField]
		private UIRectClipper background;
		[SerializeField]
		private float duration;
	}
}
