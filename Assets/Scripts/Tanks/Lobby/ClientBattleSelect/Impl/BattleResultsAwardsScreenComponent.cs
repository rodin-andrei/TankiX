using System;
using System.Collections.Generic;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientBattleSelect.Impl;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientCore.Impl;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class BattleResultsAwardsScreenComponent : BehaviourComponent
	{
		public enum BattleTypes
		{
			None,
			Ranked,
			RankedWithCashback,
			Quick,
			Arcade,
			Custom,
			Tutorial
		}

		public enum ProgressResultParts
		{
			None,
			Experience,
			League,
			Energy,
			Container,
			Buttons
		}

		public GameObject openChestButton;

		public BattleResultSpecialOfferUiComponent specialOfferUI;

		public LeagueResultUI leagueResultUI;

		public LocalizedField tutorialCongratulationLocalizedField;

		public LocalizedField crysLocalizedField;

		public ImageSkin crysImageSkin;

		[Tooltip("WIN = 0, DEFEAT = 1, DRAW = 2")]
		[SerializeField]
		private Color[] titleColors;

		[SerializeField]
		private TextMeshProUGUI title;

		[SerializeField]
		private TextMeshProUGUI subTitle;

		[SerializeField]
		private ImageListSkin rankSkin;

		[SerializeField]
		private ImageSkin containerSkin;

		[SerializeField]
		private CircleProgressBar rankPoints;

		[SerializeField]
		private CircleProgressBar containerPoints;

		[SerializeField]
		private TextMeshProUGUI rankPointsText;

		[SerializeField]
		private TextMeshProUGUI containerPointsText;

		[SerializeField]
		private TankPartInfoComponent weaponInfo;

		[SerializeField]
		private TankPartInfoComponent hullInfo;

		[SerializeField]
		private CircleProgressBar weaponPoints;

		[SerializeField]
		private CircleProgressBar hullPoints;

		[SerializeField]
		private TextMeshProUGUI weaponPointsText;

		[SerializeField]
		private TextMeshProUGUI hullPointsText;

		[SerializeField]
		private Color deltaColor;

		[SerializeField]
		private Color multColor;

		[SerializeField]
		private GameObject containerScoreParent;

		[SerializeField]
		private TextMeshProUGUI newContainersCountText;

		[SerializeField]
		private TooltipShowBehaviour rankProgressTooltip;

		[SerializeField]
		private TooltipShowBehaviour rankNameTooltip;

		[SerializeField]
		private TooltipShowBehaviour containerTooltip;

		[SerializeField]
		private TooltipShowBehaviour hullLevelTooltip;

		[SerializeField]
		private TooltipShowBehaviour turretLevelTooltip;

		[SerializeField]
		private LocalizedField rankPointsLocalizedField;

		[SerializeField]
		private LocalizedField containerPointsLocalizedField;

		[SerializeField]
		private LocalizedField winLocalizedField;

		[SerializeField]
		private LocalizedField defeatLocalizedField;

		[SerializeField]
		private LocalizedField drawLocalizedField;

		[SerializeField]
		private LocalizedField placeLocalizedField;

		[SerializeField]
		private LocalizedField arcadeLocalizedField;

		[SerializeField]
		private LocalizedField ratingLocalizedField;

		[SerializeField]
		private LocalizedField energyLocalizedField;

		[SerializeField]
		private LocalizedField rankNameTooltipLocalizedField;

		[SerializeField]
		private LocalizedField levelLocalizedField;

		[SerializeField]
		private LocalizedField containersAmountSingularText;

		[SerializeField]
		private LocalizedField containersAmountPlural1Text;

		[SerializeField]
		private LocalizedField containersAmountPlural2Text;

		[SerializeField]
		private TooltipShowBehaviour[] scoreTooltips;

		public int CardsCount;

		private BattleTypes currentBattleType;

		private List<ProgressResultParts> currentProgressScenario;

		private readonly Dictionary<BattleTypes, List<ProgressResultParts>> progressScenarios = new Dictionary<BattleTypes, List<ProgressResultParts>>
		{
			{
				BattleTypes.None,
				new List<ProgressResultParts>()
			},
			{
				BattleTypes.Ranked,
				new List<ProgressResultParts>
				{
					ProgressResultParts.Experience,
					ProgressResultParts.League,
					ProgressResultParts.Container
				}
			},
			{
				BattleTypes.RankedWithCashback,
				new List<ProgressResultParts>
				{
					ProgressResultParts.Experience,
					ProgressResultParts.Energy,
					ProgressResultParts.League,
					ProgressResultParts.Container
				}
			},
			{
				BattleTypes.Quick,
				new List<ProgressResultParts>
				{
					ProgressResultParts.Experience,
					ProgressResultParts.Energy
				}
			},
			{
				BattleTypes.Arcade,
				new List<ProgressResultParts>
				{
					ProgressResultParts.Experience
				}
			},
			{
				BattleTypes.Custom,
				new List<ProgressResultParts>()
			},
			{
				BattleTypes.Tutorial,
				new List<ProgressResultParts>
				{
					ProgressResultParts.Experience
				}
			}
		};

		public void SetBattleType(BattleTypes battleType)
		{
			currentBattleType = battleType;
			currentProgressScenario = new List<ProgressResultParts>(progressScenarios[battleType]);
		}

		public bool CanShowLeagueProgress()
		{
			return currentProgressScenario != null && currentProgressScenario.Contains(ProgressResultParts.League);
		}

		public void ShowLeagueProgress()
		{
			containerScoreParent.SetActive(true);
			leagueResultUI.transform.parent.gameObject.SetActive(true);
		}

		public void HideLeagueProgress()
		{
			containerScoreParent.SetActive(false);
			leagueResultUI.transform.parent.gameObject.SetActive(false);
		}

		public void SetupHeader(BattleMode battleMode, BattleType matchMakingModeType, TeamBattleResult resultType, string mapName, int selfUserPlace)
		{
			title.color = titleColors[(uint)resultType];
			if (battleMode == BattleMode.DM)
			{
				title.text = string.Format(placeLocalizedField, selfUserPlace);
			}
			else
			{
				switch (resultType)
				{
				case TeamBattleResult.WIN:
					title.text = winLocalizedField.Value;
					break;
				case TeamBattleResult.DEFEAT:
					title.text = defeatLocalizedField.Value;
					break;
				case TeamBattleResult.DRAW:
					title.text = drawLocalizedField.Value;
					break;
				}
			}
			string arg = string.Empty;
			switch (matchMakingModeType)
			{
			case BattleType.ARCADE:
				arg = arcadeLocalizedField.Value;
				break;
			case BattleType.ENERGY:
				arg = energyLocalizedField.Value;
				break;
			case BattleType.RATING:
				arg = ratingLocalizedField.Value;
				break;
			}
			subTitle.text = string.Format("{0}({1}), {2}", arg, battleMode, mapName);
		}

		public void ShowRankProgress(int initValue, int current, int maxValue, int delta, int deltaWithoutMults, int currentRank, string[] rankNames)
		{
			VisualUpdateProgressBar(rankPoints, initValue, maxValue, current, deltaWithoutMults, delta, delegate
			{
				rankSkin.SelectSprite(currentRank.ToString());
			});
			VisualUpdateProgressText(rankPointsText, rankPointsLocalizedField, deltaWithoutMults, delta);
			rankSkin.SelectSprite((current - delta >= initValue) ? currentRank.ToString() : (currentRank - 1).ToString());
			if (currentRank + 1 < rankNames.Length)
			{
				rankProgressTooltip.TipText = string.Format("{0}/{1}", current, maxValue);
				rankNameTooltip.TipText = string.Format(rankNameTooltipLocalizedField.Value, rankNames[currentRank], maxValue - current, rankNames[currentRank + 1]);
			}
			else
			{
				rankProgressTooltip.TipText = current.ToString();
				rankNameTooltip.TipText = rankNames[currentRank];
			}
		}

		public void ShowContainerProgress(int currentValue, int delta, int deltaWithoutMults, int maxValue, string containerSpriteUID)
		{
			containerTooltip.TipText = string.Format("{0}/{1}", currentValue, maxValue);
			containerSkin.SpriteUid = containerSpriteUID;
			VisualUpdateProgressBar(containerPoints, 0, maxValue, currentValue, deltaWithoutMults, delta);
			VisualUpdateProgressText(containerPointsText, containerPointsLocalizedField, deltaWithoutMults, delta);
			if (currentValue - delta < 0)
			{
				int num = (delta - currentValue) / maxValue;
				newContainersCountText.text = "+ " + Pluralize(num + 1).ToLower();
			}
			else
			{
				newContainersCountText.text = string.Empty;
			}
		}

		private void RestartProgressBar(CircleProgressBar bar)
		{
			bar.StopAnimation();
			bar.ResetProgressView();
			bar.ClearUpgradeAnimations();
		}

		private void VisualUpdateProgressBar(CircleProgressBar bar, int startValue, int maxValue, int currentValue, int cleanDelta, int totalDelta, Action onAllAnimationsComplete = null)
		{
			if (maxValue <= 0)
			{
				return;
			}
			int num = totalDelta - cleanDelta;
			RestartProgressBar(bar);
			if (currentValue - totalDelta < startValue)
			{
				bar.Progress = 1f;
				int num2 = (totalDelta - currentValue) / maxValue - 1;
				for (int i = 0; i < num2; i++)
				{
					bar.AddUpgradeAnimation(1f, 0f);
				}
				int num3 = currentValue - startValue;
				if (num > num3)
				{
					bar.AddUpgradeAnimation(0f, 0f, (float)num3 / (float)maxValue);
				}
				else
				{
					bar.AddUpgradeAnimation(0f, (float)(num3 - num) / (float)maxValue, (float)num / (float)maxValue);
				}
			}
			else
			{
				bar.Progress = (float)(currentValue - totalDelta) / (float)maxValue;
				bar.AdditionalProgress = (float)cleanDelta / (float)maxValue;
				bar.AdditionalProgress1 = (float)num / (float)maxValue;
			}
			if (onAllAnimationsComplete != null)
			{
				bar.allAnimationComplete = (Action)Delegate.Combine(bar.allAnimationComplete, onAllAnimationsComplete);
			}
		}

		private void VisualUpdateProgressText(TextMeshProUGUI tmpText, LocalizedField mainString, int cleanDelta, int totalDelta)
		{
			float num = ((totalDelta <= 0) ? 1f : ((float)totalDelta / (float)cleanDelta));
			TooltipShowBehaviour[] array = scoreTooltips;
			foreach (TooltipShowBehaviour tooltipShowBehaviour in array)
			{
				tooltipShowBehaviour.enabled = num > 1f;
			}
			if (num > 1f)
			{
				tmpText.text = mainString.Value + " <color=#" + deltaColor.ToHexString() + "> " + totalDelta + "</color> <color=#" + multColor.ToHexString() + "> (+" + string.Format("{0:0}", num * 100f - 100f) + "%)</color>";
			}
			else
			{
				tmpText.text = mainString.Value + "<color=#" + deltaColor.ToHexString() + "> " + totalDelta + "</color>";
			}
		}

		public void SetTankInfo(long hullId, long turretId, List<ModuleInfo> modules, ModuleUpgradablePowerConfigComponent moduleConfig)
		{
			hullInfo.Set(hullId, modules, moduleConfig);
			weaponInfo.Set(turretId, modules, moduleConfig);
		}

		public void SetHullExp(int initValue, int currentValue, int maxValue, int delta, int deltaWithoutMults, int hullLevel)
		{
			hullLevelTooltip.TipText = string.Format("{0}: {1}", levelLocalizedField.Value, hullLevel);
			VisualUpdateProgressBar(hullPoints, initValue, maxValue, currentValue, deltaWithoutMults, delta);
			hullPointsText.text = "<color=#" + deltaColor.ToHexString() + ">+" + delta;
		}

		public void SetTurretExp(int initValue, int currentValue, int maxValue, int delta, int deltaWithoutMults, int turretLevel)
		{
			turretLevelTooltip.TipText = string.Format("{0}: {1}", levelLocalizedField.Value, turretLevel);
			VisualUpdateProgressBar(weaponPoints, initValue, maxValue, currentValue, deltaWithoutMults, delta);
			weaponPointsText.text = "<color=#" + deltaColor.ToHexString() + ">+" + delta;
		}

		public void ShowNotiffication()
		{
			if (CardsCount > 0)
			{
				GetComponentInParent<Animator>().SetBool("cards", true);
			}
		}

		public void HideNotiffication()
		{
			if (CardsCount <= 0)
			{
				GetComponentInParent<Animator>().SetBool("cards", false);
				CardsCount = 0;
			}
		}

		private string Pluralize(int amount)
		{
			switch (CasesUtil.GetCase(amount))
			{
			case CaseType.DEFAULT:
				return string.Format(containersAmountPlural1Text.Value, amount);
			case CaseType.ONE:
				return string.Format(containersAmountSingularText.Value, amount);
			case CaseType.TWO:
				return string.Format(containersAmountPlural2Text.Value, amount);
			default:
				throw new Exception("Invalid case");
			}
		}
	}
}
