using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class CheckBoughtItemEvent : Event
	{
		private long itemId;

		private bool tutorialItemAlreadyBought;

		public long ItemId
		{
			get
			{
				return itemId;
			}
			set
			{
				itemId = value;
			}
		}

		public bool TutorialItemAlreadyBought
		{
			get
			{
				return tutorialItemAlreadyBought;
			}
			set
			{
				tutorialItemAlreadyBought = value;
			}
		}

		public CheckBoughtItemEvent(long itemId)
		{
			this.itemId = itemId;
		}
	}
}
