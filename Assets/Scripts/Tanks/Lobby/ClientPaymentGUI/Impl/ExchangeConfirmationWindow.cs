using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.Impl;
using Tanks.Lobby.ClientPayment.Impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	[RequireComponent(typeof(Animator))]
	public class ExchangeConfirmationWindow : LocalizedControl
	{
		[SerializeField]
		private Text questionText;

		[SerializeField]
		private TextMeshProUGUI confirmText;

		[SerializeField]
		private TextMeshProUGUI cancelText;

		[SerializeField]
		private Text forText;

		[SerializeField]
		private Button confirm;

		[SerializeField]
		private Button cancel;

		[SerializeField]
		private Text crystalsText;

		[SerializeField]
		private Text xCrystalsText;

		private Entity user;

		private long xCrystals;

		public string QuestionText
		{
			set
			{
				questionText.text = value;
			}
		}

		public string ConfirmText
		{
			set
			{
				confirmText.text = value;
			}
		}

		public string CancelText
		{
			set
			{
				cancelText.text = value;
			}
		}

		public string ForText
		{
			set
			{
				forText.text = value;
			}
		}

		public void Show(Entity user, long xCrystals, long crystals)
		{
			this.xCrystals = xCrystals;
			MainScreenComponent.Instance.OverrideOnBack(Hide);
			this.user = user;
			base.gameObject.SetActive(true);
			crystalsText.text = crystals.ToStringSeparatedByThousands();
			xCrystalsText.text = xCrystals.ToStringSeparatedByThousands();
		}

		protected override void Awake()
		{
			base.Awake();
			confirm.onClick.AddListener(OnConfirm);
			cancel.onClick.AddListener(OnCancel);
		}

		private void OnConfirm()
		{
			Hide();
			ECSBehaviour.EngineService.Engine.NewEvent(new ExchangeCrystalsEvent
			{
				XCrystals = xCrystals
			}).AttachAll(user).Schedule();
		}

		private void OnCancel()
		{
			Hide();
		}

		private void Hide()
		{
			MainScreenComponent.Instance.ClearOnBackOverride();
			GetComponent<Animator>().SetBool("Visible", false);
		}
	}
}
