using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientControls.API
{
	public class AnimatedNumber : MonoBehaviour
	{
		[SerializeField]
		private AnimationCurve curve;
		[SerializeField]
		private TextMeshProUGUI numberText;
		[SerializeField]
		private string format;
		[SerializeField]
		private float duration;
	}
}
