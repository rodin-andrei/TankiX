using System.Collections.Generic;
using System.Linq;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	public class SimpleHorizontalListComponent : MonoBehaviour, IScrollHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, Platform.Kernel.ECS.ClientEntitySystem.API.Component, IEventSystemHandler
	{
		[SerializeField]
		private RectTransform horizontalLayoutGroup;

		[SerializeField]
		private RectTransform leftButtonPlace;

		[SerializeField]
		private RectTransform rightButtonPlace;

		[SerializeField]
		private RectTransform content;

		[SerializeField]
		private RectTransform scrollRect;

		[SerializeField]
		private ListItem itemPrefab;

		[SerializeField]
		private EntityBehaviour itemContentPrefab;

		[SerializeField]
		private RectTransform navigationButtonPrefab;

		[SerializeField]
		private float navigationButtonsScrollTime = 0.3f;

		private ItemsMap items = new ItemsMap();

		private ListItem selectedItem;

		private RectTransform leftButton;

		private RectTransform rightButton;

		private float spaceBetweenNavigationButtons;

		private float spaceBetweenElements;

		private float position;

		private float velocity;

		private float navigationButtonsScrollVelocity;

		private int targetItemIndex;

		private int previousScrollRectWidth;

		private int calculatedItemWidth;

		private bool animating;

		private bool noScroll;

		private bool needDestroyNavigationButton;

		private float dragDirection;

		private Canvas canvas;

		private bool draging;

		private bool isKeyboardNavigationAllowed = true;

		private SimpleHorizontalListItemsSorter sorter;

		private bool checkedSorter;

		[Inject]
		public static EngineServiceInternal EngineService
		{
			get;
			set;
		}

		private RectTransform RectTransform
		{
			get
			{
				return (RectTransform)base.transform;
			}
		}

		public SimpleHorizontalListItemsSorter Sorter
		{
			get
			{
				if (sorter == null && !checkedSorter)
				{
					sorter = GetComponent<SimpleHorizontalListItemsSorter>();
					checkedSorter = true;
				}
				return sorter;
			}
		}

		public bool IsKeyboardNavigationAllowed
		{
			get
			{
				return isKeyboardNavigationAllowed;
			}
			set
			{
				isKeyboardNavigationAllowed = value;
			}
		}

		public int Count
		{
			get
			{
				return items.Count;
			}
		}

		public ICollection<Entity> GetItems()
		{
			return items.Select((ListItem item) => (Entity)item.Data).ToList();
		}

		public GameObject GetItem(Entity entity)
		{
			return items[entity].gameObject;
		}

		public void AddItem(Entity entity)
		{
			EntityBehaviour entityBehaviour = Object.Instantiate(itemContentPrefab);
			ListItem listItem = Object.Instantiate(itemPrefab);
			listItem.SetContent((RectTransform)entityBehaviour.transform);
			listItem.transform.SetParent(content, false);
			listItem.Data = entity;
			items.Add(listItem);
			entityBehaviour.BuildEntity(entity);
			if (Sorter != null)
			{
				Sorter.Sort(items);
				int num = 0;
				foreach (ListItem item in items)
				{
					item.transform.SetSiblingIndex(num++);
				}
			}
			else
			{
				listItem.transform.SetAsLastSibling();
			}
			Layout();
		}

		public void RemoveItem(Entity entity)
		{
			if (!items.Contains(entity))
			{
				throw new ItemNotExistsException(entity);
			}
			ListItem listItem = items[entity];
			if (selectedItem == listItem)
			{
				selectedItem = null;
			}
			items.Remove(entity);
			EntityBehaviour.CleanUp(listItem.gameObject);
			Object.DestroyImmediate(listItem.gameObject);
			Layout();
		}

		public bool Contains(Entity entity)
		{
			return items.Contains(entity);
		}

		public void Select(Entity entity)
		{
			if (!items.Contains(entity))
			{
				throw new ItemNotExistsException(entity);
			}
			OnItemSelect(items[entity]);
			items[entity].Select();
		}

		public void MoveToItem(Entity entity)
		{
			targetItemIndex = items[entity].transform.GetSiblingIndex();
			velocity = navigationButtonsScrollVelocity;
			SetPositionToTarget();
			ClearHighlight();
		}

		public void MoveToItem(GameObject obj)
		{
			Entity entity = obj.GetComponentInParent<EntityBehaviour>().Entity;
			if (items.Contains(entity))
			{
				MoveToItem(entity);
			}
		}

		public void MoveToItemAnimated(object entity)
		{
			targetItemIndex = items[entity].transform.GetSiblingIndex();
			velocity = navigationButtonsScrollVelocity;
		}

		public void ClearItems(bool immediate = false)
		{
			foreach (ListItem item in items)
			{
				EntityBehaviour.CleanUp(item.gameObject);
				if (immediate)
				{
					Object.DestroyImmediate(item.gameObject);
				}
				else
				{
					Object.Destroy(item.gameObject);
				}
			}
			items.Clear();
			selectedItem = null;
			position = 0f;
			targetItemIndex = 0;
			velocity = 0f;
			animating = false;
			ApplyPosition();
		}

		public int GetIndex(Entity entity)
		{
			return items[entity].transform.GetSiblingIndex();
		}

		public void SetIndex(Entity entity, int index)
		{
			items[entity].transform.SetSiblingIndex(index);
		}

		private void Awake()
		{
			spaceBetweenNavigationButtons = horizontalLayoutGroup.GetComponent<SimpleHorizontalLayoutGroup>().spacing;
			previousScrollRectWidth = (int)scrollRect.rect.width;
			float width = navigationButtonPrefab.rect.width;
			leftButtonPlace.GetComponent<SimpleLayoutElement>().maxWidth = width;
			rightButtonPlace.GetComponent<SimpleLayoutElement>().maxWidth = width;
		}

		private void Start()
		{
			Layout();
		}

		private void Layout()
		{
			LayoutElement component = itemPrefab.GetComponent<LayoutElement>();
			int count = items.Count;
			calculatedItemWidth = CalculateItemWidth();
			float minWidth = component.minWidth;
			spaceBetweenElements = content.GetComponent<HorizontalLayoutGroup>().spacing;
			int num = (int)(minWidth * (float)count + spaceBetweenElements * (float)(count - 1));
			if ((float)num > RectTransform.rect.width)
			{
				LayoutWithNavigationButtons();
			}
			else
			{
				LayoutWithoutNavigationButtons();
				if (component.preferredWidth > 0f)
				{
					calculatedItemWidth = Mathf.Min(calculatedItemWidth, (int)component.preferredWidth);
				}
			}
			ExtendItemsWidth(calculatedItemWidth);
			navigationButtonsScrollVelocity = ((float)calculatedItemWidth + spaceBetweenElements) / navigationButtonsScrollTime;
		}

		private void LayoutWithNavigationButtons()
		{
			noScroll = false;
			horizontalLayoutGroup.GetComponent<SimpleHorizontalLayoutGroup>().spacing = spaceBetweenNavigationButtons;
			leftButtonPlace.GetComponent<SimpleLayoutElement>().flexibleWidth = 1f;
			rightButtonPlace.GetComponent<SimpleLayoutElement>().flexibleWidth = 1f;
			CreateNavigationButtons();
		}

		private void CreateNavigationButtons()
		{
			if (leftButton == null)
			{
				leftButton = Object.Instantiate(navigationButtonPrefab);
				InitNavigationButton(leftButton, leftButtonPlace.transform, -1, OnLeftButtonClick);
			}
			if (rightButton == null)
			{
				rightButton = Object.Instantiate(navigationButtonPrefab);
				InitNavigationButton(rightButton, rightButtonPlace.transform, 1, OnRightButtonClick);
			}
		}

		private void InitNavigationButton(RectTransform button, Transform parent, int scale, UnityAction clickHandler)
		{
			button.GetComponent<Button>().onClick.AddListener(clickHandler);
			button.SetParent(parent, false);
			button.localScale = new Vector3(scale, 1f, 1f);
			button.pivot = new Vector2(0.5f - (float)scale * 0.5f, 0.5f);
			button.anchorMin = new Vector2(0f, 0.5f);
			button.anchorMax = new Vector2(0f, 0.5f);
		}

		private void OnLeftButtonClick()
		{
			if (targetItemIndex > 0)
			{
				if (targetItemIndex > GetMaxTargetIndex())
				{
					targetItemIndex = GetMaxTargetIndex();
				}
				targetItemIndex--;
				velocity = navigationButtonsScrollVelocity;
			}
		}

		private void OnRightButtonClick()
		{
			if (targetItemIndex < GetMaxTargetIndex())
			{
				targetItemIndex++;
				velocity = navigationButtonsScrollVelocity;
			}
		}

		private float GetMinPosition()
		{
			return Mathf.Min(0f, scrollRect.rect.width - (float)CalculateItemsWidth(items.Count, calculatedItemWidth));
		}

		private int GetMaxTargetIndex()
		{
			float minPosition = GetMinPosition();
			return PositionToItemIndex(minPosition);
		}

		private void LayoutWithoutNavigationButtons()
		{
			noScroll = true;
			needDestroyNavigationButton = true;
			ClearHighlight();
			horizontalLayoutGroup.GetComponent<SimpleHorizontalLayoutGroup>().spacing = 0f;
			leftButtonPlace.GetComponent<SimpleLayoutElement>().flexibleWidth = 0f;
			rightButtonPlace.GetComponent<SimpleLayoutElement>().flexibleWidth = 0f;
			targetItemIndex = 0;
			position = 0f;
			ApplyPosition();
		}

		private int CalculateItemWidth()
		{
			float minWidth = itemPrefab.GetComponent<LayoutElement>().minWidth;
			int i;
			for (i = 1; (float)CalculateItemsWidth(i + 1, minWidth) < scrollRect.rect.width; i++)
			{
			}
			i = Mathf.Min(i, items.Count);
			int num = CalculateItemsWidth(i, minWidth);
			int num2 = (int)((scrollRect.rect.width - (float)num) / (float)i);
			return (int)(minWidth + (float)num2);
		}

		private void ExtendItemsWidth(int newItemWidth)
		{
			foreach (ListItem item in items)
			{
				item.GetComponent<LayoutElement>().minWidth = newItemWidth;
			}
		}

		private void OnGUI()
		{
			if (needDestroyNavigationButton)
			{
				needDestroyNavigationButton = false;
				DestroyNavigationButtons();
			}
			if (!previousScrollRectWidth.Equals((int)scrollRect.rect.width))
			{
				previousScrollRectWidth = (int)scrollRect.rect.width;
				Layout();
				SetPositionToTarget();
			}
			if (isKeyboardNavigationAllowed && !noScroll && UnityEngine.Event.current.type == EventType.KeyDown)
			{
				float horizontal = InputMapping.Horizontal;
				int num = -1;
				if (horizontal > 0f)
				{
					num = selectedItem.transform.GetSiblingIndex() + 1;
				}
				else if (horizontal < 0f)
				{
					num = selectedItem.transform.GetSiblingIndex() - 1;
				}
				if (num >= 0 && num < content.childCount)
				{
					Transform child = content.GetChild(num);
					child.GetComponent<ListItem>().Select();
					MoveToItemAnimated(child.GetComponent<ListItem>().Data);
				}
			}
		}

		private void SetPositionToTarget()
		{
			position = ItemIndexToPosition(CorrectIndex(targetItemIndex));
			ApplyPosition();
		}

		private float ItemIndexToPosition(int itemIndex)
		{
			return (float)(-itemIndex) * ((float)calculatedItemWidth + spaceBetweenElements);
		}

		private void DestroyNavigationButtons()
		{
			if (leftButton != null)
			{
				Object.Destroy(leftButton.gameObject);
				leftButton = null;
			}
			if (rightButton != null)
			{
				Object.Destroy(rightButton.gameObject);
				rightButton = null;
			}
		}

		private int CalculateItemsWidth(int count, float itemWidth)
		{
			return (int)(itemWidth * (float)count + spaceBetweenElements * (float)(count - 1));
		}

		private void Update()
		{
			if (draging)
			{
				return;
			}
			int itemIndex = CorrectIndex(targetItemIndex);
			float num = ItemIndexToPosition(itemIndex);
			if (position == num)
			{
				return;
			}
			if (!animating)
			{
				animating = true;
				content.GetComponent<CanvasGroup>().blocksRaycasts = false;
			}
			if (position < num)
			{
				position += velocity * Time.deltaTime;
				if (position > num)
				{
					position = num;
					ClearHighlight();
				}
				ApplyPosition();
			}
			else
			{
				position -= velocity * Time.deltaTime;
				if (position < num)
				{
					position = num;
					ClearHighlight();
				}
				ApplyPosition();
			}
		}

		private void ClearHighlight()
		{
			animating = false;
			content.GetComponent<CanvasGroup>().blocksRaycasts = true;
		}

		private void OnBaseElementSizeChanged()
		{
			Layout();
			ToNearestItem();
		}

		private void ToNearestItem()
		{
			float num = position % ((float)calculatedItemWidth + spaceBetweenElements);
			targetItemIndex = ((!(dragDirection < 0f)) ? PositionToItemIndex(position - num) : PositionToItemIndex(position - ((float)calculatedItemWidth + spaceBetweenElements + num)));
			velocity = navigationButtonsScrollVelocity;
			ApplyPosition();
		}

		private void ApplyPosition()
		{
			position = ClampPosition(position);
			content.anchoredPosition = new Vector2(position, 0f);
			UpdateNavigationButtonsVisibility();
		}

		private float ClampPosition(float pos)
		{
			if (pos >= 0f)
			{
				return 0f;
			}
			float minPosition = GetMinPosition();
			if (pos < minPosition)
			{
				return minPosition;
			}
			return pos;
		}

		private void OnItemSelect(ListItem item)
		{
			if (selectedItem != null)
			{
				selectedItem.PlayDeselectionAnimation();
			}
			selectedItem = item;
			EngineService.Engine.ScheduleEvent<ListItemSelectedEvent>((Entity)selectedItem.Data);
		}

		private void UpdateNavigationButtonsVisibility()
		{
			if (leftButton != null)
			{
				leftButton.gameObject.SetActive(position < 0f);
			}
			if (rightButton != null)
			{
				float num = scrollRect.rect.width - (float)CalculateItemsWidth(items.Count, calculatedItemWidth);
				rightButton.gameObject.SetActive(position > num);
			}
		}

		public void OnScroll(PointerEventData eventData)
		{
			if (!noScroll && !draging)
			{
				if (eventData.scrollDelta.y > 0f)
				{
					OnLeftButtonClick();
				}
				else
				{
					OnRightButtonClick();
				}
			}
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (!noScroll)
			{
				if (canvas == null)
				{
					BaseElementCanvasScaler componentInParent = GetComponentInParent<BaseElementCanvasScaler>();
					canvas = componentInParent.GetComponent<Canvas>();
				}
				float num = eventData.delta.x / canvas.scaleFactor;
				position += num;
				dragDirection += num;
				ApplyPosition();
			}
		}

		private int CorrectIndex(int index)
		{
			if (index < 0)
			{
				return 0;
			}
			int maxTargetIndex = GetMaxTargetIndex();
			if (index > maxTargetIndex)
			{
				return maxTargetIndex;
			}
			return index;
		}

		private int PositionToItemIndex(float pos)
		{
			return Mathf.RoundToInt((0f - pos) / ((float)calculatedItemWidth + spaceBetweenElements));
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			if (!noScroll)
			{
				draging = true;
				dragDirection = 0f;
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (!noScroll)
			{
				draging = false;
				ToNearestItem();
				ClearHighlight();
			}
		}
	}
}
