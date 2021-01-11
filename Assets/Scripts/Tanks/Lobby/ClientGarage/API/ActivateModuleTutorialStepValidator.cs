using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientEntrance.API;
using Tanks.Lobby.ClientGarage.Impl;
using Tanks.Lobby.ClientUserProfile.API;

namespace Tanks.Lobby.ClientGarage.API
{
	public class ActivateModuleTutorialStepValidator : ECSBehaviour, ITutorialShowStepValidator
	{
		public class UserStatisticsNode : Node
		{
			public SelfUserComponent selfUser;

			public UserStatisticsComponent userStatistics;

			public FavoriteEquipmentStatisticsComponent favoriteEquipmentStatistics;

			public KillsEquipmentStatisticsComponent killsEquipmentStatistics;
		}

		[Inject]
		public new static EngineServiceInternal EngineService
		{
			get;
			set;
		}

		public bool ShowAllowed(long stepId)
		{
			GetChangeTurretTutorialValidationDataEvent getChangeTurretTutorialValidationDataEvent = new GetChangeTurretTutorialValidationDataEvent(stepId, 0L);
			ScheduleEvent(getChangeTurretTutorialValidationDataEvent, EngineService.EntityStub);
			return getChangeTurretTutorialValidationDataEvent.BattlesCount > 1;
		}
	}
}
