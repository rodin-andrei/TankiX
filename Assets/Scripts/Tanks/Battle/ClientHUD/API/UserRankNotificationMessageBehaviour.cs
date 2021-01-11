using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.API
{
	public class UserRankNotificationMessageBehaviour : BaseUserNotificationMessageBehaviour
	{
		[SerializeField]
		private Image iconImage;

		[SerializeField]
		private ImageListSkin icon;

		[SerializeField]
		private Text message;

		public ImageListSkin Icon
		{
			get
			{
				return icon;
			}
		}

		public Image IconImage
		{
			get
			{
				return iconImage;
			}
		}

		public Text Message
		{
			get
			{
				return message;
			}
		}

		private void OnIconFlyReady()
		{
			animator.SetTrigger("TextFadeIn");
		}
	}
}
