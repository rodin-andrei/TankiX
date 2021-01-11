using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientGarage.Impl;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.API
{
	public class TurretTutorialStepValidator : ECSBehaviour, ITutorialShowStepValidator
	{
		[SerializeField]
		private long neededWeapon;

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
			return getChangeTurretTutorialValidationDataEvent.MountedWeaponId == neededWeapon;
		}
	}
}
