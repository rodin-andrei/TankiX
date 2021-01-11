using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class UserLabelAvatarComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private ImageSkin avatarImage;

		[SerializeField]
		private Color offlineColor;

		[SerializeField]
		private Color onlineColor;

		[SerializeField]
		private ImageListSkin _avatarFrame;

		public Color OfflineColor
		{
			get
			{
				return offlineColor;
			}
		}

		public Color OnlineColor
		{
			get
			{
				return onlineColor;
			}
		}

		public ImageSkin AvatarImage
		{
			get
			{
				return avatarImage;
			}
		}

		public bool IsPremium
		{
			set
			{
				if ((bool)_avatarFrame)
				{
					_avatarFrame.SelectedSpriteIndex = (value ? 3 : 0);
				}
			}
		}

		public bool IsSelf
		{
			set
			{
				if ((bool)_avatarFrame && value)
				{
					_avatarFrame.SelectedSpriteIndex = 1;
				}
			}
		}
	}
}
