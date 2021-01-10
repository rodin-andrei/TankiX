using Platform.Kernel.ECS.ClientEntitySystem.API;
using System.Collections.Generic;

namespace Tanks.Lobby.ClientPayment.Impl
{
	public class RequestInfoForItemsEvent : Event
	{
		public RequestInfoForItemsEvent(List<long> itemIds)
		{
		}

		public string crystalTitle;
		public string crystalSprite;
		public string xCrystalTitle;
		public string xCrystalSprite;
		public string mainItemTitle;
		public string mainItemSprite;
		public string mainItemDescription;
		public int mainItemCount;
		public bool mainItemCrystal;
		public bool mainItemXCrystal;
		public long mainItemId;
	}
}
