using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using Tanks.Battle.ClientBattleSelect.Impl;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class BattleResultsAwardsScreenComponent : BehaviourComponent
	{
		public GameObject openChestButton;
		public BattleResultSpecialOfferUiComponent specialOfferUI;
		public LeagueResultUI leagueResultUI;
		public LocalizedField tutorialCongratulationLocalizedField;
		public LocalizedField crysLocalizedField;
		public ImageSkin crysImageSkin;
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
	}
}
