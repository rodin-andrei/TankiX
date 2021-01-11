using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	[AddComponentMenu("UI/UI Table view", 38)]
	public class UITableView : ScrollRect
	{
		[SerializeField]
		private UITableViewCell cellPrefab;

		private List<UITableViewCell> cellsPool = new List<UITableViewCell>();

		[SerializeField]
		private float CellsSpacing;

		[SerializeField]
		private float CellHeight;

		private List<int> currentVisibleIndexes = new List<int>();

		public UITableViewCell CellPrefab
		{
			get
			{
				return cellPrefab;
			}
			set
			{
				cellPrefab = value;
			}
		}

		public void UpdateTable()
		{
			for (int i = 0; i < cellsPool.Count; i++)
			{
				if (cellsPool[i] != null)
				{
					cellsPool[i].gameObject.SetActive(false);
				}
			}
			currentVisibleIndexes.Clear();
			base.content.anchoredPosition = Vector2.zero;
		}

		public void RemoveCell(int index, bool toRight)
		{
			if (!currentVisibleIndexes.Contains(index))
			{
				return;
			}
			UITableViewCell cellByIndex = GetCellByIndex(index);
			if (!(cellByIndex != null))
			{
				return;
			}
			cellsPool.Remove(cellByIndex);
			cellByIndex.removed = true;
			cellByIndex.CellRemoved = (TableViewCellRemoved)Delegate.Combine(cellByIndex.CellRemoved, new TableViewCellRemoved(CellRemoved));
			if (currentVisibleIndexes.Contains(cellByIndex.Index))
			{
				currentVisibleIndexes.Remove(cellByIndex.Index);
			}
			for (int i = 0; i < currentVisibleIndexes.Count; i++)
			{
				UITableViewCell cellByIndex2 = GetCellByIndex(currentVisibleIndexes[i]);
				if (cellByIndex2 != null && cellByIndex2.Index > cellByIndex.Index)
				{
					cellByIndex2.Index--;
					currentVisibleIndexes[i]--;
				}
			}
			cellByIndex.Remove(toRight);
		}

		public void CellRemoved(UITableViewCell cell)
		{
			cell.CellRemoved = (TableViewCellRemoved)Delegate.Remove(cell.CellRemoved, new TableViewCellRemoved(CellRemoved));
			UnityEngine.Object.Destroy(cell.gameObject);
			UITableViewCell[] componentsInChildren = base.content.GetComponentsInChildren<UITableViewCell>();
			UITableViewCell[] array = componentsInChildren;
			foreach (UITableViewCell uITableViewCell in array)
			{
				uITableViewCell.UpdatePosition();
			}
		}

		protected virtual int NumberOfRows()
		{
			return 0;
		}

		protected virtual UITableViewCell CellForRowAtIndex(int index)
		{
			if (index < 0 || index >= NumberOfRows())
			{
				return null;
			}
			UITableViewCell uITableViewCell = ReusableCell();
			uITableViewCell.Index = index;
			uITableViewCell.UpdatePositionImmidiate();
			return uITableViewCell;
		}

		private void Update()
		{
			if (Application.isPlaying)
			{
				UpdateCells();
				UpdateContentHeight();
			}
		}

		private void UpdateCells()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			List<int> visibleIndexes = GetVisibleIndexes();
			if (visibleIndexes.Equals(currentVisibleIndexes))
			{
				return;
			}
			if (visibleIndexes.Count >= currentVisibleIndexes.Count)
			{
				for (int i = 0; i < visibleIndexes.Count; i++)
				{
					if (!currentVisibleIndexes.Contains(visibleIndexes[i]))
					{
						CellForRowAtIndex(visibleIndexes[i]);
					}
				}
			}
			if (currentVisibleIndexes.Count >= visibleIndexes.Count)
			{
				for (int j = 0; j < currentVisibleIndexes.Count; j++)
				{
					if (!visibleIndexes.Contains(currentVisibleIndexes[j]))
					{
						UITableViewCell cellByIndex = GetCellByIndex(currentVisibleIndexes[j]);
						if (cellByIndex != null)
						{
							cellByIndex.gameObject.SetActive(false);
						}
					}
				}
			}
			currentVisibleIndexes = visibleIndexes;
		}

		private void UpdateContentHeight()
		{
			float num = (float)NumberOfRows() * CellHeight + (float)NumberOfRows() * CellsSpacing;
			if (!(base.content == null) && base.content.rect.height != num)
			{
				base.content.sizeDelta = new Vector2(base.content.sizeDelta.x, num);
			}
		}

		protected UITableViewCell GetCellByIndex(int index)
		{
			UITableViewCell[] componentsInChildren = base.content.GetComponentsInChildren<UITableViewCell>();
			UITableViewCell[] array = componentsInChildren;
			foreach (UITableViewCell uITableViewCell in array)
			{
				if (uITableViewCell.Index == index && !uITableViewCell.removed)
				{
					return uITableViewCell;
				}
			}
			return null;
		}

		private List<int> GetVisibleIndexes()
		{
			List<int> list = new List<int>();
			float height = base.viewport.rect.height;
			float y = base.content.anchoredPosition.y;
			float num = height / (CellHeight + CellsSpacing) + 1f;
			int num2 = (int)(y / (CellHeight + CellsSpacing));
			for (int i = 0; (float)i < num; i++)
			{
				list.Add(num2 + i);
			}
			return list;
		}

		public Vector2 PositionForRowAtIndex(int index)
		{
			return new Vector2(0f, 0f - (CellHeight * (float)index + CellsSpacing * (float)index));
		}

		private UITableViewCell ReusableCell()
		{
			foreach (UITableViewCell item in cellsPool)
			{
				if (!item.gameObject.activeSelf)
				{
					item.gameObject.SetActive(true);
					return item;
				}
			}
			UITableViewCell uITableViewCell = UnityEngine.Object.Instantiate(cellPrefab, base.content);
			uITableViewCell.gameObject.SetActive(true);
			cellsPool.Add(uITableViewCell);
			return uITableViewCell;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (!Application.isPlaying)
			{
				return;
			}
			for (int i = 0; i < cellsPool.Count; i++)
			{
				if (cellsPool[i] != null)
				{
					UnityEngine.Object.Destroy(cellsPool[i].gameObject);
				}
			}
			cellsPool.Clear();
		}
	}
}
