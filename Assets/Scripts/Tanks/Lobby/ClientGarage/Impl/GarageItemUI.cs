using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class GarageItemUI : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		private Carousel carousel;

		[SerializeField]
		private ImageSkin preview;

		[SerializeField]
		private ImageSkin shadow;

		private bool state;

		public RectTransform RectTransform
		{
			get
			{
				return GetComponent<RectTransform>();
			}
		}

		public GarageItem Item
		{
			get;
			private set;
		}

		public void Init(GarageItem item, Carousel carousel)
		{
			Item = item;
			preview.SpriteUid = item.Preview;
			shadow.SpriteUid = item.Preview;
			state = false;
			this.carousel = carousel;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (!TutorialCanvas.Instance.IsShow)
			{
				carousel.Select(Item);
			}
		}

		public void Select()
		{
			state = true;
			GetComponent<Animator>().SetBool("Selected", state);
			this.SendEvent<ListItemSelectedEvent>((Item.UserItem == null) ? Item.MarketItem : Item.UserItem);
		}

		public void Deselect()
		{
			state = false;
			if (base.gameObject.activeInHierarchy)
			{
				GetComponent<Animator>().SetBool("Selected", state);
			}
		}

		private void OnEnable()
		{
			GetComponent<Animator>().SetBool("Selected", state);
		}
	}
}
