using Tanks.Lobby.ClientNavigation.API;
using UnityEngine.UI;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class FirstPurchaseConfirmScreenComponent : LocalizedScreenComponent
	{
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
	}
}
