using System;
using System.Collections.Generic;
using Tanks.Lobby.ClientControls.API.List;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class DynamicVerticalList : MonoBehaviour
	{
		[SerializeField]
		private RectTransform item;

		[SerializeField]
		private RectTransform itemContent;

		[SerializeField]
		private int itemHeight;

		[SerializeField]
		private int spacing;

		[SerializeField]
		private RectTransform viewport;

		private ListDataProvider dataProvider;

		private List<ListItem> generatedItems = new List<ListItem>();

		private RectTransform rectTransform;

		private int visibleItemsCount;

		private ListItem selected;

		private void Awake()
		{
			rectTransform = GetComponent<RectTransform>();
		}

		private void UpdateBounds(ListDataProvider provider)
		{
			UpdateSize();
			if (provider.Selected == null)
			{
				return;
			}
			ScrollToSelection();
			Layout();
			foreach (ListItem generatedItem in generatedItems)
			{
				if (generatedItem.Data == provider.Selected)
				{
					generatedItem.Select(false);
					break;
				}
			}
		}

		private void UpdateSize()
		{
			rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, viewport.rect.width - 1f);
			int num = dataProvider.Data.Count * itemHeight + (dataProvider.Data.Count - 1) * spacing;
			rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, num);
			if ((float)num < rectTransform.anchoredPosition.y)
			{
				rectTransform.anchoredPosition = new Vector2(0f, Math.Min(0f, (float)num - viewport.rect.height));
			}
		}

		private void Update()
		{
			CalculateVisibleItems();
			Layout();
		}

		private void OnEnable()
		{
			dataProvider = GetComponent<ListDataProvider>();
			if (dataProvider == null)
			{
				dataProvider = base.gameObject.AddComponent<DefaultListDataProvider>();
			}
			dataProvider.DataChanged += UpdateBounds;
			UpdateBounds(dataProvider);
		}

		private void OnDisable()
		{
			dataProvider.DataChanged -= UpdateBounds;
			rectTransform.anchoredPosition = new Vector2(0f, 0f);
			rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0f);
		}

		private void OnItemSelect(ListItem listItem)
		{
			if (selected != null)
			{
				selected.PlayDeselectionAnimation();
			}
			selected = listItem;
		}

		private void CalculateVisibleItems()
		{
			visibleItemsCount = Math.Min((int)(viewport.rect.height / (float)(itemHeight + spacing) + 2f), dataProvider.Data.Count);
			if (visibleItemsCount > generatedItems.Count)
			{
				for (int i = generatedItems.Count; i < visibleItemsCount; i++)
				{
					RectTransform rectTransform = UnityEngine.Object.Instantiate(item);
					ListItem component = rectTransform.GetComponent<ListItem>();
					component.SetContent(UnityEngine.Object.Instantiate(itemContent));
					generatedItems.Add(component);
					rectTransform.SetParent(this.rectTransform, false);
					Vector2 vector3 = (rectTransform.anchorMax = (rectTransform.anchorMin = new Vector2(0f, 1f)));
					rectTransform.pivot = new Vector2(0f, 1f);
				}
			}
		}

		public void ScrollToSelection()
		{
			float num = rectTransform.anchoredPosition.y;
			if (num < 0f)
			{
				rectTransform.anchoredPosition = default(Vector2);
				num = 0f;
			}
			if (dataProvider.Selected == null)
			{
				return;
			}
			int num2 = dataProvider.Data.IndexOf(dataProvider.Selected);
			if (num2 >= 0)
			{
				int num3 = num2 * (itemHeight + spacing);
				float num4 = (float)num3 - num;
				if (num4 + (float)itemHeight > viewport.rect.height || num4 < 0f)
				{
					float y = Math.Min(num3, rectTransform.rect.height - viewport.rect.height);
					rectTransform.anchoredPosition = new Vector2(0f, y);
				}
			}
		}

		private void Layout()
		{
			int num = (int)(rectTransform.anchoredPosition.y / (float)(itemHeight + spacing));
			if (num < 0)
			{
				rectTransform.anchoredPosition = default(Vector2);
				num = 0;
			}
			for (int i = 0; i < visibleItemsCount && num + i < dataProvider.Data.Count; i++)
			{
				ListItem listItem = generatedItems[i];
				if (!listItem.gameObject.activeSelf)
				{
					listItem.gameObject.SetActive(true);
				}
				RectTransform component = listItem.GetComponent<RectTransform>();
				component.anchoredPosition = new Vector2(0f, -(num + i) * (itemHeight + spacing));
				component.sizeDelta = new Vector2(viewport.rect.width, itemHeight);
				listItem.Data = dataProvider.Data[num + i];
				if (listItem.Data == dataProvider.Selected)
				{
					listItem.PlaySelectionAnimation();
				}
				else
				{
					listItem.PlayDeselectionAnimation();
				}
			}
			for (int j = visibleItemsCount; j < generatedItems.Count; j++)
			{
				ListItem listItem2 = generatedItems[j];
				if (listItem2.gameObject.activeSelf)
				{
					listItem2.gameObject.SetActive(false);
				}
			}
		}
	}
}
