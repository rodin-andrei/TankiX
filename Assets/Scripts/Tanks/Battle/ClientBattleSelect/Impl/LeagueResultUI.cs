using System;
using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientUserProfile.API;
using Tanks.Lobby.ClientUserProfile.Impl;
using TMPro;
using UnityEngine;

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

		private Entity previousLeague;

		private Entity currentLeague;

		private double points;

		private long place;

		private double delta;

		private bool unfairMM;

		private bool topLeague;

		private bool newLeagueUnlocked;

		private Dictionary<long, double> lastUserReputationInLeagues = new Dictionary<long, double>();

		private void OnDisable()
		{
			previousLeague = null;
			newLeague.gameObject.SetActive(false);
		}

		public void SetPreviousLeague(Entity previousLeague)
		{
			this.previousLeague = previousLeague;
		}

		public void SetCurrentLeague(Entity currentLeague, double points, long place, bool topLeague, double delta, bool unfairMM)
		{
			this.currentLeague = currentLeague;
			this.points = points;
			this.place = place;
			this.topLeague = topLeague;
			this.delta = delta;
			this.unfairMM = unfairMM;
			SetTooltip();
			if (previousLeague == null)
			{
				SetLeagueInfo(currentLeague);
				newLeagueUnlocked = false;
				return;
			}
			int leagueIndex = currentLeague.GetComponent<LeagueConfigComponent>().LeagueIndex;
			int leagueIndex2 = previousLeague.GetComponent<LeagueConfigComponent>().LeagueIndex;
			newLeagueUnlocked = leagueIndex > leagueIndex2;
			SetLeagueInfo((!newLeagueUnlocked) ? currentLeague : previousLeague);
		}

		public void DealWithReputationChange()
		{
			if (topLeague)
			{
				deltaAnimator.gameObject.SetActive(false);
				return;
			}
			SetDeltaAnimation();
			long immediate = (long)(points - delta);
			leaguePoints.SetImmediate(immediate);
			leaguePoints.Value = (long)points;
		}

		private void SetDeltaAnimation()
		{
			int num = (int)points - (int)(points - delta);
			deltaAnimator.gameObject.SetActive(num != 0);
			deltaAnimator.SetTrigger((num < 0) ? "Down" : "Up");
			deltaText.text = num.ToString("+#;-#");
		}

		public void ShowNewLeague()
		{
			if (newLeagueUnlocked)
			{
				animator.SetTrigger("NewLeagueUnlocked");
			}
		}

		public void SetNewLeagueIcon()
		{
			SetLeagueInfo(currentLeague);
		}

		private void SetLeagueInfo(Entity league)
		{
			leagueIcon.SpriteUid = league.GetComponent<LeagueIconComponent>().SpriteUid;
			if (topLeague)
			{
				leaguePointsTitle.text = placeText.Value;
				leaguePoints.SetImmediate(place);
			}
			else
			{
				leaguePointsTitle.text = leaguePointsText.Value;
			}
		}

		private void SetTooltip()
		{
			animator.SetBool("CurrentLeagueIsMax", topLeague);
			tooltip.IsMaxLeague = topLeague;
			if (!topLeague)
			{
				GetLeagueByIndexEvent getLeagueByIndexEvent = new GetLeagueByIndexEvent(currentLeague.GetComponent<LeagueConfigComponent>().LeagueIndex + 1);
				ScheduleEvent(getLeagueByIndexEvent, currentLeague);
				Entity leagueEntity = getLeagueByIndexEvent.leagueEntity;
				tooltip.SetNextLeagueTooltipData(GetReputationToEnter(leagueEntity) - Math.Truncate(points), leagueEntity.GetComponent<LeagueIconComponent>().SpriteUid, leagueEntity.GetComponent<LeagueNameComponent>().Name, (int)delta, unfairMM);
			}
			else
			{
				tooltip.TipText = string.Format(youLeaguePointsText, Math.Truncate(points));
			}
		}

		public void PutReputationToEnter(long legueId, double reputation)
		{
			lastUserReputationInLeagues[legueId] = reputation;
			SetTooltip();
		}

		private double GetReputationToEnter(Entity legue)
		{
			double reputationToEnter = legue.GetComponent<LeagueConfigComponent>().ReputationToEnter;
			return (!lastUserReputationInLeagues.ContainsKey(legue.Id)) ? reputationToEnter : Math.Max(lastUserReputationInLeagues[legue.Id], reputationToEnter);
		}
	}
}
