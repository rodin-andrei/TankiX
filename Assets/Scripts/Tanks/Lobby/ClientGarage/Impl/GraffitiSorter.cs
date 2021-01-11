using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class GraffitiSorter : MonoBehaviour, SimpleHorizontalListItemsSorter, IComparer<ListItem>
	{
		public void Sort(ItemsMap items)
		{
			items.Sort(this);
		}

		public int Compare(ListItem x, ListItem y)
		{
			Entity entity = x.Data as Entity;
			Entity entity2 = y.Data as Entity;
			if (entity == null || entity2 == null)
			{
				return 0;
			}
			bool flag = IsUserItem(entity);
			bool flag2 = IsUserItem(entity2);
			if (flag && flag2)
			{
				bool flag3 = IsLocked(entity);
				bool flag4 = IsLocked(entity2);
				if (flag3 ^ flag4)
				{
					return (!flag4) ? 1 : (-1);
				}
				return (GetId(entity) >= GetId(entity2)) ? 1 : (-1);
			}
			if (!flag && !flag2)
			{
				return (GetId(entity) >= GetId(entity2)) ? 1 : (-1);
			}
			if (flag)
			{
				return IsLocked(entity) ? 1 : (-1);
			}
			return IsLocked(entity2) ? 1 : (-1);
		}

		private bool IsUserItem(Entity entity)
		{
			return entity.HasComponent<UserItemComponent>();
		}

		private bool IsLocked(Entity entity)
		{
			return entity.HasComponent<RestrictedByUpgradeLevelComponent>();
		}

		private int GetId(Entity entity)
		{
			return entity.GetComponent<OrderItemComponent>().Index;
		}
	}
}
