using Tanks.Lobby.ClientGarage.Impl;
using TMPro;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientMatchMaking.Impl
{
	public class BuyEnergyDialogComponent : ConfirmDialogComponent
	{
		[SerializeField]
		private TextMeshProUGUI message;
		[SerializeField]
		private TextMeshProUGUI buyButtonText;
		[SerializeField]
		private LocalizedField messageLoc;
		[SerializeField]
		private LocalizedField buyButtonLoc;
		[SerializeField]
		private LocalizedField chargesAmountSingularText;
		[SerializeField]
		private LocalizedField chargesAmountPlural1Text;
		[SerializeField]
		private LocalizedField chargesAmountPlural2Text;
	}
}
