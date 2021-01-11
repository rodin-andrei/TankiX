using System;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientGarage.Impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientPaymentGUI.Impl.Payguru
{
	public class PayguruDialogComponent : EntityBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI label;

		[SerializeField]
		private ScrollRect scrollRect;

		[SerializeField]
		private PayguruBankItem itemPrefab;

		private Action onBack;

		public void Cancel()
		{
			MainScreenComponent.Instance.ClearOnBackOverride();
			GetComponent<Animator>().SetTrigger("cancel");
		}

		public void setOrderId(string orderId)
		{
			label.text = "Sipariş numaranız: " + orderId;
		}

		public void setBanksData(PayguruAbbreviatedBankInfo[] banksInfo)
		{
			foreach (PayguruAbbreviatedBankInfo bank in banksInfo)
			{
				PayguruBankItem payguruBankItem = UnityEngine.Object.Instantiate(itemPrefab);
				payguruBankItem.transform.SetParent(scrollRect.content, false);
				payguruBankItem.gameObject.SetActive(true);
				payguruBankItem.Init(bank);
			}
		}
	}
}
