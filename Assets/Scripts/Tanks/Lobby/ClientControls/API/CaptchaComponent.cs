using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	public class CaptchaComponent : BehaviourComponent
	{
		[SerializeField]
		private Image captchaImage;

		[SerializeField]
		private Animator animator;

		public Sprite CaptchaSprite
		{
			get
			{
				return captchaImage.sprite;
			}
			set
			{
				captchaImage.sprite = value;
			}
		}

		public Animator Animator
		{
			get
			{
				return animator;
			}
		}
	}
}
