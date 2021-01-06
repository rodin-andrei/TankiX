using UnityEngine.UI;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

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
	}
}
