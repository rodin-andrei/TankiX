using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class PurchasedItemListComponent : Component
	{
		private List<long> purchasedItems = new List<long>();

		public void AddPurchasedItem(long marketItemId)
		{
			purchasedItems.Add(marketItemId);
		}

		public bool Contains(long marketItemId)
		{
			return purchasedItems.Contains(marketItemId);
		}
	}
}
