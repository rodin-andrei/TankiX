using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientControls.API
{
	public class AnimatedLong : MonoBehaviour
	{
		[SerializeField]
		private AnimationCurve curve;
		[SerializeField]
		private float duration;
		[SerializeField]
		private TextMeshProUGUI numberText;
		[SerializeField]
		private string format;
	}
}
