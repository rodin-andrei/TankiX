using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientGarage.Impl;
using Tanks.Lobby.ClientPayment.Impl;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class WarningWindowComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI info;

		[SerializeField]
		private TextMeshProUGUI warning;

		[SerializeField]
		private LocalizedField warningText;

		[SerializeField]
		private PaletteColorField xCrystalColor;

		private Action onBack;

		private Action onForward;

		public void Show(Entity item, Action onBack, Action onForward)
		{
			MainScreenComponent.Instance.OverrideOnBack(Cancel);
			this.onBack = onBack;
			this.onForward = onForward;
			base.gameObject.SetActive(true);
			info.text = ShopDialogs.FormatItem(item);
			warning.text = string.Empty;
			ECSBehaviour.EngineService.Engine.NewEvent<CalculateCompensationRequestEvent>().AttachAll(SelfUserComponent.SelfUser, item).Schedule();
		}

		public void Cancel()
		{
			MainScreenComponent.Instance.ClearOnBackOverride();
			GetComponent<Animator>().SetTrigger("cancel");
			onBack();
		}

		public void Proceed()
		{
			MainScreenComponent.Instance.ClearOnBackOverride();
			GetComponent<Animator>().SetTrigger("cancel");
			onForward();
		}

		public void SetCompensation(long amount)
		{
			warning.text = string.Format(warningText.Value, string.Format("<#{0}>{1}<sprite=9></color>", xCrystalColor.Color.ToHexString(), amount));
		}
	}
}
