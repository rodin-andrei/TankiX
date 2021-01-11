using System;
using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientDataStructures.API;

namespace Platform.System.Data.Exchange.ClientNetwork.Impl
{
	public class ProtocolFlowInstancesCache : AbstratFlowInstancesCache
	{
		private Dictionary<Type, AbstractCache> instancesCache = new Dictionary<Type, AbstractCache>();

		public ProtocolFlowInstancesCache()
		{
			RegisterType<EntityShareCommand>();
			RegisterType<EntityUnshareCommand>();
			RegisterType<CloseCommand>();
			RegisterType<InitTimeCommand>();
			RegisterType<SendEventCommand>();
			RegisterType<ComponentAddCommand>();
			RegisterType<ComponentRemoveCommand>();
			RegisterType<ComponentChangeCommand>();
		}

		public T GetInstance<T>()
		{
			return ((Cache<T>)instancesCache[typeof(T)]).GetInstance();
		}

		public object GetInstance(Type type)
		{
			if (type == typeof(SendEventCommand))
			{
				return GetInstance<SendEventCommand>();
			}
			if (type == typeof(ComponentAddCommand))
			{
				return GetInstance<ComponentAddCommand>();
			}
			if (type == typeof(ComponentRemoveCommand))
			{
				return GetInstance<ComponentRemoveCommand>();
			}
			if (type == typeof(ComponentChangeCommand))
			{
				return GetInstance<ComponentChangeCommand>();
			}
			if (type == typeof(EntityShareCommand))
			{
				return GetInstance<EntityShareCommand>();
			}
			if (type == typeof(EntityUnshareCommand))
			{
				return GetInstance<EntityUnshareCommand>();
			}
			if (type == typeof(CloseCommand))
			{
				return GetInstance<CloseCommand>();
			}
			if (type == typeof(InitTimeCommand))
			{
				return GetInstance<InitTimeCommand>();
			}
			return null;
		}

		private void RegisterType<T>()
		{
			instancesCache.Add(typeof(T), Register<T>());
		}
	}
}
