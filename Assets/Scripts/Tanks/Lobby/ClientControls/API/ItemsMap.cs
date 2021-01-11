using System.Collections;
using System.Collections.Generic;

namespace Tanks.Lobby.ClientControls.API
{
	public class ItemsMap : IEnumerable<ListItem>, IEnumerable
	{
		private List<ListItem> items = new List<ListItem>();

		private Dictionary<object, ListItem> map = new Dictionary<object, ListItem>();

		public int Count
		{
			get
			{
				return items.Count;
			}
		}

		public ListItem this[object entity]
		{
			get
			{
				return map[entity];
			}
		}

		public IEnumerator<ListItem> GetEnumerator()
		{
			return items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return items.GetEnumerator();
		}

		public void Add(ListItem item)
		{
			items.Add(item);
			map.Add(item.Data, item);
		}

		public void Clear()
		{
			items.Clear();
			map.Clear();
		}

		public bool Contains(object entity)
		{
			return map.ContainsKey(entity);
		}

		public bool Remove(object entity)
		{
			if (map.ContainsKey(entity))
			{
				ListItem listItem = map[entity];
				if (listItem != null)
				{
					items.Remove(listItem);
				}
			}
			return map.Remove(entity);
		}

		public void Sort(IComparer<ListItem> comparer)
		{
			items.Sort(comparer);
		}
	}
}
