using System;
using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientDataStructures.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class EngineServiceImpl : EngineServiceInternal, EngineService
	{
		protected readonly Flow flow;

		protected readonly TemplateRegistry templateRegistry;

		private readonly bool instanceFieldsInitialized;

		private EngineDefaultRegistrator engineDefaultRegistrator;

		private SystemRegistry systemRegistry;

		public bool IsRunning
		{
			get;
			private set;
		}

		public ICollection<ComponentConstructor> ComponentConstructors
		{
			get;
			private set;
		}

		public HandlerCollector HandlerCollector
		{
			get;
			private set;
		}

		public EventMaker EventMaker
		{
			get;
			private set;
		}

		public BroadcastEventHandlerCollector BroadcastEventHandlerCollector
		{
			get;
			private set;
		}

		public DelayedEventManager DelayedEventManager
		{
			get;
			private set;
		}

		public EntityRegistry EntityRegistry
		{
			get;
			private set;
		}

		public virtual NodeCollectorImpl NodeCollector
		{
			get;
			protected set;
		}

		public Entity EntityStub
		{
			get;
			private set;
		}

		public Engine Engine
		{
			get;
			private set;
		}

		public ComponentBitIdRegistry ComponentBitIdRegistry
		{
			get;
			private set;
		}

		public NodeCache NodeCache
		{
			get;
			protected set;
		}

		public HandlerStateListener HandlerStateListener
		{
			get;
			private set;
		}

		public HandlerContextDataStorage HandlerContextDataStorage
		{
			get;
			private set;
		}

		public ICollection<FlowListener> FlowListeners
		{
			get;
			private set;
		}

		public ICollection<ComponentListener> ComponentListeners
		{
			get;
			private set;
		}

		public ICollection<EventListener> EventListeners
		{
			get;
			private set;
		}

		public TypeInstancesStorage<Event> EventInstancesStorageForReuse
		{
			get;
			private set;
		}

		public SystemRegistry SystemRegistry
		{
			get
			{
				return systemRegistry;
			}
		}

		public EngineServiceImpl(TemplateRegistry templateRegistry, HandlerCollector handlerCollector, EventMaker eventMaker, ComponentBitIdRegistry componentBitIdRegistry)
		{
			this.templateRegistry = templateRegistry;
			if (!instanceFieldsInitialized)
			{
				InitializeInstanceFields();
				instanceFieldsInitialized = true;
			}
			HandlerCollector = handlerCollector;
			EventMaker = eventMaker;
			BroadcastEventHandlerCollector = new BroadcastEventHandlerCollector(HandlerCollector);
			HandlerStateListener = new HandlerStateListener(HandlerCollector);
			ComponentConstructors = new List<ComponentConstructor>();
			DelayedEventManager = new DelayedEventManager(this);
			Engine = CreateDefaultEngine(DelayedEventManager);
			EntityRegistry = new EntityRegistryImpl();
			NodeCollector = new NodeCollectorImpl();
			systemRegistry = new SystemRegistry(templateRegistry, this);
			NodeCache = new NodeCache(this);
			ComponentBitIdRegistry = componentBitIdRegistry;
			HandlerContextDataStorage = new HandlerContextDataStorage();
			FlowListeners = new HashSet<FlowListener>();
			ComponentListeners = new HashSet<ComponentListener>();
			EventListeners = new HashSet<EventListener>();
			EventInstancesStorageForReuse = new TypeInstancesStorage<Event>();
			engineDefaultRegistrator.Register();
			CollectEmptyEventInstancesForReuse();
			flow = new Flow(this);
		}

		private void InitializeInstanceFields()
		{
			engineDefaultRegistrator = new EngineDefaultRegistrator(this);
		}

		private Engine CreateDefaultEngine(DelayedEventManager delayedEventManager)
		{
			EngineImpl engineImpl = new EngineImpl();
			engineImpl.Init(templateRegistry, delayedEventManager);
			return engineImpl;
		}

		public void RunECSKernel()
		{
			if (!IsRunning)
			{
				HandlerCollector.SortHandlers();
				IsRunning = true;
				EntityStub = new EntityStub();
				EntityRegistry.RegisterEntity(EntityStub);
			}
		}

		public void CollectEmptyEventInstancesForReuse()
		{
			List<Type> list = new List<Type>(512);
			AssemblyTypeCollector.CollectEmptyEventTypes(list);
			foreach (Type item in list)
			{
				EventInstancesStorageForReuse.AddInstance(item);
			}
		}

		public void RegisterTasksForHandler(Type handlerType)
		{
			HandlerCollector.RegisterTasksForHandler(handlerType);
		}

		public void RegisterHandlerFactory(HandlerFactory factory)
		{
			HandlerCollector.RegisterHandlerFactory(factory);
		}

		public void RegisterSystem(ECSSystem system)
		{
			systemRegistry.RegisterSystem(system);
		}

		public void ForceRegisterSystem(ECSSystem system)
		{
			systemRegistry.ForceRegisterSystem(system);
		}

		public void AddSystemProcessingListener(EngineHandlerRegistrationListener listener)
		{
			HandlerCollector.AddHandlerListener(listener);
		}

		public Flow NewFlow()
		{
			RequireRunningState();
			return flow;
		}

		public Flow GetFlow()
		{
			return flow;
		}

		public void ExecuteInFlow(Consumer<Engine> consumer)
		{
			Flow.Current.ScheduleWith(consumer);
		}

		public void RegisterComponentConstructor(ComponentConstructor componentConstructor)
		{
			ComponentConstructors.Add(componentConstructor);
		}

		public virtual void RequireInitState()
		{
			if (IsRunning)
			{
				throw new RegistrationAfterStartECSException();
			}
		}

		private void RequireRunningState()
		{
			if (!IsRunning)
			{
				throw new ECSNotRunningException();
			}
		}

		public virtual EntityBuilder CreateEntityBuilder()
		{
			return new EntityBuilder(this, EntityRegistry, templateRegistry);
		}

		public void AddFlowListener(FlowListener flowListener)
		{
			FlowListeners.Add(flowListener);
		}

		public void RemoveFlowListener(FlowListener flowListener)
		{
			FlowListeners.Remove(flowListener);
		}

		public void AddComponentListener(ComponentListener componentListener)
		{
			ComponentListeners.Add(componentListener);
		}

		public void AddEventListener(EventListener eventListener)
		{
			EventListeners.Add(eventListener);
		}
	}
}
