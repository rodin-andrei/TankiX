using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class BattleResultSpecialOfferUiComponent : ItemContainerComponent
	{
		[SerializeField]
		private TextMeshProUGUI titleText;
		[SerializeField]
		private TextMeshProUGUI descriptionText;
		[SerializeField]
		private GameObject smile;
		[SerializeField]
		private SpecialOfferPriceButtonComponent priceButton;
		[SerializeField]
		private SpecialOfferCrystalButtonComponent crystalButton;
		[SerializeField]
		private SpecialOfferUseDiscountComponent useDiscountButton;
		[SerializeField]
		private SpecialOfferTakeRewardButtonComponent takeRewardButton;
		[SerializeField]
		private Button tutorialRewardButton;
		[SerializeField]
		private SpecialOfferOpenContainerButton openButton;
		[SerializeField]
		private SpecialOfferWorthItComponent worthIt;
		[SerializeField]
		private Animator animator;
		[SerializeField]
		private LocalizedField tutorialCongratulationLocalizedField;
	}
}
