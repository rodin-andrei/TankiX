using System;
using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class BattleResultAwardsScreenAnimationComponent : BehaviourComponent
	{
		[SerializeField]
		private Animator headerAnimator;

		[SerializeField]
		private Animator infoAnimator;

		[SerializeField]
		private Animator tankInfoAnimator;

		[SerializeField]
		private Animator specialOfferAnimator;

		[SerializeField]
		private CircleProgressBar rankProgressBar;

		[SerializeField]
		private CircleProgressBar containerProgressBar;

		[SerializeField]
		private CircleProgressBar hullProgressBar;

		[SerializeField]
		private CircleProgressBar turretProgressBar;

		private List<Action> actions;

		private float showDelay = 0.2f;

		private float timer;

		public bool playActions;

		[Inject]
		public new static EngineServiceInternal EngineService
		{
			get;
			set;
		}

		private void OnEnable()
		{
			timer = 0f;
			showDelay = 0.2f;
			playActions = true;
			actions = new List<Action>
			{
				ShowHeader,
				ShowInfo,
				ShowTankInfo,
				ShowSpecialOffer
			};
			rankProgressBar.StopAnimation();
			containerProgressBar.StopAnimation();
			hullProgressBar.StopAnimation();
			turretProgressBar.StopAnimation();
		}

		private void Update()
		{
			if (playActions)
			{
				timer += Time.deltaTime;
				if (timer > showDelay)
				{
					timer = 0f;
					NextAction();
				}
			}
		}

		private void NextAction()
		{
			if (actions.Count > 0)
			{
				Action action = actions[0];
				actions.Remove(action);
				playActions = actions.Count > 0;
				action();
			}
		}

		private void OnDisable()
		{
			DisableAll();
		}

		public void ShowHeader()
		{
			headerAnimator.SetBool("on", true);
		}

		public void ShowInfo()
		{
			playActions = false;
			infoAnimator.SetBool("on", true);
			showDelay = 0.5f;
			ShowBattleResultsScreenNotificationEvent showBattleResultsScreenNotificationEvent = new ShowBattleResultsScreenNotificationEvent();
			showBattleResultsScreenNotificationEvent.Index = 1;
			EngineService.Engine.ScheduleEvent(showBattleResultsScreenNotificationEvent, EngineService.EntityStub);
			if (!showBattleResultsScreenNotificationEvent.NotificationExist)
			{
				playActions = true;
			}
			rankProgressBar.Animate(1f);
			containerProgressBar.Animate(1f);
		}

		public void ShowTankInfo()
		{
			EngineService.Engine.ScheduleEvent<BuildSelfPlayerTankEvent>(EngineService.EntityStub);
			tankInfoAnimator.SetBool("on", true);
			hullProgressBar.Animate(1f);
			turretProgressBar.Animate(1f);
		}

		public void ShowSpecialOffer()
		{
			specialOfferAnimator.SetBool("on", true);
			ShowButtons();
		}

		public void ShowButtons()
		{
			GetComponentInParent<BattleResultCommonUIComponent>().ShowBottomPanel();
			GetComponentInParent<BattleResultCommonUIComponent>().ShowTopPanel();
		}

		public void DisableAll()
		{
			playActions = false;
			headerAnimator.SetBool("on", false);
			infoAnimator.SetBool("on", false);
			tankInfoAnimator.SetBool("on", false);
			specialOfferAnimator.SetBool("on", false);
			headerAnimator.GetComponentInChildren<CanvasGroup>().alpha = 0f;
			infoAnimator.GetComponentInChildren<CanvasGroup>().alpha = 0f;
			tankInfoAnimator.GetComponentInChildren<CanvasGroup>().alpha = 0f;
			specialOfferAnimator.GetComponentInChildren<CanvasGroup>().alpha = 0f;
		}
	}
}
