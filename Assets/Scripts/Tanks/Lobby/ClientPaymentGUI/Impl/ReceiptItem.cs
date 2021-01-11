using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class ReceiptItem : MonoBehaviour
	{
		[SerializeField]
		private new Text name;

		[SerializeField]
		private Text amount;

		public void Init(string name, long amount)
		{
			this.name.text = name;
			this.amount.text = amount.ToStringSeparatedByThousands();
		}
	}
}
