using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class UserLabelAvatarComponent : MonoBehaviour
	{
		[SerializeField]
		private ImageSkin avatarImage;
		[SerializeField]
		private Color offlineColor;
		[SerializeField]
		private Color onlineColor;
		[SerializeField]
		private ImageListSkin _avatarFrame;
	}
}
