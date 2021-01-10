using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	public class AnimatedDiffRadialProgress : MonoBehaviour
	{
		[SerializeField]
		private AnimationCurve curve;
		[SerializeField]
		private Image fill;
		[SerializeField]
		private Image background;
		[SerializeField]
		private Image diff;
		[SerializeField]
		private float duration;
		[SerializeField]
		private float normalizedValue;
		[SerializeField]
		private float newValue;
	}
}
