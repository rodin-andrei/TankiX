using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class UidColorComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Color friendColor;

		[SerializeField]
		private Color moderatorColor;

		[SerializeField]
		private Color color;

		public Color FriendColor
		{
			get
			{
				return friendColor;
			}
			set
			{
				friendColor = value;
			}
		}

		public Color ModeratorColor
		{
			get
			{
				return moderatorColor;
			}
			set
			{
				moderatorColor = value;
			}
		}

		public Color Color
		{
			get
			{
				return color;
			}
			set
			{
				color = value;
			}
		}
	}
}
