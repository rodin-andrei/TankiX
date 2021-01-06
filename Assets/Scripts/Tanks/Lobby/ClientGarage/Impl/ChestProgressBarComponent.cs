using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ChestProgressBarComponent : BehaviourComponent
	{
		[SerializeField]
		private TooltipShowBehaviour tooltip;
		[SerializeField]
		private TooltipShowBehaviour chestTooltip;
		[SerializeField]
		private LocalizedField chestTooltipLocalization;
		[SerializeField]
		private LocalizedField chestTooltipLowLeagueLocalization;
		[SerializeField]
		private UIRectClipper bar;
		[SerializeField]
		private TextMeshProUGUI chestName;
		[SerializeField]
		private ImageSkin chestIcon;
	}
}
