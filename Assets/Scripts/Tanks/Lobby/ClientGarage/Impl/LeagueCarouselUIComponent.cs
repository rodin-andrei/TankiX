using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientUserProfile.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class LeagueCarouselUIComponent : BehaviourComponent
	{
		public CarouselItemSelected itemSelected;

		[SerializeField]
		private LeagueTitleUIComponent leagueTitlePrefab;

		[SerializeField]
		private RectTransform scrollContent;

		[SerializeField]
		private Button leftScrollButton;

		[SerializeField]
		private Button rightScrollButton;

		[SerializeField]
		private float autoScrollSpeed = 1f;

		[SerializeField]
		private float pageWidth = 400f;

		[SerializeField]
		private float pagesOffset = 20f;

		[SerializeField]
		private int pageCount;

		[SerializeField]
		private int currentPage = 1;

		[SerializeField]
		private bool interactWithScrollView;

		[SerializeField]
		private LocalizedField leagueLocalizedField;

		public LeagueTitleUIComponent CurrentLeague
		{
			get
			{
				return GetComponentsInChildren<LeagueTitleUIComponent>()[currentPage - 1];
			}
		}

		private void Start()
		{
			leftScrollButton.onClick.AddListener(ScrollLeft);
			rightScrollButton.onClick.AddListener(ScrollRight);
		}

		private void ScrollRight()
		{
			SelectPage(Mathf.Min(pageCount, currentPage + 1));
		}

		private void ScrollLeft()
		{
			SelectPage(Mathf.Max(1, currentPage - 1));
		}

		private void SelectPage(int page)
		{
			currentPage = page;
			interactWithScrollView = false;
			if (itemSelected != null)
			{
				itemSelected(CurrentLeague);
			}
			SetButtons();
		}

		private void SetButtons()
		{
			leftScrollButton.gameObject.SetActive(currentPage != 1);
			rightScrollButton.gameObject.SetActive(currentPage != GetComponentsInChildren<LeagueTitleUIComponent>().Length);
		}

		public LeagueTitleUIComponent AddLeagueItem(Entity entity)
		{
			return GetNewLeagueTitleLayout(entity);
		}

		private LeagueTitleUIComponent GetNewLeagueTitleLayout(Entity entity)
		{
			LeagueTitleUIComponent leagueTitleUIComponent = Object.Instantiate(leagueTitlePrefab);
			leagueTitleUIComponent.transform.SetParent(scrollContent, false);
			leagueTitleUIComponent.gameObject.SetActive(true);
			string name = entity.GetComponent<LeagueNameComponent>().Name + " " + leagueLocalizedField.Value;
			string spriteUid = entity.GetComponent<LeagueIconComponent>().SpriteUid;
			leagueTitleUIComponent.Name = name;
			leagueTitleUIComponent.Icon = spriteUid;
			return leagueTitleUIComponent;
		}

		private void Update()
		{
			if (!interactWithScrollView)
			{
				pageCount = scrollContent.childCount;
				Vector2 b = new Vector2((float)(-(currentPage - 1)) * pageWidth - pagesOffset, scrollContent.anchoredPosition.y);
				scrollContent.anchoredPosition = Vector2.Lerp(scrollContent.anchoredPosition, b, autoScrollSpeed * Time.deltaTime);
			}
		}

		public void SelectItem(Entity entity)
		{
			LeagueTitleUIComponent[] componentsInChildren = GetComponentsInChildren<LeagueTitleUIComponent>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].LeagueEntity.Equals(entity))
				{
					SelectPage(i + 1);
					return;
				}
			}
			SelectPage(1);
		}

		private void OnDisable()
		{
			Clear();
		}

		private void Clear()
		{
			scrollContent.DestroyChildren();
		}
	}
}
