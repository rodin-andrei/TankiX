using System;
using System.Collections.Generic;

namespace Platform.Kernel.OSGi.ClientCore.API
{
	public class ActivatorsLauncher
	{
		private readonly Queue<Activator> activators;

		public Activator CurrentActivator
		{
			get;
			private set;
		}

		public ActivatorsLauncher(IEnumerable<Activator> activators)
		{
			this.activators = new Queue<Activator>(activators);
		}

		public void LaunchAll(Action onComplete = null)
		{
			LaunchActivator(onComplete);
		}

		private void LaunchActivator(Action onComplete = null)
		{
			if (activators.Count > 0)
			{
				CurrentActivator = activators.Dequeue();
				CurrentActivator.Launch(delegate
				{
					LaunchActivator(onComplete);
				});
			}
			else if (onComplete != null)
			{
				onComplete();
			}
		}
	}
}
