using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class LeagueUIComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI leagueName;
		[SerializeField]
		private ImageSkin leagueIcon;
		[SerializeField]
		private TextMeshProUGUI leaguePoints;
		[SerializeField]
		private LocalizedField pointsLocalizedField;
	}
}
