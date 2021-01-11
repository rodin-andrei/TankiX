using System;
using System.Collections.Generic;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientGarage.Impl.Tutorial;
using tanks.modules.lobby.ClientGarage.Scripts.API.UI.Items;
using tanks.modules.lobby.ClientGarage.Scripts.Impl.NewModules.UI.New.DragAndDrop;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class DragAndDropController : MonoBehaviour, IDropController
	{
		public TankPartCollectionView turretCollectionView;

		public TankPartCollectionView hullCollectionView;

		public CollectionView collectionView;

		public GameObject background;

		private bool changeSize;

		private DropDescriptor delayedDrop;

		public static float OVER_ITEM_Z_OFFSET = -7f;

		public Action<DropDescriptor, DropDescriptor> onDrop;

		public void Awake()
		{
			turretCollectionView.activeSlot.GetComponent<DragAndDropCell>().dropController = this;
			turretCollectionView.activeSlot2.GetComponent<DragAndDropCell>().dropController = this;
			turretCollectionView.passiveSlot.GetComponent<DragAndDropCell>().dropController = this;
			hullCollectionView.activeSlot.GetComponent<DragAndDropCell>().dropController = this;
			hullCollectionView.activeSlot2.GetComponent<DragAndDropCell>().dropController = this;
			hullCollectionView.passiveSlot.GetComponent<DragAndDropCell>().dropController = this;
			foreach (CollectionSlotView value in CollectionView.slots.Values)
			{
				value.GetComponent<DragAndDropCell>().dropController = this;
			}
		}

		public void OnEnable()
		{
			background.SetActive(false);
			DragAndDropItem.OnItemDragStartEvent += OnAnyItemDragStart;
			DragAndDropItem.OnItemDragEndEvent += OnAnyItemDragEnd;
		}

		public void OnDisable()
		{
			DragAndDropItem.OnItemDragStartEvent -= OnAnyItemDragStart;
			DragAndDropItem.OnItemDragEndEvent -= OnAnyItemDragEnd;
			CorrectFinishDrag();
		}

		private void Update()
		{
			if (changeSize)
			{
				changeSize = false;
				DragAndDropItem.draggedItemContentCopy.GetComponent<Animator>().SetBool("GrowUp", true);
			}
			if (delayedDrop.item != null)
			{
				OnDrop(delayedDrop.sourceCell, delayedDrop.destinationCell, delayedDrop.item);
				delayedDrop.sourceCell = null;
				delayedDrop.destinationCell = null;
				delayedDrop.item = null;
			}
		}

		private void OnAnyItemDragStart(DragAndDropItem item, PointerEventData eventData)
		{
			float oVER_SCREEN_Z_OFFSET = NewModulesScreenUIComponent.OVER_SCREEN_Z_OFFSET;
			if (!ModulesTutorialUtil.TUTORIAL_MODE)
			{
				background.SetActive(true);
				background.transform.SetAsLastSibling();
				Vector3 anchoredPosition3D = background.GetComponent<RectTransform>().anchoredPosition3D;
				anchoredPosition3D.z = oVER_SCREEN_Z_OFFSET * 0.5f - 0.01f;
				background.GetComponent<RectTransform>().anchoredPosition3D = anchoredPosition3D;
			}
			HighlightPossibleSlots();
			MoveDraggingCardInFronfOfAll(oVER_SCREEN_Z_OFFSET + OVER_ITEM_Z_OFFSET);
			DragAndDropItem.draggedItemContentCopy.transform.GetChild(0).GetComponent<Animator>().SetInteger("colorCode", 1);
			if (DragAndDropItem.sourceCell.GetComponent<SlotView>() is CollectionSlotView)
			{
				changeSize = true;
			}
		}

		private void OnAnyItemDragEnd(DragAndDropItem item, PointerEventData eventData)
		{
			background.SetActive(false);
			turretCollectionView.CancelHighlightForDrop();
			hullCollectionView.CancelHighlightForDrop();
			foreach (KeyValuePair<ModuleItem, CollectionSlotView> slot in CollectionView.slots)
			{
				CollectionSlotView value = slot.Value;
				value.GetComponent<DragAndDropCell>().enabled = true;
				value.TurnOffRenderAboveAll();
			}
		}

		private bool DraggedItemWasntDrop(DragAndDropItem item)
		{
			return DragAndDropItem.sourceCell.Equals(item.GetComponentInParent<DragAndDropCell>());
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			CorrectFinishDrag();
		}

		private void CorrectFinishDrag()
		{
			DragAndDropItem draggedItem = DragAndDropItem.draggedItem;
			if (draggedItem != null)
			{
				draggedItem.OnEndDrag(null);
				OnAnyItemDragEnd(draggedItem, null);
			}
		}

		private bool CellIsTankSlot(DragAndDropCell cell)
		{
			return cell.GetComponent<TankSlotView>() != null;
		}

		private void HighlightPossibleSlots()
		{
			ModuleItem moduleItem = DragAndDropItem.draggedItem.GetComponent<SlotItemView>().ModuleItem;
			hullCollectionView.TurnOffSlots();
			turretCollectionView.TurnOffSlots();
			if (moduleItem.TankPartModuleType == TankPartModuleType.WEAPON)
			{
				turretCollectionView.TurnOnSlotsByTypeAndHighlightForDrop(moduleItem.ModuleBehaviourType);
			}
			else
			{
				hullCollectionView.TurnOnSlotsByTypeAndHighlightForDrop(moduleItem.ModuleBehaviourType);
			}
			foreach (KeyValuePair<ModuleItem, CollectionSlotView> slot in CollectionView.slots)
			{
				CollectionSlotView value = slot.Value;
				if (slot.Key == moduleItem)
				{
					value.TurnOnRenderAboveAll();
				}
				else
				{
					value.GetComponent<DragAndDropCell>().enabled = false;
				}
			}
		}

		private void MoveDraggingCardInFronfOfAll(float zOffset)
		{
			Vector3 anchoredPosition3D = DragAndDropItem.draggedItemContentCopy.GetComponent<RectTransform>().anchoredPosition3D;
			anchoredPosition3D.z = zOffset;
			DragAndDropItem.draggedItemContentCopy.GetComponent<RectTransform>().anchoredPosition3D = anchoredPosition3D;
			TurnOnRenderAboveAll(DragAndDropItem.draggedItemContentCopy);
		}

		public void TurnOnRenderAboveAll(GameObject gameObject)
		{
			Canvas canvas = gameObject.AddComponent<Canvas>();
			canvas.renderMode = RenderMode.WorldSpace;
			canvas.overrideSorting = true;
			canvas.sortingOrder = 30;
			gameObject.AddComponent<GraphicRaycaster>();
			CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>() ?? gameObject.AddComponent<CanvasGroup>();
			canvasGroup.blocksRaycasts = true;
			canvasGroup.ignoreParentGroups = true;
			canvasGroup.interactable = false;
		}

		public void OnDrop(DragAndDropCell cellFrom, DragAndDropCell cellTo, DragAndDropItem item)
		{
			if (item == null || cellFrom == cellTo)
			{
				return;
			}
			DropDescriptor dropDescriptor = default(DropDescriptor);
			dropDescriptor.item = item;
			dropDescriptor.sourceCell = cellFrom;
			dropDescriptor.destinationCell = cellTo;
			DropDescriptor dropDescriptor2 = dropDescriptor;
			if (CellIsTankSlot(cellTo))
			{
				if (CellIsTankSlot(cellFrom))
				{
					dropDescriptor = default(DropDescriptor);
					dropDescriptor.destinationCell = dropDescriptor2.sourceCell;
					dropDescriptor.item = dropDescriptor2.destinationCell.GetItem();
					dropDescriptor.sourceCell = dropDescriptor2.destinationCell;
					DropDescriptor arg = dropDescriptor;
					dropDescriptor2.destinationCell.PlaceItem(dropDescriptor2.item);
					if (arg.item != null)
					{
						dropDescriptor2.sourceCell.PlaceItem(arg.item);
					}
					if (onDrop != null)
					{
						onDrop(dropDescriptor2, arg);
					}
					return;
				}
				DragAndDropItem item2 = dropDescriptor2.destinationCell.GetItem();
				DragAndDropCell destinationCell = null;
				if (item2 != null)
				{
					ModuleItem moduleItem = item2.GetComponent<SlotItemView>().ModuleItem;
					destinationCell = CollectionView.slots[moduleItem].GetComponent<DragAndDropCell>();
				}
				dropDescriptor = default(DropDescriptor);
				dropDescriptor.destinationCell = destinationCell;
				dropDescriptor.item = item2;
				dropDescriptor.sourceCell = dropDescriptor2.destinationCell;
				DropDescriptor arg2 = dropDescriptor;
				dropDescriptor2.destinationCell.PlaceItem(dropDescriptor2.item);
				if (arg2.item != null)
				{
					arg2.destinationCell.PlaceItem(arg2.item);
				}
				if (onDrop != null)
				{
					onDrop(dropDescriptor2, arg2);
				}
			}
			else
			{
				dropDescriptor2.destinationCell.PlaceItem(dropDescriptor2.item);
				if (onDrop != null)
				{
					Action<DropDescriptor, DropDescriptor> action = onDrop;
					DropDescriptor arg3 = dropDescriptor2;
					dropDescriptor = default(DropDescriptor);
					action(arg3, dropDescriptor);
				}
			}
		}
	}
}
