using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class DailyBonusMainScreenButtonComponent : BehaviourComponent
	{
		private const string IS_ACTIVE = "isActive";

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

		private bool? isActiveState;

		private bool? interactable;

		public bool IsActiveState
		{
			set
			{
				if (!isActiveState.HasValue)
				{
					isActiveState = value;
					animator.SetBool("isActive", value);
				}
				else if (isActiveState.Value ^ value)
				{
					isActiveState = value;
					animator.SetBool("isActive", value);
				}
			}
		}

		public bool Interactable
		{
			set
			{
				canvasGroup.interactable = value;
				canvasGroup.alpha = ((!value) ? 0.5f : 1f);
				if (!interactable.HasValue)
				{
					tooltipShow.localizedTip = ((!value) ? disabledTipTip : enabledTip);
					tooltipShow.UpdateTipText();
					interactable = value;
				}
				else if (interactable.Value ^ value)
				{
					tooltipShow.localizedTip = ((!value) ? disabledTipTip : enabledTip);
					tooltipShow.UpdateTipText();
					interactable = value;
				}
			}
		}

		public void ResetState()
		{
			interactable = null;
			isActiveState = null;
		}
	}
}
