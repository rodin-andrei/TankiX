using System;
using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientUserProfile.API;
using Tanks.Lobby.ClientUserProfile.Impl;
using TMPro;
using UnityEngine;

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

		private int selectedBar;

		private long chestScoreLimit;

		private int leaguesCount;

		private Entity userLeague;

		private double currentUserReputation;

		private readonly Dictionary<long, double> lastUserReputationInLeagues = new Dictionary<long, double>();

		private LeagueCarouselUIComponent carousel;

		public int PlaceInTopLeague
		{
			get;
			set;
		}

		public LeagueCarouselUIComponent Carousel
		{
			get
			{
				if (carousel == null)
				{
					carousel = GetComponentInChildren<LeagueCarouselUIComponent>(true);
					LeagueCarouselUIComponent leagueCarouselUIComponent = carousel;
					leagueCarouselUIComponent.itemSelected = (CarouselItemSelected)Delegate.Combine(leagueCarouselUIComponent.itemSelected, new CarouselItemSelected(LeagueSelected));
				}
				return carousel;
			}
		}

		public string GetSeasonEndsAsString(Date endDate)
		{
			float unityTime = endDate.UnityTime;
			float unityTime2 = Date.Now.UnityTime;
			float num = ((!(unityTime2 < unityTime)) ? 0f : (unityTime - unityTime2));
			int num2 = Mathf.FloorToInt(num / 86400f);
			int num3 = Mathf.FloorToInt((num - (float)(num2 * 24 * 60 * 60)) / 3600f);
			int num4 = Mathf.FloorToInt((num - (float)(num2 * 24 * 60 * 60) - (float)(num3 * 60 * 60)) / 60f);
			int num5 = Mathf.FloorToInt(num - (float)(num2 * 24 * 60 * 60) - (float)(num3 * 60 * 60) - (float)(num4 * 60));
			string text = seasonEndsIn;
			if (num2 > 0)
			{
				text = text + num2 + (string)seasonEndsDays;
				return text + num3 + (string)seasonEndsHours;
			}
			if (num3 > 0)
			{
				text = text + num3 + (string)seasonEndsHours;
				return text + num4 + (string)seasonEndsMinutes;
			}
			text = text + num4 + (string)seasonEndsMinutes;
			return text + num5 + (string)seasonEndsSeconds;
		}

		public void SetSeasonEndsInText(string endsIn)
		{
			seasonEndsInText.text = endsIn;
		}

		public void SetSeasonEndDate(Date endDate)
		{
			string seasonEndsAsString = GetSeasonEndsAsString(endDate);
			SetSeasonEndsInText(seasonEndsAsString);
		}

		public void SetChestScoreLimit(long score)
		{
			chestScoreLimit = score;
		}

		public void SetLeaguesCount(int count)
		{
			leaguesCount = count;
		}

		private void OnEnable()
		{
			SetRadioButton(0);
		}

		public void SelectUserLeague(Entity entity, double userReputation)
		{
			userLeague = entity;
			currentUserReputation = userReputation;
			Carousel.SelectItem(entity);
		}

		public LeagueTitleUIComponent AddLeagueItem(Entity entity)
		{
			return Carousel.AddLeagueItem(entity);
		}

		private void LeagueSelected(LeagueTitleUIComponent selectedLeague)
		{
			FillInfo(selectedLeague);
			FillLeagueChest(selectedLeague);
			FillSeasonReward(selectedLeague);
			FillTooltip(selectedLeague);
		}

		public void PutReputationToEnter(long legueId, double reputation)
		{
			lastUserReputationInLeagues[legueId] = reputation;
		}

		public void UpdateLeagueRewardUI()
		{
			FillInfo(Carousel.CurrentLeague);
		}

		private void FillInfo(LeagueTitleUIComponent selectedLeague)
		{
			bool flag = selectedLeague.LeagueEntity.Equals(userLeague);
			currentLeagueTitle.color = ((!flag) ? Color.clear : Color.white);
			string text = string.Empty;
			double d = 0.0;
			int leagueIndex = selectedLeague.LeagueEntity.GetComponent<LeagueConfigComponent>().LeagueIndex;
			GetLeagueByIndexEvent getLeagueByIndexEvent = new GetLeagueByIndexEvent(leagueIndex + 1);
			ScheduleEvent(getLeagueByIndexEvent, selectedLeague.LeagueEntity);
			Entity leagueEntity = getLeagueByIndexEvent.leagueEntity;
			if (leagueEntity != null)
			{
				text = leagueEntity.GetComponent<LeagueNameComponent>().NameAccusative;
				d = GetReputationToEnter(leagueEntity);
			}
			if (flag)
			{
				if (leagueIndex.Equals(leaguesCount - 1))
				{
					leaguePoints.text = string.Format(leaguePointsCurrentMax.Value, ToBoldText(Math.Truncate(currentUserReputation).ToString())) + "\n" + string.Format(leaguePlaceCurrentMax.Value, ToBoldText(PlaceInTopLeague.ToString()));
				}
				else
				{
					leaguePoints.text = string.Format(leaguePointsCurrent.Value, "<color=white><b>" + Math.Truncate(currentUserReputation), Math.Truncate(d) + "</b></color>", text + " " + leagueAccusative.Value);
				}
			}
			else
			{
				double reputationToEnter = GetReputationToEnter(selectedLeague.LeagueEntity);
				double num = reputationToEnter - currentUserReputation;
				leaguePoints.text = ((!(num > 0.0)) ? string.Empty : string.Format(leaguePointsNotCurrent.Value, "<color=white><b>" + Math.Ceiling(num) + "</b></color>"));
			}
		}

		private string ToBoldText(string text)
		{
			return "<color=white><b>" + text + "</b></color>";
		}

		private double GetReputationToEnter(Entity league)
		{
			double reputationToEnter = league.GetComponent<LeagueConfigComponent>().ReputationToEnter;
			return (!lastUserReputationInLeagues.ContainsKey(league.Id)) ? reputationToEnter : Math.Max(lastUserReputationInLeagues[league.Id], reputationToEnter);
		}

		private void FillLeagueChest(LeagueTitleUIComponent selectedLeague)
		{
			leagueChestList.Clear();
			long chestId = selectedLeague.LeagueEntity.GetComponent<ChestBattleRewardComponent>().ChestId;
			AddItemToList(chestId, 1, leagueChestList);
		}

		private void FillSeasonReward(LeagueTitleUIComponent selectedLeague)
		{
			seasonRewardList.Clear();
			bool active = false;
			bool active2 = false;
			Entity leagueEntity = selectedLeague.LeagueEntity;
			if (!leagueEntity.HasComponent<CurrentSeasonRewardForClientComponent>())
			{
				Debug.LogWarning("League doesn't have reward!");
				return;
			}
			List<EndSeasonRewardItem> rewards = selectedLeague.LeagueEntity.GetComponent<CurrentSeasonRewardForClientComponent>().Rewards;
			if (rewards.Count > 0)
			{
				if (selectedBar > rewards.Count - 1)
				{
					selectedBar = 0;
					SetRadioButton(0);
				}
				active2 = rewards.Count > 1;
				List<DroppedItem> items = rewards[selectedBar].Items;
				if (items != null)
				{
					active = items.Count > 0;
					foreach (DroppedItem item in items)
					{
						AddItemToList(item, seasonRewardList);
					}
				}
			}
			else
			{
				Debug.LogWarning("End season rewards is empty");
			}
			seasonRewardsTitleLayout.SetActive(active);
			tabsPanel.SetActive(active2);
		}

		private void FillTooltip(LeagueTitleUIComponent selectedLeague)
		{
			string text = string.Format(chestTooltipLocalization.Value, chestScoreLimit);
			if (userLeague.GetComponent<LeagueConfigComponent>().LeagueIndex < 3)
			{
				text += chestTooltipLowLeagueLocalization.Value;
			}
			chestTooltip.TipText = text;
		}

		private void AddItemToList(long itemId, int count, LeagueRewardListUIComponent list)
		{
			Entity entity = Flow.Current.EntityRegistry.GetEntity(itemId);
			DescriptionItemComponent component = entity.GetComponent<DescriptionItemComponent>();
			ImageItemComponent component2 = entity.GetComponent<ImageItemComponent>();
			string text = ((count <= 1) ? string.Empty : (" x" + count));
			string text2 = string.Empty;
			if (!entity.HasComponent<ContainerMarkerComponent>())
			{
				text2 = MarketItemNameLocalization.Instance.GetCategoryName(entity) + " ";
			}
			list.AddItem(text2 + component.Name + text + "\n" + component.Description, component2.SpriteUid);
		}

		private void AddItemToList(DroppedItem item, LeagueRewardListUIComponent list)
		{
			AddItemToList(item.marketItemEntity.Id, item.Amount, list);
		}

		private void OnDestroy()
		{
			LeagueCarouselUIComponent leagueCarouselUIComponent = Carousel;
			leagueCarouselUIComponent.itemSelected = (CarouselItemSelected)Delegate.Remove(leagueCarouselUIComponent.itemSelected, new CarouselItemSelected(LeagueSelected));
		}

		public void SelectBar(int value)
		{
			selectedBar = value;
			FillSeasonReward(Carousel.CurrentLeague);
			SetRadioButton(value);
		}

		private void SetRadioButton(int value)
		{
			RadioButton[] componentsInChildren = GetComponentsInChildren<RadioButton>(true);
			if (componentsInChildren.Length > value)
			{
				componentsInChildren[componentsInChildren.Length - 1 - value].Activate();
			}
		}
	}
}
