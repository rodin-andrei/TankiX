using System.Collections.Generic;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class FriendsUITableView : UITableView
	{
		private List<UserCellData> items;

		private List<UserCellData> filteredItems;

		private string filterString = string.Empty;

		public List<UserCellData> Items
		{
			get
			{
				return items ?? (items = new List<UserCellData>());
			}
			set
			{
				items = value;
			}
		}

		public List<UserCellData> FilteredItems
		{
			get
			{
				return filteredItems ?? (filteredItems = new List<UserCellData>());
			}
			set
			{
				filteredItems = value;
			}
		}

		public string FilterString
		{
			get
			{
				return filterString;
			}
			set
			{
				filterString = value;
				FilteredItems = new List<UserCellData>();
				foreach (UserCellData item in Items)
				{
					if (string.IsNullOrEmpty(value) || item.uid.ToLower().Contains(filterString.ToLower()))
					{
						FilteredItems.Add(item);
					}
				}
				UpdateTable();
			}
		}

		protected override int NumberOfRows()
		{
			return FilteredItems.Count;
		}

		protected override UITableViewCell CellForRowAtIndex(int index)
		{
			UITableViewCell uITableViewCell = base.CellForRowAtIndex(index);
			if (uITableViewCell != null)
			{
				FriendsUITableViewCell friendsUITableViewCell = (FriendsUITableViewCell)uITableViewCell;
				friendsUITableViewCell.Init(FilteredItems[index].id, Items.Count > 50);
			}
			return uITableViewCell;
		}

		public void RemoveUser(long userId, bool toRight)
		{
			for (int i = 0; i < Items.Count; i++)
			{
				if (Items[i].id == userId)
				{
					UserCellData item = Items[i];
					Items.Remove(item);
					if (FilteredItems.Contains(item))
					{
						int index = FilteredItems.IndexOf(item);
						FilteredItems.RemoveAt(index);
						RemoveCell(index, toRight);
					}
				}
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			Items.Clear();
			FilterString = string.Empty;
		}
	}
}
