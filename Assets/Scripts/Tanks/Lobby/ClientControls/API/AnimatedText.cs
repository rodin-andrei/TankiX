using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientControls.API
{
	public class AnimatedText : MonoBehaviour
	{
		[SerializeField]
		protected TextMeshProUGUI message;
		[SerializeField]
		private float textAnimationDelay;
	}
}
