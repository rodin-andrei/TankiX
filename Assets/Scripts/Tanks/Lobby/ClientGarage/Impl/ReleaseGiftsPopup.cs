using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ReleaseGiftsPopup : ConfirmDialogComponent
	{
		public RectTransform itemsContainer;
		public ReleaseGiftItemComponent itemPrefab;
		public float itemsShowDelay;
		public ImageSkin leagueIcon;
		public TextMeshProUGUI headerText;
		public TextMeshProUGUI text;
	}
}
