using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class PopupDialogComponent : ConfirmDialogComponent
	{
		public RectTransform itemsContainer;
		public LeagueEntranceItemComponent itemPrefab;
		public float itemsShowDelay;
		public ImageSkin leagueIcon;
		public TextMeshProUGUI headerText;
		public TextMeshProUGUI text;
		public TextMeshProUGUI rewardHeader;
		public TextMeshProUGUI buttonText;
	}
}
