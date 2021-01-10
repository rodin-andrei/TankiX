using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Tanks.Lobby.ClientGarage.Impl;
using Tanks.Lobby.ClientBattleSelect.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class MatchLobbyGUIComponent : EventMappingComponent
	{
		[SerializeField]
		private GameObject teamList1Title;
		[SerializeField]
		private TextMeshProUGUI gameModeTitle;
		[SerializeField]
		private Image mapIcon;
		[SerializeField]
		private TextMeshProUGUI mapTitle;
		[SerializeField]
		private PresetsDropDownList presetsDropDownList;
		[SerializeField]
		private VisualItemsDropDownList hullSkinsDropDownList;
		[SerializeField]
		private VisualItemsDropDownList hullPaintDropDownList;
		[SerializeField]
		private VisualItemsDropDownList turretSkinsDropDownList;
		[SerializeField]
		private VisualItemsDropDownList turretPaintDropDownList;
		[SerializeField]
		private RectTransform blueTeamListWithHeader;
		[SerializeField]
		private RectTransform redTeamListWithHeader;
		[SerializeField]
		private TeamListGUIComponent blueTeamList;
		[SerializeField]
		private TeamListGUIComponent redTeamList;
		[SerializeField]
		private TextMeshProUGUI hullName;
		[SerializeField]
		private TextMeshProUGUI turretName;
		[SerializeField]
		private TextMeshProUGUI hullFeature;
		[SerializeField]
		private TextMeshProUGUI turretFeature;
		[SerializeField]
		private GameObject customGameElements;
		[SerializeField]
		private GameObject openBattleButton;
		[SerializeField]
		private GameObject inviteFriendsButton;
		[SerializeField]
		private GameObject editParamsButton;
		public TextMeshProUGUI paramTimeLimit;
		public TextMeshProUGUI paramFriendlyFire;
		public TextMeshProUGUI paramGravity;
		public TextMeshProUGUI enabledModules;
		public CreateBattleScreenComponent createBattleScreen;
		public GameObject chat;
	}
}
