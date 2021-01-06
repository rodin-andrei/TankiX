using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class VisualItemUIContent : MonoBehaviour
	{
		[SerializeField]
		private new TextMeshProUGUI name;
		[SerializeField]
		private ImageSkin preview;
		[SerializeField]
		private ListItemPrices prices;
		[SerializeField]
		private TextMeshProUGUI containerLabel;
		[SerializeField]
		private TextMeshProUGUI upgradesLabel;
		[SerializeField]
		private LocalizedField upgradesRequiredText;
		[SerializeField]
		private LocalizedField _commonString;
		[SerializeField]
		private LocalizedField _rareString;
		[SerializeField]
		private LocalizedField _epicString;
		[SerializeField]
		private LocalizedField _legendaryString;
	}
}
