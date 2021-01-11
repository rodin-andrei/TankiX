using System.Collections;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class GameplayChestResultUI : MonoBehaviour
	{
		[SerializeField]
		private AnimatedDiffRadialProgress progress;

		[SerializeField]
		protected TextMeshProUGUI progressValue;

		[SerializeField]
		private ImageSkin chestIcon;

		[SerializeField]
		private Button openChestButton;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private TooltipShowBehaviour progressTooltip;

		[SerializeField]
		private LocalizedField progressValueFormat;

		public long chestCount;

		[SerializeField]
		private long previousScores;

		[SerializeField]
		private long earnedScores;

		[SerializeField]
		private long limitScores;

		private float previousProgress;

		public void SetGameplayChestResult(string icon, long currentScores, long limitScores, long earnedScores)
		{
			this.earnedScores = earnedScores;
			this.limitScores = limitScores;
			progressValue.text = string.Format(progressValueFormat, earnedScores);
			chestIcon.SpriteUid = icon;
			long num = (currentScores - earnedScores) % limitScores;
			previousScores = ((num < 0) ? (limitScores + num) : num);
			previousProgress = Mathf.Clamp01((float)previousScores / (float)limitScores);
			progress.Set(previousProgress, previousProgress);
			progressTooltip.gameObject.SetActive(false);
			openChestButton.gameObject.SetActive(false);
		}

		public void ShowGameplayChestResult()
		{
			if (previousScores + earnedScores >= limitScores && chestCount > 1)
			{
				progress.Set(previousProgress, 1f);
				earnedScores -= limitScores - previousScores;
				previousScores = 0L;
				StartCoroutine(AnimateProgress());
			}
			if (previousScores + earnedScores >= limitScores && chestCount == 1)
			{
				progress.Set(previousProgress, 1f);
				animator.SetTrigger("GotChest");
				earnedScores -= limitScores - previousScores;
				previousScores = 0L;
				StartCoroutine(AnimateProgress());
			}
			if (previousScores + earnedScores < limitScores && chestCount < 1)
			{
				float newValue = Mathf.Clamp01((float)(previousScores + earnedScores) / (float)limitScores);
				progress.Set(previousProgress, newValue);
				progressTooltip.gameObject.SetActive(true);
				progressTooltip.TipText = string.Format("{0} / {1}", previousScores + earnedScores, limitScores);
			}
		}

		private IEnumerator AnimateProgress()
		{
			yield return new WaitForSeconds(0.3f);
			ResetProgress();
		}

		public void OpenGameplayChest()
		{
			animator.SetTrigger("ChestRewardTaken");
			previousProgress = 0f;
			float num = Mathf.Clamp01((float)(previousScores + earnedScores) / (float)limitScores);
			progress.Set(num, num);
			chestCount = 0L;
			ShowGameplayChestResult();
		}

		public void ResetProgress()
		{
			previousProgress = 0f;
			progress.Set(0f, 0f);
			chestCount--;
			ShowGameplayChestResult();
		}
	}
}
