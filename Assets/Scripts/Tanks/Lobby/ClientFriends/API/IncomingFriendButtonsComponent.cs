using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientFriends.API
{
	public class IncomingFriendButtonsComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject acceptButton;
		[SerializeField]
		private GameObject declineButton;
	}
}
