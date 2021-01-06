using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ItemSelectUI : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI itemName;
		[SerializeField]
		private TextMeshProUGUI feature;
		[SerializeField]
		private TextMeshProUGUI description;
		[SerializeField]
		private MainVisualPropertyUI[] props;
		[SerializeField]
		private AnimatedNumber mastery;
		[SerializeField]
		private Animator buttonsAnimator;
		[SerializeField]
		private BuyItemButton buyButton;
		[SerializeField]
		private BuyItemButton xBuyButton;
		[SerializeField]
		private TextMeshProUGUI crystalsRestrictionMismatch;
		[SerializeField]
		private TextMeshProUGUI crystalsRestrictionMatch;
		[SerializeField]
		private LocalizedField crystalsRestrictionMismatchField;
		[SerializeField]
		private LocalizedField crystalsRestrictionMatchField;
		[SerializeField]
		private Button changeSkinButton;
		[SerializeField]
		private Button changePaintButton;
		[SerializeField]
		private Button changeAmmoButton;
		[SerializeField]
		private Button changeCoverButton;
		[SerializeField]
		private CustomizationUIComponent customizationUI;
	}
}
