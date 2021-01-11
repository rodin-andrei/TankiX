using System;
using System.Collections.Generic;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientDataStructures.API;
using Platform.Library.ClientDataStructures.Impl.Cache;

namespace Platform.Kernel.ECS.ClientEntitySystem.API
{
	public abstract class AbstratFlowInstancesCache : FlowListener
	{
		protected List<AbstractCache> caches = new List<AbstractCache>();

		[Inject]
		public static EngineService EngineService
		{
			get;
			set;
		}

		public AbstratFlowInstancesCache()
		{
			EngineService.AddFlowListener(this);
		}

		public void OnFlowFinish()
		{
		}

		public virtual void OnFlowClean()
		{
			caches.ForEach(delegate(AbstractCache c)
			{
				c.FreeAll();
			});
		}

		protected Cache<T> Register<T>()
		{
			CacheImpl<T> cacheImpl = new CacheImpl<T>();
			caches.Add(cacheImpl);
			return cacheImpl;
		}

		protected Cache<T> Register<T>(Action<T> cleaner)
		{
			CacheImpl<T> cacheImpl = new CacheImpl<T>(cleaner);
			caches.Add(cacheImpl);
			return cacheImpl;
		}
	}
}
