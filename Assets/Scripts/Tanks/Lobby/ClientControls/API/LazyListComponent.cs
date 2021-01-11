using System.Collections;
using log4net;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientLogger.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tanks.Lobby.ClientControls.API
{
	public class LazyListComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component, ILazyList, IScrollHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IEventSystemHandler
	{
		private const float EPSILON = 0.01f;

		[SerializeField]
		private ListItem itemPrefab;

		[SerializeField]
		private EntityBehaviour entityBehaviour;

		[SerializeField]
		private float itemMinSize = 100f;

		[SerializeField]
		private float spacing;

		[SerializeField]
		private bool vertical;

		[SerializeField]
		private bool noScroll;

		[SerializeField]
		private float itemScrollTime = 0.2f;

		private ILog log;

		private RectTransform rectTransform;

		private Canvas canvas;

		private float position;

		private float targetPosition;

		private int targetItemIndex;

		private int itemsCount;

		private IndexRange visibleItemsRange;

		private IndexRange screenRange;

		private float pageSize;

		private float prevPageSize;

		private int itemsPerPage;

		private float itemSize;

		private float allContentSize;

		private bool dragging;

		private bool dragDirectionPositive;

		private bool quiting;

		private bool forceNextUpdate = true;

		private int selectedItemIndex;

		private Entity selectedEntity;

		private bool inSelectMode;

		[Inject]
		public static EngineService EngineService
		{
			get;
			set;
		}

		public bool AtLimitLow
		{
			get;
			private set;
		}

		public bool AtLimitHigh
		{
			get;
			private set;
		}

		public int ItemsCount
		{
			get
			{
				return itemsCount;
			}
			set
			{
				if (itemsCount != value)
				{
					itemsCount = value;
					Layout();
				}
			}
		}

		public IndexRange VisibleItemsRange
		{
			get
			{
				return visibleItemsRange;
			}
		}

		public RectTransform GetItemContent(int itemIndex)
		{
			RectTransform item = GetItem(itemIndex);
			if (item != null)
			{
				return item.GetComponent<ListItem>().GetContent();
			}
			return null;
		}

		public void SetItemContent(int itemIndex, RectTransform content)
		{
			log.DebugFormat("SetItemContent itemIndex={0}", itemIndex);
			RectTransform item = GetItem(itemIndex);
			if (item != null)
			{
				item.GetComponent<ListItem>().SetContent(content);
			}
		}

		public void UpdateSelection(int itemIndex)
		{
			if (itemIndex == selectedItemIndex)
			{
				SelectItemContent();
			}
		}

		public void OnRemoveItemContent(int itemIndex)
		{
			log.DebugFormat("OnRemoveItemContent itemIndex={0}", itemIndex);
			if (itemIndex == selectedItemIndex)
			{
				UnselectItemContent();
			}
		}

		public void Scroll(int deltaItems)
		{
			targetItemIndex += deltaItems;
			ClampTargetItemIndex();
			targetPosition = GetItemStartPosition(targetItemIndex);
			ClampPosition();
		}

		public void ClearItems()
		{
			UnselectItemContent();
			UpdateVisibility(default(IndexRange), CalculateScreenRange(), false);
			screenRange = default(IndexRange);
			itemsCount = 0;
			position = 0f;
			targetPosition = 0f;
			targetItemIndex = 0;
			dragging = false;
			selectedItemIndex = 0;
		}

		private void OnApplicationQuit()
		{
			quiting = true;
		}

		protected override void Awake()
		{
			log = LoggerProvider.GetLogger(this);
			rectTransform = GetComponent<RectTransform>();
			canvas = GetComponentInParent<Canvas>();
		}

		private void Update()
		{
			if (!AtTarget() || IsSizeChanged() || dragging || forceNextUpdate)
			{
				forceNextUpdate = false;
				Layout();
			}
		}

		private void OnGUI()
		{
			if (UnityEngine.Event.current.type == EventType.KeyDown && !inSelectMode)
			{
				float horizontal = InputMapping.Horizontal;
				if (horizontal > 0f)
				{
					StartCoroutine(DelaySelection(1));
				}
				else if (horizontal < 0f)
				{
					StartCoroutine(DelaySelection(-1));
				}
			}
		}

		private IEnumerator DelaySelection(int dir)
		{
			if (inSelectMode)
			{
				yield break;
			}
			int newIndex = selectedItemIndex + dir;
			if (newIndex >= itemsCount || newIndex < 0)
			{
				yield break;
			}
			inSelectMode = true;
			int index = ItemIndexToChildIndex(newIndex);
			float waitTime2 = 0f;
			if (index == -1)
			{
				Scroll(dir);
				while (index == -1)
				{
					yield return new WaitForEndOfFrame();
					index = ItemIndexToChildIndex(newIndex);
					waitTime2 += Time.deltaTime;
					if (waitTime2 > 1f)
					{
						inSelectMode = false;
						yield break;
					}
				}
			}
			waitTime2 = 0f;
			while (GetItemContent(newIndex) == null)
			{
				yield return new WaitForEndOfFrame();
				waitTime2 += Time.deltaTime;
				if (waitTime2 > 1f)
				{
					inSelectMode = false;
					yield break;
				}
			}
			GetItem(newIndex).GetComponent<ListItem>().Select();
			inSelectMode = false;
		}

		private void Layout()
		{
			bool sizeChanged = IsSizeChanged();
			UpdatePageSizes();
			UpdatePagePosition(sizeChanged);
			UpdateVisibility(CalculateVisibleItemsRange(), CalculateScreenRange(), true);
			UpdateItemsPositionsAndSizes();
			SendScrollLimitEvent();
		}

		private bool IsSizeChanged()
		{
			return GetSize() != prevPageSize;
		}

		protected override void OnDisable()
		{
			if (!quiting)
			{
				ClearItems();
				forceNextUpdate = true;
			}
		}

		private void UpdatePageSizes()
		{
			pageSize = GetSize();
			itemsPerPage = GetItemsPerPage(itemMinSize, spacing, pageSize);
			itemSize = GetItemSize(pageSize, itemsPerPage, spacing);
			allContentSize = GetAllContentSize(itemsCount, itemSize, spacing);
			prevPageSize = pageSize;
		}

		private void UpdatePagePosition(bool sizeChanged)
		{
			if (sizeChanged)
			{
				targetPosition = GetItemStartPosition(targetItemIndex);
				position = targetPosition;
				ClampPosition();
				ClampTargetItemIndex();
			}
			if (position == targetPosition)
			{
				return;
			}
			float num = (itemSize + spacing) / itemScrollTime;
			if (position < targetPosition)
			{
				position += num * Time.deltaTime;
				if (position > targetPosition)
				{
					position = targetPosition;
				}
			}
			else
			{
				position -= num * Time.deltaTime;
				if (position < targetPosition)
				{
					position = targetPosition;
				}
			}
		}

		private void UpdateVisibility(IndexRange newVisibleItemsRange, IndexRange newScreenRange, bool canDestroyImmediate)
		{
			IndexRange removedLow;
			IndexRange removedHigh;
			IndexRange addedLow;
			IndexRange addedHigh;
			visibleItemsRange.CalculateDifference(newVisibleItemsRange, out removedLow, out removedHigh, out addedLow, out addedHigh);
			if (!canDestroyImmediate)
			{
			}
			if (newVisibleItemsRange != visibleItemsRange)
			{
				IndexRange prevRange = visibleItemsRange;
				visibleItemsRange = newVisibleItemsRange;
				int i = removedLow.Position;
				int num = 0;
				for (; i <= removedLow.EndPosition; i++)
				{
					if (!canDestroyImmediate)
					{
						num++;
					}
					OnItemInvisible(num, canDestroyImmediate);
				}
				int num2 = removedHigh.EndPosition;
				int num3 = rectTransform.childCount - 1;
				while (num2 >= removedHigh.Position)
				{
					OnItemInvisible(num3, canDestroyImmediate);
					num3--;
					num2--;
				}
				int num4 = addedLow.Position;
				int num5 = 0;
				while (num4 <= addedLow.EndPosition)
				{
					OnItemVisible(num5);
					num4++;
					num5++;
				}
				for (int j = addedHigh.Position; j <= addedHigh.EndPosition; j++)
				{
					OnItemVisible(rectTransform.childCount);
				}
				if (addedLow.Contains(selectedItemIndex) || addedHigh.Contains(selectedItemIndex))
				{
					RectTransform item = GetItem(selectedItemIndex);
					item.GetComponent<ListItem>().PlaySelectionAnimation();
				}
				EngineService.Engine.ScheduleEvent(new ItemsVisibilityChangedEvent(prevRange, visibleItemsRange), entityBehaviour.Entity);
			}
			if (newScreenRange != screenRange)
			{
				screenRange = newScreenRange;
				EngineService.Engine.ScheduleEvent(new ScreenRangeChangedEvent(screenRange), entityBehaviour.Entity);
			}
		}

		private IndexRange CalculateVisibleItemsRange()
		{
			if (itemsPerPage == 0)
			{
				return default(IndexRange);
			}
			int num = PositionToItemIndex(position + 0.01f);
			int num2 = PositionToItemIndex(position + pageSize - 0.01f);
			if (num >= 0 && num2 == -1)
			{
				num2 = itemsCount - 1;
			}
			return IndexRange.CreateFromBeginAndEnd(num, num2);
		}

		private IndexRange CalculateScreenRange()
		{
			int num = PositionToItemIndexUnclamped(position + 0.01f);
			int endPosition = PositionToItemIndexUnclamped(position + pageSize - 0.01f);
			return IndexRange.CreateFromBeginAndEnd(num, endPosition);
		}

		private void UpdateItemsPositionsAndSizes()
		{
			int num = visibleItemsRange.Position;
			int num2 = 0;
			while (num <= visibleItemsRange.EndPosition)
			{
				RectTransform rectTransform = (RectTransform)this.rectTransform.GetChild(num2);
				Vector2 sizeDelta = rectTransform.sizeDelta;
				sizeDelta[GetAxis()] = itemSize;
				rectTransform.sizeDelta = sizeDelta;
				Vector2 anchoredPosition = rectTransform.anchoredPosition;
				anchoredPosition[GetAxis()] = GetItemCenterPosition(num) - position;
				rectTransform.anchoredPosition = anchoredPosition;
				num++;
				num2++;
			}
		}

		private void SendScrollLimitEvent()
		{
			bool flag = position <= 0.01f;
			bool flag2 = position >= allContentSize - pageSize - 0.01f;
			if (flag != AtLimitLow || flag2 != AtLimitHigh)
			{
				AtLimitLow = flag;
				AtLimitHigh = flag2;
				EngineService.Engine.ScheduleEvent<ScrollLimitEvent>(entityBehaviour.Entity);
			}
		}

		private void OnItemSelect(ListItem listItem)
		{
			SelectItem(listItem);
			SelectItemContent();
		}

		private void SelectItem(ListItem listItem)
		{
			int num = selectedItemIndex;
			selectedItemIndex = ChildIndexToItemIndex(listItem.transform.GetSiblingIndex());
			log.DebugFormat("SelectItem prevSelectedItemIndex={0} selectedItemIndex={1}", num, selectedItemIndex);
			RectTransform item = GetItem(num);
			if (item != null)
			{
				item.GetComponent<ListItem>().PlayDeselectionAnimation();
			}
			RectTransform item2 = GetItem(selectedItemIndex);
			if (item2 != null)
			{
				item2.GetComponent<ListItem>().PlaySelectionAnimation();
			}
		}

		private void SelectItemContent()
		{
			log.DebugFormat("SelectItemContent OUTER selectedItemIndex={0}", selectedItemIndex);
			RectTransform itemContent = GetItemContent(selectedItemIndex);
			Entity entity = GetEntity(itemContent);
			if (entity != selectedEntity)
			{
				UnselectItemContent();
				if (entity != null)
				{
					selectedEntity = entity;
					log.DebugFormat("SelectItemContent INNER selectedEntity={0}", entity);
					entity.AddComponent<SelectedListItemComponent>();
				}
			}
		}

		private void UnselectItemContent()
		{
			log.DebugFormat("UnselectItemContent OUTER selectedEntity={0}", selectedEntity);
			if (selectedEntity != null)
			{
				Entity entity = selectedEntity;
				selectedEntity = null;
				log.DebugFormat("UnselectItemContent INNER selectedEntity={0}", entity);
				if (entity.HasComponent<SelectedListItemComponent>() && !entity.HasComponent<DeletedEntityComponent>())
				{
					entity.RemoveComponent<SelectedListItemComponent>();
				}
			}
		}

		public void OnScroll(PointerEventData eventData)
		{
			if (!noScroll)
			{
				if (eventData.scrollDelta.y > 0f)
				{
					Scroll(-1);
				}
				else
				{
					Scroll(1);
				}
			}
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (!noScroll)
			{
				float num = eventData.delta[GetAxis()] / canvas.scaleFactor;
				position -= num;
				dragDirectionPositive = num >= 0f;
				targetPosition = position;
				ClampPosition();
			}
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			if (!noScroll)
			{
				targetPosition = position;
				dragging = true;
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (!noScroll)
			{
				dragging = false;
				targetItemIndex = PositionToItemIndex(position);
				if (!dragDirectionPositive)
				{
					targetItemIndex++;
				}
				targetPosition = GetItemStartPosition(targetItemIndex);
				ClampPosition();
			}
		}

		private void OnItemInvisible(int childIndex, bool canDestroyImmediate)
		{
			log.DebugFormat("OnItemInvisible childIndex={0}", childIndex);
			Transform child = rectTransform.GetChild(childIndex);
			if (canDestroyImmediate)
			{
				Object.DestroyImmediate(child.gameObject);
			}
			else
			{
				Object.Destroy(child.gameObject);
			}
		}

		private void OnItemVisible(int childIndex)
		{
			log.DebugFormat("OnItemVisible childIndex={0}", childIndex);
			ListItem listItem = CreateItem();
			listItem.transform.SetSiblingIndex(childIndex);
		}

		private bool AtTarget()
		{
			return position == targetPosition;
		}

		private void ClampPosition()
		{
			if (targetPosition > allContentSize - pageSize)
			{
				targetPosition = allContentSize - pageSize;
				if (position > targetPosition)
				{
					position = targetPosition;
				}
			}
			if (targetPosition < 0f)
			{
				targetPosition = 0f;
				if (position < 0f)
				{
					position = 0f;
				}
			}
		}

		private void ClampTargetItemIndex()
		{
			if (targetItemIndex + itemsPerPage > itemsCount)
			{
				targetItemIndex = itemsCount - itemsPerPage;
			}
			if (targetItemIndex < 0)
			{
				targetItemIndex = 0;
			}
		}

		private int ItemIndexToChildIndex(int itemIndex)
		{
			if (!IsItemVisible(itemIndex))
			{
				return -1;
			}
			return itemIndex - visibleItemsRange.Position;
		}

		private bool IsItemVisible(int itemIndex)
		{
			return visibleItemsRange.Contains(itemIndex);
		}

		private int ChildIndexToItemIndex(int childIndex)
		{
			return childIndex + visibleItemsRange.Position;
		}

		public RectTransform GetItem(int itemIndex)
		{
			int num = ItemIndexToChildIndex(itemIndex);
			if (num != -1)
			{
				return (RectTransform)rectTransform.GetChild(num);
			}
			return null;
		}

		private ListItem CreateItem()
		{
			ListItem listItem = Object.Instantiate(itemPrefab);
			listItem.transform.SetParent(rectTransform, false);
			return listItem;
		}

		private static Entity GetEntity(Transform content)
		{
			if (content != null)
			{
				EntityBehaviour component = content.GetComponent<EntityBehaviour>();
				if (component != null)
				{
					return component.Entity;
				}
			}
			return null;
		}

		private int PositionToItemIndex(float pos)
		{
			if (itemsCount == 0)
			{
				return -1;
			}
			float num = itemSize + spacing;
			int num2 = -1;
			if (pos >= num)
			{
				num2 = 1 + Mathf.FloorToInt((pos - num) / num);
			}
			else if (pos > 0f)
			{
				num2 = 0;
			}
			if (num2 > itemsCount - 1)
			{
				num2 = -1;
			}
			return num2;
		}

		private int PositionToItemIndexUnclamped(float pos)
		{
			if (itemsPerPage == 0)
			{
				return 0;
			}
			float num = itemSize + spacing;
			float f = pos / num;
			return Mathf.FloorToInt(f);
		}

		private float GetItemCenterPosition(int itemIndex)
		{
			return GetItemStartPosition(itemIndex) + itemSize / 2f;
		}

		private float GetItemStartPosition(int itemIndex)
		{
			return (float)itemIndex * (itemSize + spacing);
		}

		private float GetSize()
		{
			float num = rectTransform.rect.size[GetAxis()];
			if (num < 0f)
			{
				return 0f;
			}
			return num;
		}

		private int GetAxis()
		{
			return vertical ? 1 : 0;
		}

		private static float GetAllContentSize(int itemsCount, float itemSize, float spacing)
		{
			float num = (float)itemsCount * (itemSize + spacing);
			if (itemsCount > 1)
			{
				num -= spacing;
			}
			return num;
		}

		private static float GetItemSize(float pageSize, int itemsPerPage, float spacing)
		{
			if (itemsPerPage > 0)
			{
				return (pageSize - spacing * (float)(itemsPerPage - 1)) / (float)itemsPerPage;
			}
			return 0f;
		}

		private static int GetItemsPerPage(float itemsMinSize, float spacing, float pageSize)
		{
			if (itemsMinSize > 0f)
			{
				if (itemsMinSize <= pageSize)
				{
					float num = pageSize - itemsMinSize;
					float num2 = itemsMinSize + spacing;
					return 1 + Mathf.FloorToInt(num / num2);
				}
			}
			return 0;
		}
	}
}
