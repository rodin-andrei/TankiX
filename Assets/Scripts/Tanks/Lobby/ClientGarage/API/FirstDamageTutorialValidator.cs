using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Tanks.Lobby.ClientGarage.Impl;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.API
{
	public class FirstDamageTutorialValidator : MonoBehaviour, ITutorialShowStepValidator
	{
		[SerializeField]
		private long itemId;

		[SerializeField]
		private Slot mountSlot;

		[Inject]
		public static EngineServiceInternal EngineService
		{
			get;
			set;
		}

		public bool ShowAllowed(long stepId)
		{
			CheckMountedModuleEvent checkMountedModuleEvent = new CheckMountedModuleEvent();
			checkMountedModuleEvent.StepId = stepId;
			checkMountedModuleEvent.ItemId = itemId;
			checkMountedModuleEvent.MountSlot = mountSlot;
			CheckMountedModuleEvent checkMountedModuleEvent2 = checkMountedModuleEvent;
			EngineService.Engine.ScheduleEvent(checkMountedModuleEvent2, EngineService.EntityStub);
			return checkMountedModuleEvent2.ModuleMounted;
		}
	}
}
