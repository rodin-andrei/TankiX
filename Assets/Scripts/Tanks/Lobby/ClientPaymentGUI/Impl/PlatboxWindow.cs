using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientGarage.Impl;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class PlatboxWindow : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI info;

		[SerializeField]
		private TMP_InputField phone;

		[SerializeField]
		private TextMeshProUGUI code;

		[SerializeField]
		private Animator continueButton;

		private Action onBack;

		private Action onForward;

		public string EnteredPhoneNumber
		{
			get
			{
				return code.text + phone.text.Replace(" ", string.Empty);
			}
		}

		private void Awake()
		{
			phone.onValueChanged.AddListener(ValidateInput);
		}

		private void ValidateInput(string value)
		{
			continueButton.SetBool("Visible", phone.text.Length == phone.characterLimit);
		}

		public void Show(Entity item, Entity method, Action onBack, Action onForward)
		{
			phone.text = string.Empty;
			phone.Select();
			MainScreenComponent.Instance.OverrideOnBack(Cancel);
			this.onBack = onBack;
			this.onForward = onForward;
			base.gameObject.SetActive(true);
			info.text = ShopDialogs.FormatItem(item, method);
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
	}
}
