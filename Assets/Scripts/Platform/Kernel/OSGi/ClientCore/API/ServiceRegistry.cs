using System;
using System.Collections.Generic;
using System.Reflection;

namespace Platform.Kernel.OSGi.ClientCore.API
{
	public class ServiceRegistry
	{
		private static ServiceRegistry current;

		private readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

		private readonly Dictionary<Type, List<PropertyInfo>> waitingConsumers = new Dictionary<Type, List<PropertyInfo>>();

		public static ServiceRegistry Current
		{
			get
			{
				if (current == null)
				{
					throw new Exception("Service registry is not set");
				}
				return current;
			}
			set
			{
				current = value;
			}
		}

		static ServiceRegistry()
		{
			Reset();
		}

		public static void Reset()
		{
			Current = new ServiceRegistry();
		}

		public void RegisterService<T>(T service)
		{
			Type typeFromHandle = typeof(T);
			services[typeFromHandle] = service;
			if (waitingConsumers.ContainsKey(typeFromHandle))
			{
				InjectIntoWaitingConsumers(typeFromHandle);
			}
		}

		private void InjectIntoWaitingConsumers(Type type)
		{
			List<PropertyInfo> list = waitingConsumers[type];
			waitingConsumers.Remove(type);
			foreach (PropertyInfo item in list)
			{
				InjectIntoConsumer(item, services[type]);
			}
		}

		public void RegisterConsumer(PropertyInfo consumer)
		{
			if (!consumer.GetSetMethod(true).IsStatic)
			{
				string name = consumer.DeclaringType.Name;
				throw new ArgumentException(string.Format("Property {0}::{1} has to be static", name, consumer.Name), "consumer");
			}
			Type propertyType = consumer.PropertyType;
			if (services.ContainsKey(propertyType))
			{
				InjectIntoConsumer(consumer, services[propertyType]);
			}
			else
			{
				StoreWaitingConsumer(consumer, propertyType);
			}
		}

		private void StoreWaitingConsumer(PropertyInfo consumer, Type type)
		{
			List<PropertyInfo> value;
			if (!waitingConsumers.TryGetValue(type, out value))
			{
				value = new List<PropertyInfo>();
				waitingConsumers.Add(type, value);
			}
			value.Add(consumer);
		}

		private void InjectIntoConsumer(PropertyInfo propertyInfo, object service)
		{
			propertyInfo.GetSetMethod(true).Invoke(null, new object[1]
			{
				service
			});
		}
	}
}
