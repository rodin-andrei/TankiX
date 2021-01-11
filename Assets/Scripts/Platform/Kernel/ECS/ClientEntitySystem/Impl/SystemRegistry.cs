using System;
using System.Collections.Generic;
using System.Reflection;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class SystemRegistry
	{
		private readonly TemplateRegistry templateRegistry;

		private EngineServiceInternal engineService;

		private HashSet<Type> registeredSystemTypes;

		private NodeRegistrator nodeRegistrator;

		[Inject]
		public static NodeDescriptionRegistry NodeDescriptionRegistry
		{
			get;
			set;
		}

		public SystemRegistry(TemplateRegistry templateRegistry, EngineServiceInternal engineService)
		{
			this.templateRegistry = templateRegistry;
			this.engineService = engineService;
			registeredSystemTypes = new HashSet<Type>();
			nodeRegistrator = new NodeRegistrator();
		}

		public void RegisterSystem(ECSSystem system)
		{
			CheckDoubleRegistration(system.GetType());
			DoRegister(system);
		}

		public void ForceRegisterSystem(ECSSystem system)
		{
			DoRegister(system);
		}

		public void RegisterNode<T>() where T : Node
		{
			NodeDescriptionRegistry.AddNodeDescription(new StandardNodeDescription(typeof(T)));
		}

		public void RegisterSingleNode<T>() where T : Component
		{
			NodeDescriptionRegistry.AddNodeDescription(new StandardNodeDescription(typeof(SingleNode<T>)));
		}

		private void DoRegister(ECSSystem system)
		{
			engineService.RequireInitState();
			RegisterNodesDeclaredInSystem(system.GetType());
			CollectHandlersAndNodes(system);
			InitSystem(system);
			registeredSystemTypes.Add(system.GetType());
		}

		private void CheckDoubleRegistration(Type systemType)
		{
			if (registeredSystemTypes.Contains(systemType))
			{
				throw new SystemAlreadyRegisteredException(systemType);
			}
		}

		private void CollectHandlersAndNodes(ECSSystem systemInstance)
		{
			ICollection<Handler> collection = engineService.HandlerCollector.CollectHandlers(systemInstance);
			foreach (Handler item in collection)
			{
				IList<HandlerArgument> handlerArguments = item.HandlerArgumentsDescription.HandlerArguments;
				foreach (HandlerArgument item2 in handlerArguments)
				{
					NodeDescriptionRegistry.AddNodeDescription(item2.NodeDescription);
				}
			}
		}

		private void InitSystem(ECSSystem systemInstance)
		{
			systemInstance.Init(templateRegistry, engineService.DelayedEventManager, engineService, nodeRegistrator);
		}

		private void RegisterNodesDeclaredInSystem(Type systemClass)
		{
			Type[] nestedTypes = systemClass.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic);
			Type[] array = nestedTypes;
			foreach (Type type in array)
			{
				if (type.IsSubclassOf(typeof(Node)) && !type.IsGenericTypeDefinition)
				{
					NodeDescriptionRegistry.AddNodeDescription(new StandardNodeDescription(type));
				}
			}
		}
	}
}
