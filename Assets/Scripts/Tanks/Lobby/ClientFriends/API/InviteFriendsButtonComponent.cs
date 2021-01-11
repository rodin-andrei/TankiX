using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientFriends.API
{
	public class InviteFriendsButtonComponent : BehaviourComponent
	{
		[SerializeField]
		private RectTransform popupPosition;

		public Vector3 PopupPosition
		{
			get
			{
				return popupPosition.position;
			}
		}
	}
}
