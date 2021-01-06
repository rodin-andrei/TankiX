using UnityEngine.UI;
using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class EnergyBonusContent : DealItemContent
	{
		[SerializeField]
		private Button button;
		[SerializeField]
		private GameObject goBackText;
		[SerializeField]
		private CanvasGroup bottom;
		[SerializeField]
		private Sprite activeBonusSprite;
		[SerializeField]
		private Sprite inactiveBonusSprite;
		[SerializeField]
		private Image bannerImage;
	}
}
