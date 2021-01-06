using Platform.Library.ClientUnityIntegration.API;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class CaptchaComponent : BehaviourComponent
	{
		[SerializeField]
		private Image captchaImage;
		[SerializeField]
		private Animator animator;
	}
}
