using System;
using tanks.modules.lobby.ClientGarage.Scripts.API.UI.Items;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class SlotInteractive : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IEventSystemHandler
	{
		public Image selectionBorder;

		public Image border;

		public Color highlightedColor;

		public Color pressedColor;

		private Color colorMultiplier;

		private bool selectable;

		public ModuleItem moduleItem;

		public Action onClick;

		public Action onDoubleClick;

		private bool selected;

		public void Select()
		{
			selected = true;
			UpdateView();
		}

		public void Deselect()
		{
			selected = false;
			UpdateView();
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (eventData.button != PointerEventData.InputButton.Right && selectable)
			{
				SetPressedColor();
			}
		}

		private void SetPressedColor()
		{
			selectionBorder.color = pressedColor * colorMultiplier;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (selectable)
			{
				border.gameObject.SetActive(false);
				if (!selected)
				{
					selectionBorder.color = highlightedColor * colorMultiplier;
					selectionBorder.gameObject.SetActive(true);
				}
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (selectable)
			{
				border.gameObject.SetActive(moduleItem.UserItem != null && !selected);
				selectionBorder.gameObject.SetActive(selected);
			}
		}

		public void UpdateView(Color colorMultiplier)
		{
			this.colorMultiplier = colorMultiplier;
			UpdateView();
		}

		private void UpdateView()
		{
			selectable = moduleItem.UserItem == null || moduleItem.ImproveAvailable();
			if (selectable)
			{
				if (selected)
				{
					selectionBorder.gameObject.SetActive(true);
					border.gameObject.SetActive(false);
					SetPressedColor();
				}
				else
				{
					selectionBorder.gameObject.SetActive(false);
					border.gameObject.SetActive(moduleItem.IsMounted);
				}
			}
			else
			{
				selectionBorder.gameObject.SetActive(false);
				border.gameObject.SetActive(true);
			}
			border.color = Color.white * colorMultiplier;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (eventData.button != PointerEventData.InputButton.Right)
			{
				if (selectable && eventData.clickCount == 1 && onClick != null)
				{
					onClick();
				}
				if (eventData.clickCount > 1 && onDoubleClick != null)
				{
					onDoubleClick();
				}
			}
		}
	}
}
