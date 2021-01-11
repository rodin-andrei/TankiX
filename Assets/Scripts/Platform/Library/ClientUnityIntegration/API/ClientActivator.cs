using System.Collections.Generic;
using System.Linq;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientDataStructures.API;
using Platform.Library.ClientUnityIntegration.Impl;
using UnityEngine;

namespace Platform.Library.ClientUnityIntegration.API
{
	public abstract class ClientActivator : MonoBehaviour
	{
		private List<Activator> coreActivators;

		private List<Activator> nonCoreActivators;

		protected ActivatorsLauncher activatorsLauncher;

		[Inject]
		public static EngineServiceInternal EngineServiceInternal
		{
			get;
			set;
		}

		public bool AllActivatorsLaunched
		{
			get;
			private set;
		}

		public void ActivateClient(List<Activator> coreActivators, List<Activator> nonCoreActivators)
		{
			this.coreActivators = coreActivators;
			this.nonCoreActivators = nonCoreActivators;
			InjectionUtils.RegisterInjectionPoints(typeof(InjectAttribute), ServiceRegistry.Current);
			LaunchCoreActivators();
		}

		private void LaunchCoreActivators()
		{
			activatorsLauncher = new ActivatorsLauncher(coreActivators);
			activatorsLauncher.LaunchAll(OnCoreActivatorsLaunched);
		}

		private void OnCoreActivatorsLaunched()
		{
			(from a in nonCoreActivators
				select a as ECSActivator into a
				where a != null
				select a).ForEach(delegate(ECSActivator a)
			{
				a.RegisterSystemsAndTemplates();
			});
			EngineServiceInternal.RunECSKernel();
			base.gameObject.AddComponent<PreciseTimeBehaviour>();
			base.gameObject.AddComponent<EngineBehaviour>();
			activatorsLauncher = new ActivatorsLauncher(nonCoreActivators);
			activatorsLauncher.LaunchAll(OnAllActivatorsLaunched);
		}

		private void OnAllActivatorsLaunched()
		{
			AllActivatorsLaunched = true;
			Engine engine = EngineServiceInternal.Engine;
			Entity entity = engine.CreateEntity("loader");
			engine.ScheduleEvent<ClientStartEvent>(entity);
		}

		protected IEnumerable<Activator> GetActivatorsAddedInUnityEditor()
		{
			return from a in base.gameObject.GetComponentsInChildren<Activator>()
				where ((MonoBehaviour)a).enabled
				select a;
		}
	}
}
