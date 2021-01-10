using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class DealItemContent : LocalizedControl
	{
		public TextMeshProUGUI title;
		public TextMeshProUGUI description;
		public ImageSkin banner;
		public TextMeshProUGUI price;
		public int order;
		public bool canFillBigRow;
		public bool canFillSmallRow;
	}
}
