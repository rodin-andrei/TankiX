using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientGarage.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class Avatar : VisualItem, IAvatarStateChanger, IComparable<Avatar>
	{
		private bool _unlocked = true;

		public Action<bool> SetSelected
		{
			get;
			set;
		}

		public Action<bool> SetEquipped
		{
			get;
			set;
		}

		public Action<bool> SetUnlocked
		{
			get;
			set;
		}

		public Action OnBought
		{
			get;
			set;
		}

		public Action Remove
		{
			get;
			set;
		}

		public override Entity MarketItem
		{
			get
			{
				return base.MarketItem;
			}
			set
			{
				base.MarketItem = value;
				IconUid = value.GetComponent<AvatarItemComponent>().Id;
				MinRank = value.GetComponent<PurchaseUserRankRestrictionComponent>().RestrictionValue;
				orderIndex = value.GetComponent<OrderItemComponent>().Index;
			}
		}

		public string RarityName
		{
			get
			{
				return base.Rarity.ToString().ToLower();
			}
		}

		public string IconUid
		{
			get;
			private set;
		}

		public int MinRank
		{
			get;
			private set;
		}

		public int Index
		{
			get;
			set;
		}

		private int orderIndex
		{
			get;
			set;
		}

		public bool Unlocked
		{
			get
			{
				return _unlocked;
			}
			set
			{
				_unlocked = value;
				if (SetUnlocked != null)
				{
					SetUnlocked(_unlocked);
				}
			}
		}

		public int CompareTo(Avatar other)
		{
			if (this == other)
			{
				return 0;
			}
			if (MarketItem.GetComponent<DefaultItemComponent>().Default)
			{
				return -1;
			}
			if (other.MarketItem.GetComponent<DefaultItemComponent>().Default)
			{
				return 1;
			}
			if (base.UserItem != null && other.UserItem == null)
			{
				return -1;
			}
			if (other.UserItem != null && base.UserItem == null)
			{
				return 1;
			}
			if (orderIndex != other.orderIndex)
			{
				return orderIndex - other.orderIndex;
			}
			if (base.Rarity != other.Rarity)
			{
				return other.Rarity - base.Rarity;
			}
			if (MinRank != other.MinRank)
			{
				return other.MinRank - MinRank;
			}
			return string.Compare(base.Name, other.Name, StringComparison.Ordinal);
		}
	}
}
