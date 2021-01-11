using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientQuests.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientQuests.Impl
{
	public class InBattleQuestItemGUIComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI taskText;

		[SerializeField]
		private ImageSkin taskImageSkin;

		[SerializeField]
		private TextMeshProUGUI currentProgressValue;

		[SerializeField]
		private TextMeshProUGUI targetProgressValue;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private InBattleQuestItemGUIRewardContainerComponent rewardContainer;

		private bool questCompleted;

		public string TaskText
		{
			get
			{
				return taskText.text;
			}
			set
			{
				taskText.text = value;
			}
		}

		public string TargetProgressValue
		{
			get
			{
				return targetProgressValue.text;
			}
			set
			{
				targetProgressValue.text = value;
			}
		}

		public string CurrentProgressValue
		{
			get
			{
				return currentProgressValue.text;
			}
			set
			{
				currentProgressValue.text = value;
			}
		}

		public void SetReward(BattleQuestReward reward, int quatity, long itemId)
		{
			rewardContainer.SetActiveReward(reward, quatity, itemId);
		}

		public void SetImage(string spriteUid)
		{
			taskImageSkin.SpriteUid = spriteUid;
		}

		public void UpdateCurrentProgressValue(string newCurrentProgressValue, bool questCompleted = false)
		{
			this.questCompleted = questCompleted;
			CurrentProgressValue = newCurrentProgressValue;
			animator.SetTrigger("ShowProgress");
		}

		public void ProgressWasShown()
		{
			if (questCompleted)
			{
				CompleteQuest();
			}
		}

		public void DestroyQuest()
		{
			Object.Destroy(base.gameObject);
		}

		public void CompleteQuest()
		{
			animator.SetTrigger("Complete");
		}
	}
}
