using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class LeagueRewardUIComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI currentLeagueTitle;
		[SerializeField]
		private LeagueRewardListUIComponent leagueChestList;
		[SerializeField]
		private LeagueRewardListUIComponent seasonRewardList;
		[SerializeField]
		private TextMeshProUGUI leaguePoints;
		[SerializeField]
		private LocalizedField leaguePointsCurrentMax;
		[SerializeField]
		private LocalizedField leaguePlaceCurrentMax;
		[SerializeField]
		private LocalizedField leaguePointsCurrent;
		[SerializeField]
		private LocalizedField leaguePointsNotCurrent;
		[SerializeField]
		private LocalizedField leagueAccusative;
		[SerializeField]
		private LocalizedField seasonEndsIn;
		[SerializeField]
		private LocalizedField seasonEndsDays;
		[SerializeField]
		private LocalizedField seasonEndsHours;
		[SerializeField]
		private LocalizedField seasonEndsMinutes;
		[SerializeField]
		private LocalizedField seasonEndsSeconds;
		[SerializeField]
		private TextMeshProUGUI seasonEndsInText;
		[SerializeField]
		private GameObject seasonRewardsTitleLayout;
		[SerializeField]
		private LocalizedField chestTooltipLocalization;
		[SerializeField]
		private LocalizedField chestTooltipLowLeagueLocalization;
		[SerializeField]
		private TooltipShowBehaviour chestTooltip;
		[SerializeField]
		private GameObject tabsPanel;
	}
}
