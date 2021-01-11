using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientDataStructures.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class HandlerCollector
	{
		public HashSet<string> HandlersToIgnore;

		private readonly IList<HandlerFactory> factories = new List<HandlerFactory>();

		private readonly MultiMap<Type, Handler> groupType2Handler = new MultiMap<Type, Handler>();

		private readonly Type[] nodeChangeEventTypes = new Type[2]
		{
			typeof(NodeAddedEvent),
			typeof(NodeRemoveEvent)
		};

		private readonly IDictionary<NodeDescription, List<Handler>> handlersByNode = new Dictionary<NodeDescription, List<Handler>>();

		private readonly IDictionary<Type, IDictionary<Type, List<Handler>>> handlersByEvent = new Dictionary<Type, IDictionary<Type, List<Handler>>>();

		private readonly IDictionary<Type, IDictionary<NodeDescription, List<Handler>>> handlersByContextNode = new Dictionary<Type, IDictionary<NodeDescription, List<Handler>>>();

		private readonly ICollection<EngineHandlerRegistrationListener> handlerListeners = new List<EngineHandlerRegistrationListener>();

		[Inject]
		public static FlowInstancesCache Cache
		{
			get;
			set;
		}

		protected virtual Type InheritableEventLimit
		{
			get
			{
				return typeof(Event);
			}
		}

		public void RegisterHandlerFactory(HandlerFactory factory)
		{
			factories.Add(factory);
		}

		public void RegisterTasksForHandler(Type handlerType)
		{
			handlersByEvent[handlerType] = new Dictionary<Type, List<Handler>>();
			handlersByContextNode[handlerType] = new Dictionary<NodeDescription, List<Handler>>();
		}

		public ICollection<Handler> CollectHandlers(ECSSystem system)
		{
			ICollection<Handler> collection = new List<Handler>();
			for (Type type = system.GetType(); type != typeof(ECSSystem); type = type.BaseType)
			{
				MethodInfo[] methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				Array.Sort(methods, (MethodInfo a, MethodInfo b) => string.CompareOrdinal(a.Name, b.Name));
				MethodInfo[] array = methods;
				foreach (MethodInfo methodInfo in array)
				{
					if (!AddHandlerIfNeed(methodInfo, system, collection))
					{
						CheckMethodIsNotHandler(methodInfo);
					}
				}
			}
			return collection;
		}

		private bool AddHandlerIfNeed(MethodInfo declaredMethod, ECSSystem system, ICollection<Handler> systemHandler)
		{
			foreach (HandlerFactory factory in factories)
			{
				Handler handler = factory.CreateHandler(declaredMethod, system);
				if (handler == null)
				{
					continue;
				}
				if (HandlerMustBeIgnored(handler))
				{
					return true;
				}
				if (!declaredMethod.IsPublic)
				{
					throw new PrivateHandlerFoundException(declaredMethod);
				}
				foreach (EngineHandlerRegistrationListener handlerListener in handlerListeners)
				{
					handlerListener.OnHandlerAdded(handler);
				}
				Register(handler);
				systemHandler.Add(handler);
				return true;
			}
			return false;
		}

		private void CheckMethodIsNotHandler(MethodInfo method)
		{
			if (method.GetParameters().Length == 0 || !method.IsPublic || !method.GetParameters()[0].ParameterType.IsSubclassOf(typeof(Event)))
			{
				return;
			}
			throw new MissingHandlerAnnotationException(method);
		}

		private void Register(Handler handler)
		{
			RegisterByEvent(handler);
			RegisterByContextNode(handler);
			RegisterByNode(handler);
			CollectGroup2HandlerReference(handler);
		}

		private void RegisterByEvent(Handler handler)
		{
			IDictionary<Type, List<Handler>> dictionary = handlersByEvent[handler.GetType()];
			ICollection<Handler> collection = dictionary.ComputeIfAbsent(handler.EventType, (Type t) => new List<Handler>());
			collection.Add(handler);
		}

		private void RegisterByContextNode(Handler handler)
		{
			IDictionary<NodeDescription, List<Handler>> handlersByTask = handlersByContextNode[handler.GetType()];
			HashSet<NodeDescription> nodes = new HashSet<NodeDescription>();
			handler.ContextArguments.ForEach(delegate(HandlerArgument a)
			{
				nodes.Add(a.NodeDescription);
			});
			nodes.ForEach(delegate(NodeDescription desc)
			{
				ICollection<Handler> collection = handlersByTask.ComputeIfAbsent(desc, (NodeDescription t) => new List<Handler>());
				collection.Add(handler);
			});
		}

		private void RegisterByNode(Handler handler)
		{
			HashSet<NodeDescription> nodes = new HashSet<NodeDescription>();
			handler.HandlerArgumentsDescription.HandlerArguments.ForEach(delegate(HandlerArgument a)
			{
				nodes.Add(a.NodeDescription);
			});
			nodes.ForEach(delegate(NodeDescription desc)
			{
				ICollection<Handler> collection = handlersByNode.ComputeIfAbsent(desc, (NodeDescription t) => new List<Handler>());
				collection.Add(handler);
			});
		}

		private void CollectGroup2HandlerReference(Handler handler)
		{
			if (nodeChangeEventTypes.Contains(handler.EventType))
			{
				return;
			}
			foreach (HandlerArgument handlerArgument in handler.HandlerArgumentsDescription.HandlerArguments)
			{
				if (handlerArgument.JoinType.IsPresent() && handlerArgument.JoinType.Get().ContextComponent.IsPresent())
				{
					Type key = handlerArgument.JoinType.Get().ContextComponent.Get();
					groupType2Handler.Add(key, handler);
				}
			}
		}

		public void AddHandlerListener(EngineHandlerRegistrationListener listener)
		{
			handlerListeners.Add(listener);
			handlersByEvent.Values.ForEach(delegate(IDictionary<Type, List<Handler>> m)
			{
				m.Values.ForEach(delegate(List<Handler> h)
				{
					h.ForEach(listener.OnHandlerAdded);
				});
			});
		}

		public ICollection<Handler> GetHandlersByGroupComponent(Type groupComponentType)
		{
			return groupType2Handler.GetValues(groupComponentType);
		}

		public ICollection<Handler> GetHandlers(Type handlerType, Type eventType)
		{
			if (IsNotInheritableEvent(eventType))
			{
				return Get(handlerType, eventType);
			}
			IList<Type> inheritableEventTypes = GetInheritableEventTypes(eventType);
			List<Handler> list = new List<Handler>();
			int count = inheritableEventTypes.Count;
			for (int i = 0; i < count; i++)
			{
				list.AddRange(Get(handlerType, inheritableEventTypes[i]));
			}
			return list;
		}

		private bool IsNotInheritableEvent(Type eventType)
		{
			if (!eventType.IsGenericTypeDefinition && eventType.BaseType == InheritableEventLimit)
			{
				return true;
			}
			return false;
		}

		private ICollection<Handler> Get(Type handlerType, Type eventType)
		{
			List<Handler> value;
			return (!handlersByEvent[handlerType].TryGetValue(eventType, out value)) ? Collections.EmptyList<Handler>() : value;
		}

		private IList<Type> GetInheritableEventTypes(Type eventType)
		{
			if (!eventType.IsGenericTypeDefinition)
			{
				List<Type> instance = Cache.listType.GetInstance();
				return ClassUtils.GetClasses(eventType, InheritableEventLimit, instance);
			}
			throw new InvalidOperationException();
		}

		public ICollection<Handler> GetHandlers(Type handlerType, NodeDescription nodeDescription)
		{
			List<Handler> value;
			return (!handlersByContextNode[handlerType].TryGetValue(nodeDescription, out value)) ? Collections.EmptyList<Handler>() : value;
		}

		public ICollection<Handler> GetHandlersWithoutContext(NodeDescription nodeDescription)
		{
			List<Handler> value;
			return (!handlersByNode.TryGetValue(nodeDescription, out value)) ? Collections.EmptyList<Handler>() : value;
		}

		public void SortHandlers()
		{
			handlersByEvent.Values.ForEach(delegate(IDictionary<Type, List<Handler>> m)
			{
				m.Values.ForEach(delegate(List<Handler> c)
				{
					c.Sort();
				});
			});
			handlersByContextNode.Values.ForEach(delegate(IDictionary<NodeDescription, List<Handler>> m)
			{
				m.Values.ForEach(delegate(List<Handler> c)
				{
					c.Sort();
				});
			});
		}

		private bool HandlerMustBeIgnored(Handler handler)
		{
			return HandlersToIgnore != null && HandlersToIgnore.Count > 0 && HandlersToIgnore.Contains(handler.FullMethodName);
		}
	}
}
