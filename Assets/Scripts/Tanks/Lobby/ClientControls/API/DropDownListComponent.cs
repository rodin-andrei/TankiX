using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	public class DropDownListComponent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
	{
		public OnDropDownListItemSelected onDropDownListItemSelected;

		[SerializeField]
		protected TextMeshProUGUI listTitle;

		[SerializeField]
		protected DefaultListDataProvider dataProvider;

		[SerializeField]
		private float maxHeight = 210f;

		private RectTransform scrollRectContent;

		private RectTransform listRect;

		private bool isOpen;

		private bool pointerOver;

		private bool pointerOverContent;

		public object Selected
		{
			get
			{
				return dataProvider.Selected;
			}
			set
			{
				dataProvider.Selected = value;
				listTitle.text = Selected.ToString();
			}
		}

		public int SelectionIndex
		{
			get
			{
				return dataProvider.Data.IndexOf(Selected);
			}
			set
			{
				Selected = dataProvider.Data[value];
			}
		}

		protected bool IsOpen
		{
			get
			{
				return isOpen;
			}
			set
			{
				isOpen = value;
				CanvasGroup component = listRect.GetComponent<CanvasGroup>();
				component.alpha = ((!isOpen) ? 0f : 1f);
				component.interactable = isOpen;
				component.blocksRaycasts = isOpen;
			}
		}

		private void Awake()
		{
			ScrollRect componentInChildren = GetComponentInChildren<ScrollRect>();
			scrollRectContent = componentInChildren.content;
			listRect = componentInChildren.transform.parent.GetComponent<RectTransform>();
			GetComponent<Button>().onClick.AddListener(ClickAction);
			IsOpen = false;
		}

		public void ClickAction()
		{
			IsOpen = !IsOpen;
		}

		private void Update()
		{
			if (IsOpen)
			{
				float num = Mathf.Min(maxHeight, scrollRectContent.rect.height);
				if (listRect.sizeDelta.y != num)
				{
					listRect.sizeDelta = new Vector2(listRect.sizeDelta.x, num);
					scrollRectContent.anchoredPosition = Vector2.zero;
					scrollRectContent.GetComponentInChildren<DynamicVerticalList>().ScrollToSelection();
				}
				if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && !pointerOverContent && !pointerOver)
				{
					IsOpen = false;
				}
			}
			pointerOverContent = false;
		}

		protected virtual void OnItemSelect(ListItem item)
		{
			IsOpen = false;
			if (onDropDownListItemSelected != null)
			{
				onDropDownListItemSelected(item);
			}
		}

		protected virtual void PointerOverContentItem(ListItem item)
		{
			pointerOverContent = true;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			pointerOver = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			pointerOver = false;
		}
	}
}
