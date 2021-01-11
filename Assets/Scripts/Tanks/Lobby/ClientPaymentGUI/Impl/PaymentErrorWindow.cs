using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class PaymentErrorWindow : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI info;

		private Action onHide;

		public void Show(Entity item, Entity method, Action onHide)
		{
			this.onHide = onHide;
			base.gameObject.SetActive(true);
			info.text = ShopDialogs.FormatItem(item, method);
		}

		public void Hide()
		{
			GetComponent<Animator>().SetTrigger("cancel");
			onHide();
		}
	}
}
