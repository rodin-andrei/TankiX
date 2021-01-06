using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientMatchMaking.Impl
{
	public class UserEnergyCellUIComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI nickname;
		[SerializeField]
		private TextMeshProUGUI energyValue;
		[SerializeField]
		private TextMeshProUGUI energyGiftText;
		[SerializeField]
		private Color notEnoughColor;
		[SerializeField]
		private Image borederImage;
		[SerializeField]
		private GameObject enoughView;
		[SerializeField]
		private GameObject notEnoughView;
		[SerializeField]
		private TextMeshProUGUI text;
		[SerializeField]
		private LocalizedField shareEnergyText;
		[SerializeField]
		private LocalizedField buyEnergyText;
		[SerializeField]
		private GameObject shareButton;
		[SerializeField]
		private GameObject line;
		[SerializeField]
		private LocalizedField chargesAmountSingularText;
		[SerializeField]
		private LocalizedField chargesAmountPlural1Text;
		[SerializeField]
		private LocalizedField chargesAmountPlural2Text;
		[SerializeField]
		private LocalizedField fromText;
	}
}
