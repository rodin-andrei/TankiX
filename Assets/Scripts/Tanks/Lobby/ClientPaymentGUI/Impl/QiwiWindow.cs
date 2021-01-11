using System;
using System.Collections;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientGarage.Impl;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class QiwiWindow : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI info;

		[SerializeField]
		private QiwiAccountFormatterComponent account;

		[SerializeField]
		private Animator continueButton;

		private Action onBack;

		private Action onForward;

		public string Account
		{
			get
			{
				return account.Account;
			}
		}

		private void Awake()
		{
			account.GetComponent<TMP_InputField>().onValueChanged.AddListener(ValidateInput);
		}

		private void ValidateInput(string value)
		{
			continueButton.SetBool("Visible", account.IsValidPhoneNumber);
		}

		public void Show(Entity item, Entity method, string acc, Action onBack, Action onForward)
		{
			base.gameObject.SetActive(true);
			if (!string.IsNullOrEmpty(acc))
			{
				StartCoroutine(DelaySet(acc));
			}
			account.GetComponent<TMP_InputField>().Select();
			MainScreenComponent.Instance.OverrideOnBack(Cancel);
			this.onBack = onBack;
			this.onForward = onForward;
			info.text = ShopDialogs.FormatItem(item, method);
		}

		private IEnumerator DelaySet(string acc)
		{
			yield return new WaitForEndOfFrame();
			TMP_InputField input = account.GetComponent<TMP_InputField>();
			input.text += acc;
			input.MoveTextEnd(false);
			continueButton.SetBool("Visible", false);
			account.GetComponent<Animator>().SetBool("HasError", true);
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
