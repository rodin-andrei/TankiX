using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientProfile.API;
using Tanks.Lobby.ClientUserProfile.Impl;
using TMPro;
using UnityEngine;

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

		public void SetLevelInfo(LevelInfo levelInfo, string rankName)
		{
			bool isMaxLevel = levelInfo.IsMaxLevel;
			nextRank.gameObject.SetActive(!isMaxLevel);
			expProgress.NormalizedValue = levelInfo.Progress;
			currentRank.text = (levelInfo.Level + 1).ToString();
			nextRank.text = (levelInfo.Level + 2).ToString();
			exp.text = ((!isMaxLevel) ? string.Format(expLocalizedField.Value, levelInfo.Experience, levelInfo.MaxExperience) : levelInfo.Experience.ToString());
			rank.SetRank(levelInfo.Level, rankName);
		}

		public void SetWinLossStatistics(long winCount, long lossCount, long battlesCount)
		{
			winStats.text = "<color=#" + winColor.ToHexString() + ">" + winCount + "/<color=#" + lossColor.ToHexString() + ">" + lossCount;
			totalMatches.text = totalMatchesLocalizedField.Value + "\n" + battlesCount;
		}
	}
}
