using Platform.Library.ClientUnityIntegration.API;
using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class InviteFriendsPanelLocalizationComponent : BehaviourComponent
	{
		[SerializeField]
		private Text showInviteFriendsPanelButton;
		[SerializeField]
		private Text hideInviteFriendsPanelButton;
		[SerializeField]
		private Text emptyListNotification;
	}
}
