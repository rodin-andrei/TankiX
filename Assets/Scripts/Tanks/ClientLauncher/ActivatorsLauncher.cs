using System;
using System.Collections.Generic;
using log4net;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientLogger.API;

namespace Tanks.ClientLauncher
{
	public class ActivatorsLauncher
	{
		private readonly ILog logger;

		private readonly Queue<Platform.Kernel.OSGi.ClientCore.API.Activator> activators;

		public ActivatorsLauncher(IEnumerable<Platform.Kernel.OSGi.ClientCore.API.Activator> activators)
		{
			this.activators = new Queue<Platform.Kernel.OSGi.ClientCore.API.Activator>(activators);
			logger = LoggerProvider.GetLogger<ActivatorsLauncher>();
		}

		public void LaunchAll(Action onComplete = null)
		{
			InjectionUtils.RegisterInjectionPoints(typeof(InjectAttribute), ServiceRegistry.Current);
			LaunchECSActivators();
			LaunchActivator(onComplete);
		}

		private void LaunchECSActivators()
		{
			foreach (Platform.Kernel.OSGi.ClientCore.API.Activator activator in activators)
			{
				if (activator is ECSActivator)
				{
					logger.InfoFormat("Activate ECS part {0}", activator.GetType());
					((ECSActivator)activator).RegisterSystemsAndTemplates();
				}
			}
		}

		public void LaunchActivator(Action onComplete = null)
		{
			if (activators.Count > 0)
			{
				Platform.Kernel.OSGi.ClientCore.API.Activator activator = activators.Dequeue();
				logger.InfoFormat("Activate {0}", activator.GetType());
				activator.Launch(delegate
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
