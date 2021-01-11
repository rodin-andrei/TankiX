using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;

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

		public string ShowInviteFriendsPanelButton
		{
			set
			{
				showInviteFriendsPanelButton.text = value;
			}
		}

		public string HideInviteFriendsPanelButton
		{
			set
			{
				hideInviteFriendsPanelButton.text = value;
			}
		}

		public string EmptyListNotification
		{
			set
			{
				emptyListNotification.text = value;
			}
		}

		public string InviteSentNotification
		{
			get;
			set;
		}
	}
}
