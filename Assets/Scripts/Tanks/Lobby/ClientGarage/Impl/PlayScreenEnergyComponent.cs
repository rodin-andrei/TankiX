using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using System.Collections.Generic;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class PlayScreenEnergyComponent : BehaviourComponent
	{
		[SerializeField]
		private Color fullColor;
		[SerializeField]
		private Color partColor;
		[SerializeField]
		private List<UIRectClipperY> energyBar;
		[SerializeField]
		private TextMeshProUGUI quantumCountText;
		[SerializeField]
		private TooltipShowBehaviour tooltip;
	}
}
