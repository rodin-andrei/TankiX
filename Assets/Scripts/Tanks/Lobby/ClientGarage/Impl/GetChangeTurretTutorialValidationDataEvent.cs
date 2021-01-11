using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class GetChangeTurretTutorialValidationDataEvent : Event
	{
		private long stepId;

		private long itemId;

		private long battlesCount;

		private bool tutorialItemAlreadyMounted;

		private bool tutorialItemAlreadyBought;

		private long mountedWeaponId;

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

		public long StepId
		{
			get
			{
				return stepId;
			}
			set
			{
				stepId = value;
			}
		}

		public long BattlesCount
		{
			get
			{
				return battlesCount;
			}
			set
			{
				battlesCount = value;
			}
		}

		public bool TutorialItemAlreadyMounted
		{
			get
			{
				return tutorialItemAlreadyMounted;
			}
			set
			{
				tutorialItemAlreadyMounted = value;
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

		public long MountedWeaponId
		{
			get
			{
				return mountedWeaponId;
			}
			set
			{
				mountedWeaponId = value;
			}
		}

		public GetChangeTurretTutorialValidationDataEvent(long stepId, long itemId = 0L)
		{
			this.stepId = stepId;
			this.itemId = itemId;
		}
	}
}
