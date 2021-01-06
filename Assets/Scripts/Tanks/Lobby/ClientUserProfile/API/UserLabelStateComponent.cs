using Platform.Library.ClientUnityIntegration.API;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class UserLabelStateComponent : BehaviourComponent
	{
		[SerializeField]
		private Image[] images;
		[SerializeField]
		private CanvasGroup textGroup;
		[SerializeField]
		private TextMeshProUGUI stateText;
		[SerializeField]
		private LocalizedField online;
		[SerializeField]
		private LocalizedField offline;
		[SerializeField]
		private LocalizedField inBattle;
		[SerializeField]
		private Color onlineColor;
		[SerializeField]
		private Color offlineColor;
		[SerializeField]
		private float alpha;
		[SerializeField]
		private bool userInBattle;
		[SerializeField]
		private GameObject userInSquadLabel;
		[SerializeField]
		private Button inviteButton;
		[SerializeField]
		private bool disableInviteOnlyForSquadState;
	}
}
