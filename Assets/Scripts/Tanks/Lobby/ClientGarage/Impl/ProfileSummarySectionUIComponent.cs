using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientUserProfile.Impl;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ProfileSummarySectionUIComponent : BehaviourComponent
	{
		[SerializeField]
		private AnimatedProgress expProgress;
		[SerializeField]
		private TextMeshProUGUI exp;
		[SerializeField]
		private TextMeshProUGUI currentRank;
		[SerializeField]
		private TextMeshProUGUI nextRank;
		[SerializeField]
		private TextMeshProUGUI winStats;
		[SerializeField]
		private TextMeshProUGUI totalMatches;
		[SerializeField]
		private LocalizedField expLocalizedField;
		[SerializeField]
		private LocalizedField totalMatchesLocalizedField;
		[SerializeField]
		private RankUI rank;
		[SerializeField]
		private Color winColor;
		[SerializeField]
		private Color lossColor;
		public GameObject showRewardsButton;
	}
}
