using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class PeriodicEventTask : ScheduleManager
	{
		private readonly Event e;

		private readonly EngineServiceInternal engineService;

		private readonly HashSet<Entity> contextEntities;

		private readonly float timeInSec;

		private double timeToExecute;

		private bool canceled;

		public PeriodicEventTask(Event e, EngineServiceInternal engineService, ICollection<Entity> contextEntities, float timeInSec)
		{
			this.e = e;
			this.engineService = engineService;
			this.contextEntities = new HashSet<Entity>(contextEntities);
			this.timeInSec = timeInSec;
			NewPeriod();
		}

		private void NewPeriod()
		{
			timeToExecute = timeInSec;
		}

		public void Update(double time)
		{
			while (timeToExecute <= time)
			{
				timeToExecute += timeInSec;
				Flow flow = engineService.GetFlow();
				flow.SendEvent(e, contextEntities);
			}
		}

		public bool IsCanceled()
		{
			return canceled;
		}

		public bool Cancel()
		{
			if (canceled)
			{
				return false;
			}
			canceled = true;
			return true;
		}
	}
}
