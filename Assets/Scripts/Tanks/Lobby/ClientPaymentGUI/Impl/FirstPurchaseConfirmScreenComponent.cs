using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientNavigation.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class FirstPurchaseConfirmScreenComponent : LocalizedScreenComponent, PaymentScreen
	{
		private long compensation;

		[SerializeField]
		private Text info;

		[SerializeField]
		private Text confirmButton;

		[SerializeField]
		private PaletteColorField color;

		[SerializeField]
		private GameObject overlay;

		[SerializeField]
		private CanvasGroup content;

		public string ConfirmationText
		{
			private get;
			set;
		}

		public long Compensation
		{
			get
			{
				return compensation;
			}
			set
			{
				compensation = value;
				info.text = string.Format(ConfirmationText, string.Format("<color=#{0}>{1}</color>", color.Color.ToHexString(), compensation));
				content.interactable = true;
				overlay.SetActive(false);
			}
		}

		public string ConfirmButton
		{
			set
			{
				confirmButton.text = value;
			}
		}

		private void OnDisable()
		{
			info.text = string.Empty;
			content.interactable = false;
			overlay.SetActive(true);
		}
	}
}
