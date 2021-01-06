using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class LeagueCarouselUIComponent : BehaviourComponent
	{
		[SerializeField]
		private LeagueTitleUIComponent leagueTitlePrefab;
		[SerializeField]
		private RectTransform scrollContent;
		[SerializeField]
		private Button leftScrollButton;
		[SerializeField]
		private Button rightScrollButton;
		[SerializeField]
		private float autoScrollSpeed;
		[SerializeField]
		private float pageWidth;
		[SerializeField]
		private float pagesOffset;
		[SerializeField]
		private int pageCount;
		[SerializeField]
		private int currentPage;
		[SerializeField]
		private bool interactWithScrollView;
		[SerializeField]
		private LocalizedField leagueLocalizedField;
	}
}
