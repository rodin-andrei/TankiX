using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientQuests.Impl
{
	public class QuestItemGUIComponent : BehaviourComponent, AttachToEntityListener, DetachFromEntityListener
	{
		private Entity entity;

		[SerializeField]
		private TextMeshProUGUI taskText;

		[SerializeField]
		private TextMeshProUGUI conditionText;

		[SerializeField]
		private QuestProgressGUIComponent questProgressGUIComponent;

		[SerializeField]
		private QuestRewardGUIComponent questRewardGUIComponent;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private GameObject premiumBackground;

		[SerializeField]
		private TextMeshProUGUI questsCount;

		[SerializeField]
		private GameObject changeButton;

		public QuestProgressGUIComponent QuestProgressGUIComponent
		{
			get
			{
				return questProgressGUIComponent;
			}
		}

		public QuestRewardGUIComponent QuestRewardGUIComponent
		{
			get
			{
				return questRewardGUIComponent;
			}
		}

		public string ConditionText
		{
			get
			{
				return conditionText.text;
			}
			set
			{
				conditionText.text = value;
				conditionText.gameObject.SetActive(true);
			}
		}

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

		public void ShowQuest()
		{
			animator.SetTrigger("ActivateQuest");
		}

		public void RemoveQuest()
		{
			animator.SetTrigger("RemoveQuest");
		}

		public void AddQuest()
		{
			animator.SetTrigger("AddQuest");
		}

		public void CompeleQuest()
		{
			animator.SetTrigger("CompleteQuest");
		}

		public void SetQuestCompleted(bool value)
		{
			animator.SetBool("completedQuest", value);
		}

		public void SetQuestResult(bool value)
		{
			animator.SetBool("questResult", value);
		}

		public void ShowPremiumBack(int count)
		{
			premiumBackground.SetActive(true);
			questsCount.text = count.ToString();
		}

		public void SetChangeButtonActivity(bool active)
		{
			changeButton.SetActive(active);
		}

		private void QuestRemoved()
		{
			if (entity != null)
			{
				ECSBehaviour.EngineService.Engine.ScheduleEvent(new QuestRemovedEvent(), entity);
			}
			else
			{
				Object.Destroy(base.gameObject);
			}
		}

		public void ChangeQuest()
		{
			if (entity != null)
			{
				animator.SetBool("showConfirmChangeQuest", true);
				ECSBehaviour.EngineService.Engine.ScheduleEvent(new HideQuestsChangeMenuEvent(), entity);
			}
		}

		public void ConfirmChangeQuest()
		{
			if (entity != null)
			{
				ECSBehaviour.EngineService.Engine.ScheduleEvent(new ChangeQuestEvent(), entity);
			}
		}

		public void RejectChangeQuest()
		{
			animator.SetBool("showConfirmChangeQuest", false);
		}

		void AttachToEntityListener.AttachedToEntity(Entity entity)
		{
			this.entity = entity;
		}

		void DetachFromEntityListener.DetachedFromEntity(Entity entity)
		{
			this.entity = null;
			Object.Destroy(base.gameObject);
		}
	}
}
