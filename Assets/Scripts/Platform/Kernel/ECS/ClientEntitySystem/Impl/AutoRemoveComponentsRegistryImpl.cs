using System;
using System.Collections.Generic;
using System.Linq;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class AutoRemoveComponentsRegistryImpl : AutoRemoveComponentsRegistry, EngineHandlerRegistrationListener
	{
		private HashSet<Type> componentTypes = new HashSet<Type>();

		public AutoRemoveComponentsRegistryImpl(EngineService engineService)
		{
			engineService.AddSystemProcessingListener(this);
		}

		public bool IsComponentAutoRemoved(Type componentType)
		{
			return componentTypes.Contains(componentType);
		}

		public void OnHandlerAdded(Handler handler)
		{
			if (handler.EventType != typeof(NodeRemoveEvent))
			{
				return;
			}
			foreach (HandlerArgument contextArgument in handler.ContextArguments)
			{
				ICollection<Type> components = contextArgument.NodeDescription.Components;
				if (!IsNodeAutoRemoved(components))
				{
					RegisterOneComponent(components);
				}
			}
		}

		public bool IsNodeAutoRemoved(ICollection<Type> components)
		{
			return components.Any(componentTypes.Contains);
		}

		private void RegisterOneComponent(ICollection<Type> components)
		{
			foreach (Type component in components)
			{
				if (!component.IsDefined(typeof(SkipAutoRemove), true))
				{
					componentTypes.Add(component);
					break;
				}
			}
		}
	}
}
