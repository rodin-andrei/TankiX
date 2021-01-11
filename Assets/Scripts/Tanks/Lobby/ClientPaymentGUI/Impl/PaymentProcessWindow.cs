using Platform.Kernel.ECS.ClientEntitySystem.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class PaymentProcessWindow : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI info;

		public void Show(Entity item, Entity method)
		{
			base.gameObject.SetActive(true);
			info.text = ShopDialogs.FormatItem(item, method);
		}
	}
}
