using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class EventContainerPopupComponent : ConfirmDialogComponent
	{
		public RectTransform itemsContainer;
		public EventContainerItemComponent itemPrefab;
		public float itemsShowDelay;
		public ImageSkin leagueIcon;
		public TextMeshProUGUI headerText;
		public TextMeshProUGUI text;
	}
}
