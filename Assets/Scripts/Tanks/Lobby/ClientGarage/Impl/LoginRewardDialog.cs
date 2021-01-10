using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class LoginRewardDialog : ConfirmDialogComponent
	{
		public RectTransform itemsContainer;
		public ReleaseGiftItemComponent itemPrefab;
		public float itemsShowDelay;
		public ImageSkin leagueIcon;
		public TextMeshProUGUI headerText;
		public TextMeshProUGUI text;
		public LoginRewardAllItemsContainer allItems;
		[SerializeField]
		private LocalizedField paint;
		[SerializeField]
		private LocalizedField coating;
		[SerializeField]
		private LocalizedField dayShort;
		[SerializeField]
		private LocalizedField container;
		[SerializeField]
		private LocalizedField premium;
	}
}
