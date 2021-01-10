using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class AnimatedDiffProgress : MonoBehaviour
	{
		[SerializeField]
		private AnimationCurve curve;
		[SerializeField]
		private UIRectClipper fill;
		[SerializeField]
		private UIRectClipper background;
		[SerializeField]
		private UIRectClipper diff;
		[SerializeField]
		private float duration;
	}
}
