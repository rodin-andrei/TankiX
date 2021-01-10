using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class ProfileScreenComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI otherPlayerNickname;
		[SerializeField]
		private GameObject addToFriendRow;
		[SerializeField]
		private GameObject friendRequestRow;
		[SerializeField]
		private GameObject revokeFriendRow;
		[SerializeField]
		private GameObject removeFriendRow;
		[SerializeField]
		private GameObject enterBattleAsSpectatorRow;
		[SerializeField]
		private ImageListSkin leagueBorder;
		[SerializeField]
		private ImageSkin avatar;
		[SerializeField]
		private GameObject _premiumFrame;
		public GameObject selfUserAccountButtonsTab;
		public GameObject otherUserAccountButtonsTab;
		[SerializeField]
		private Color friendColor;
	}
}
