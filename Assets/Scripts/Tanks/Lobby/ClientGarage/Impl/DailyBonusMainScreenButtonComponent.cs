using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class DailyBonusMainScreenButtonComponent : BehaviourComponent
	{
		[SerializeField]
		private Animator animator;
		[SerializeField]
		private CanvasGroup canvasGroup;
		[SerializeField]
		private LocalizedField enabledTip;
		[SerializeField]
		private LocalizedField disabledTipTip;
		[SerializeField]
		private TooltipShowBehaviour tooltipShow;
	}
}
