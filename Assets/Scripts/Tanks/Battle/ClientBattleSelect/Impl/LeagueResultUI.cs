using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using TMPro;

namespace Tanks.Battle.ClientBattleSelect.Impl
{
	public class LeagueResultUI : ECSBehaviour
	{
		[SerializeField]
		private ImageSkin leagueIcon;
		[SerializeField]
		private TextMeshProUGUI leaguePointsTitle;
		[SerializeField]
		private TextMeshProUGUI leaguePointsValue;
		[SerializeField]
		private TextMeshProUGUI newLeague;
		[SerializeField]
		private Animator animator;
		[SerializeField]
		private NextLeagueTooltipShowComponent tooltip;
		[SerializeField]
		private LocalizedField leaguePointsText;
		[SerializeField]
		private LocalizedField placeText;
		[SerializeField]
		private LocalizedField youLeaguePointsText;
		[SerializeField]
		private AnimatedLong leaguePoints;
		[SerializeField]
		private Animator deltaAnimator;
		[SerializeField]
		private TextMeshProUGUI deltaText;
	}
}
