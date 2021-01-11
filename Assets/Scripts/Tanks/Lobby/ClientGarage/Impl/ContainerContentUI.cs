using System.Collections.Generic;
using System.Linq;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ContainerContentUI : MonoBehaviour
	{
		private class GarageItemComparer : IComparer<GarageItem>
		{
			public int Compare(GarageItem x, GarageItem y)
			{
				if (x == null)
				{
					return 1;
				}
				if (y == null)
				{
					return -1;
				}
				int rarity = (int)x.Rarity;
				int rarity2 = (int)y.Rarity;
				int num = rarity.CompareTo(rarity2);
				if (num != 0)
				{
					return num;
				}
				return x.CompareByType(y);
			}
		}

		[SerializeField]
		private DefaultListDataProvider dataProvider;

		[SerializeField]
		private Animator contentAnimator;

		[SerializeField]
		private GameObject graffitiRoot;

		[SerializeField]
		private TextMeshProUGUI containerDescription;

		private readonly List<GarageItem> _itemBuffer = new List<GarageItem>(64);

		private readonly GarageItemComparer _comparer = new GarageItemComparer();

		public ContainerBoxItem Item
		{
			get;
			private set;
		}

		public GameObject GraffitiRoot
		{
			get
			{
				return graffitiRoot;
			}
		}

		public void Set(ContainerBoxItem item, bool selectionIsOn)
		{
			Item = item;
			dataProvider.ClearItems();
			_itemBuffer.AddRange(item.Content);
			_itemBuffer.Sort(_comparer);
			if (selectionIsOn)
			{
				GarageItem garageItem = _itemBuffer.First();
				dataProvider.Init(_itemBuffer, garageItem);
				garageItem.Select();
			}
			else
			{
				dataProvider.Init(_itemBuffer);
			}
			_itemBuffer.Clear();
			containerDescription.text = item.GetLocalizedDescription(item.MarketItem.Id);
			GetComponentInChildren<ScrollRect>().verticalNormalizedPosition = 1f;
		}

		public void CheckGraffityVisibility()
		{
			VisualItem visualItem = dataProvider.Selected as VisualItem;
			GraffitiRoot.SetActive(visualItem != null && visualItem.Type == VisualItem.VisualItemType.Graffiti);
		}

		private void OnDisable()
		{
			graffitiRoot.SetActive(false);
		}
	}
}
