using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Lobby.ClientGarage.API
{
	[SerialVersionUID(636462061562673727L)]
	public class TargetTierComponent : Component
	{
		private bool containsAllTierItem = true;

		private List<long> itemList = new List<long>();

		public int TargetTier
		{
			get;
			set;
		}

		public int MaxExistTier
		{
			get;
			set;
		}

		public bool ContainsAllTierItem
		{
			get
			{
				return containsAllTierItem;
			}
			set
			{
				containsAllTierItem = value;
			}
		}

		public List<long> ItemList
		{
			get
			{
				return itemList;
			}
			set
			{
				itemList = value;
			}
		}
	}
}
