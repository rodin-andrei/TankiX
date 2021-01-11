using System;
using System.Collections.Generic;
using System.Reflection;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class GroupRegistryImpl : GroupRegistry
	{
		private IDictionary<Type, IDictionary<long, GroupComponent>> groups = new Dictionary<Type, IDictionary<long, GroupComponent>>();

		public T FindOrCreateGroup<T>(long key) where T : GroupComponent
		{
			return (T)FindOrCreateGroup(typeof(T), key);
		}

		public GroupComponent FindOrCreateGroup(Type groupClass, long key)
		{
			if (!groups.ContainsKey(groupClass))
			{
				groups[groupClass] = new Dictionary<long, GroupComponent>();
			}
			IDictionary<long, GroupComponent> dictionary = groups[groupClass];
			if (!dictionary.ContainsKey(key))
			{
				dictionary[key] = CreateGroupComponent(groupClass, key);
			}
			return dictionary[key];
		}

		private GroupComponent CreateGroupComponent(Type groupClass, long key)
		{
			ConstructorInfo constructor = groupClass.GetConstructor(new Type[1]
			{
				typeof(long)
			});
			if (constructor == null)
			{
				throw new ComponentInstantiatingException(groupClass);
			}
			return (GroupComponent)constructor.Invoke(new object[1]
			{
				key
			});
		}

		public T FindOrRegisterGroup<T>(T groupComponent) where T : GroupComponent
		{
			return (T)FindOrRegisterGroup((GroupComponent)groupComponent);
		}

		public GroupComponent FindOrRegisterGroup(GroupComponent groupComponent)
		{
			Type type = groupComponent.GetType();
			long key = groupComponent.Key;
			if (!groups.ContainsKey(type))
			{
				groups[type] = new Dictionary<long, GroupComponent>();
			}
			IDictionary<long, GroupComponent> dictionary = groups[type];
			if (!dictionary.ContainsKey(key))
			{
				dictionary[key] = groupComponent;
			}
			return dictionary[key];
		}
	}
}
