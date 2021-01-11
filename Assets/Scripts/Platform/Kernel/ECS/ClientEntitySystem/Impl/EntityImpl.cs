using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientDataStructures.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class EntityImpl : EntityInternal, EntityUnsafe, IComparable<EntityImpl>, Entity
	{
		public static readonly List<Entity> EMPTY_LIST = new List<Entity>();

		private static readonly Type[] EmptyTypes = new Type[0];

		protected readonly EngineServiceInternal engineService;

		protected readonly NodeDescriptionStorage nodeDescriptionStorage;

		protected readonly EntityComponentStorage storage;

		private readonly NodeProvider nodeProvider;

		private readonly int hashCode;

		private readonly long id;

		private ICollection<EntityListener> entityListeners;

		protected NodeChangedEventMaker nodeAddedEventMaker;

		protected NodeChangedEventMaker nodeRemoveEventMaker;

		private NodeCache nodeCache;

		[Inject]
		public static NodeDescriptionRegistry NodeDescriptionRegistry
		{
			get;
			set;
		}

		[Inject]
		public static GroupRegistry GroupRegistry
		{
			get;
			set;
		}

		[Inject]
		public static EngineService EngineService
		{
			get;
			set;
		}

		[Inject]
		public static FlowInstancesCache FlowInstancesCache
		{
			get;
			set;
		}

		public long Id
		{
			get
			{
				return id;
			}
		}

		public string Name
		{
			get;
			set;
		}

		public string ConfigPath
		{
			get
			{
				return TemplateAccessor.Get().ConfigPath;
			}
		}

		public Optional<TemplateAccessor> TemplateAccessor
		{
			get;
			set;
		}

		public bool Alive
		{
			get;
			private set;
		}

		public ICollection<Component> Components
		{
			get
			{
				return storage.Components;
			}
		}

		public ICollection<Type> ComponentClasses
		{
			get
			{
				return storage.ComponentClasses;
			}
		}

		public NodeDescriptionStorage NodeDescriptionStorage
		{
			get
			{
				return nodeDescriptionStorage;
			}
		}

		public BitSet ComponentsBitId
		{
			get
			{
				return storage.bitId;
			}
		}

		public EntityImpl(EngineServiceInternal engineService, long id, string name)
			: this(engineService, id, name, Optional<Platform.Kernel.ECS.ClientEntitySystem.Impl.TemplateAccessor>.empty())
		{
		}

		public EntityImpl(EngineServiceInternal engineService, long id, string name, Optional<TemplateAccessor> templateAccessor)
		{
			this.engineService = engineService;
			this.id = id;
			Name = name;
			nodeCache = engineService.NodeCache;
			TemplateAccessor = templateAccessor;
			storage = new EntityComponentStorage(this, engineService.ComponentBitIdRegistry);
			nodeProvider = new NodeProvider(this);
			nodeDescriptionStorage = new NodeDescriptionStorage();
			hashCode = calcHashCode();
			nodeAddedEventMaker = new NodeChangedEventMaker(NodeAddedEvent.Instance, typeof(NodeAddedFireHandler), typeof(NodeAddedCompleteHandler), engineService.HandlerCollector);
			nodeRemoveEventMaker = new NodeChangedEventMaker(NodeRemoveEvent.Instance, typeof(NodeRemovedFireHandler), typeof(NodeRemovedCompleteHandler), engineService.HandlerCollector);
			Init();
			UpdateNodes(NodeDescriptionRegistry.GetNodeDescriptionsWithNotComponentsOnly());
		}

		public void Init()
		{
			Alive = true;
			entityListeners = new List<EntityListener>
			{
				engineService.HandlerContextDataStorage,
				engineService.HandlerStateListener,
				engineService.BroadcastEventHandlerCollector
			};
		}

		public void AddComponent<T>() where T : Component, new()
		{
			AddComponent(typeof(T));
		}

		public void AddComponentIfAbsent<T>() where T : Component, new()
		{
			if (!HasComponent<T>())
			{
				AddComponent(typeof(T));
			}
		}

		public void AddComponent(Type componentType)
		{
			Component component = CreateNewComponentInstance(componentType);
			AddComponent(component);
		}

		public void AddComponent(Component component)
		{
			if (component is GroupComponent)
			{
				component = GroupRegistry.FindOrRegisterGroup((GroupComponent)component);
			}
			AddComponent(component, true);
		}

		public void AddComponentSilent(Component component)
		{
			AddComponent(component, false);
		}

		private void AddComponent(Component component, bool sendEvent)
		{
			Type type = component.GetType();
			if (!storage.HasComponent(type) || !IsSkipExceptionOnAddRemove(type))
			{
				UpdateHandlers(component.GetType());
				NotifyAttachToEntity(component);
				storage.AddComponentImmediately(component.GetType(), component);
				MakeNodes(component.GetType(), component);
				if (sendEvent)
				{
					NotifyAddComponent(component);
				}
				PrepareAndSendNodeAddedEvent(component);
			}
		}

		private void NotifyAddComponent(Component component)
		{
			Collections.Enumerator<ComponentListener> enumerator = Collections.GetEnumerator(engineService.ComponentListeners);
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnComponentAdded(this, component);
			}
		}

		private void UpdateHandlers(Type componentType)
		{
			if (componentType.IsSubclassOf(typeof(GroupComponent)))
			{
				engineService.HandlerCollector.GetHandlersByGroupComponent(componentType).ForEach(delegate(Handler h)
				{
					h.ChangeVersion();
				});
			}
		}

		private void PrepareAndSendNodeAddedEvent(Component component)
		{
			nodeAddedEventMaker.MakeIfNeed(this, component.GetType());
		}

		private void NotifyAttachToEntity(Component component)
		{
			AttachToEntityListener attachToEntityListener = component as AttachToEntityListener;
			if (attachToEntityListener != null)
			{
				attachToEntityListener.AttachedToEntity(this);
			}
		}

		public void ChangeComponent(Component component)
		{
			bool flag = HasComponent(component.GetType()) && GetComponent(component.GetType()).Equals(component);
			storage.ChangeComponent(component);
			if (!flag)
			{
				nodeProvider.OnComponentChanged(component);
			}
			NotifyChangedInEntity(component);
		}

		private void NotifyChangedInEntity(Component component)
		{
			ComponentServerChangeListener componentServerChangeListener = component as ComponentServerChangeListener;
			if (componentServerChangeListener != null)
			{
				componentServerChangeListener.ChangedOnServer(this);
			}
		}

		public Component GetComponent(Type componentType)
		{
			return storage.GetComponent(componentType);
		}

		public Component GetComponentUnsafe(Type componentType)
		{
			return storage.GetComponentUnsafe(componentType);
		}

		public T GetComponent<T>() where T : Component
		{
			return (T)GetComponent(typeof(T));
		}

		public void OnDelete()
		{
			Alive = false;
			ClearNodes();
			SendEntityDeletedForAllListeners();
			storage.OnEntityDelete();
		}

		private void SendEntityDeletedForAllListeners()
		{
			Collections.Enumerator<EntityListener> enumerator = Collections.GetEnumerator(entityListeners);
			while (enumerator.MoveNext())
			{
				EntityListener current = enumerator.Current;
				current.OnEntityDeleted(this);
			}
			entityListeners.Clear();
		}

		public bool CanCast(NodeDescription desc)
		{
			return nodeProvider.CanCast(desc);
		}

		public Node GetNode(NodeClassInstanceDescription instanceDescription)
		{
			return nodeProvider.GetNode(instanceDescription);
		}

		public void NotifyComponentChange(Type componentType)
		{
			Component component = GetComponent(componentType);
			Collections.Enumerator<ComponentListener> enumerator = Collections.GetEnumerator(engineService.ComponentListeners);
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnComponentChanged(this, component);
			}
		}

		public void RemoveComponent<T>() where T : Component
		{
			RemoveComponent(typeof(T));
		}

		public void RemoveComponentIfPresent<T>() where T : Component
		{
			if (HasComponent<T>())
			{
				RemoveComponent(typeof(T));
			}
		}

		public void RemoveComponent(Type componentType)
		{
			UpdateHandlers(componentType);
			NotifyComponentRemove(componentType);
			RemoveComponentSilent(componentType);
		}

		private void NotifyComponentRemove(Type componentType)
		{
			Component component = storage.GetComponent(componentType);
			Collections.Enumerator<ComponentListener> enumerator = Collections.GetEnumerator(engineService.ComponentListeners);
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnComponentRemoved(this, component);
			}
		}

		public void RemoveComponentSilent(Type componentType)
		{
			if (HasComponent(componentType) || (!HasComponent<DeletedEntityComponent>() && !IsSkipExceptionOnAddRemove(componentType)))
			{
				SendNodeRemoved(componentType);
				Component component = storage.RemoveComponentImmediately(componentType);
				NotifyDetachFromEntity(component);
				UpdateNodesOnComponentRemoved(componentType);
			}
		}

		private bool IsSkipExceptionOnAddRemove(Type componentType)
		{
			return componentType.IsDefined(typeof(SkipExceptionOnAddRemoveAttribute), true);
		}

		private void SendNodeRemoved(Type componentType)
		{
			nodeRemoveEventMaker.MakeIfNeed(this, componentType);
		}

		private void NotifyDetachFromEntity(Component component)
		{
			DetachFromEntityListener detachFromEntityListener = component as DetachFromEntityListener;
			if (detachFromEntityListener != null)
			{
				detachFromEntityListener.DetachedFromEntity(this);
			}
		}

		public bool HasComponent<T>() where T : Component
		{
			return HasComponent(typeof(T));
		}

		public bool HasComponent(Type type)
		{
			return storage.HasComponent(type);
		}

		public T CreateGroup<T>() where T : GroupComponent
		{
			T val = GroupRegistry.FindOrCreateGroup<T>(Id);
			AddComponent(val);
			return val;
		}

		public T ToNode<T>() where T : Node, new()
		{
			T result = new T();
			result.Entity = this;
			return result;
		}

		public T AddComponentAndGetInstance<T>()
		{
			Component component = CreateNewComponentInstance(typeof(T));
			AddComponent(component);
			return (T)component;
		}

		public int CompareTo(EntityImpl other)
		{
			return (int)(id - other.id);
		}

		public Component CreateNewComponentInstance(Type componentType)
		{
			Collections.Enumerator<ComponentConstructor> enumerator = Collections.GetEnumerator(engineService.ComponentConstructors);
			while (enumerator.MoveNext())
			{
				ComponentConstructor current = enumerator.Current;
				if (current.IsAcceptable(componentType, this))
				{
					return current.GetComponentInstance(componentType, this);
				}
			}
			ConstructorInfo constructor = componentType.GetConstructor(EmptyTypes);
			return (Component)constructor.Invoke(Collections.EmptyArray);
		}

		protected void MakeNodes(Type componentType, Component component)
		{
			nodeProvider.OnComponentAdded(component, componentType);
			NodesToChange nodesToChange = nodeCache.GetNodesToChange(this, componentType);
			foreach (NodeDescription item in nodesToChange.NodesToAdd)
			{
				AddNode(item);
			}
			foreach (NodeDescription item2 in nodesToChange.NodesToRemove)
			{
				RemoveNode(item2);
			}
		}

		private void UpdateNodes(ICollection<NodeDescription> nodes)
		{
			BitSet componentsBitId = ComponentsBitId;
			Collections.Enumerator<NodeDescription> enumerator = Collections.GetEnumerator(nodes);
			while (enumerator.MoveNext())
			{
				NodeDescription current = enumerator.Current;
				if (componentsBitId.Mask(current.NodeComponentBitId))
				{
					if (componentsBitId.MaskNot(current.NotNodeComponentBitId))
					{
						AddNode(current);
					}
					else if (nodeDescriptionStorage.Contains(current))
					{
						RemoveNode(current);
					}
				}
			}
		}

		protected internal void AddNode(NodeDescription node)
		{
			Flow.Current.NodeCollector.Attach(this, node);
			nodeDescriptionStorage.AddNode(node);
			SendNodeAddedForCollectors(node);
		}

		private void UpdateNodesOnComponentRemoved(Type componentClass)
		{
			List<NodeDescription> list = new List<NodeDescription>(nodeDescriptionStorage.GetNodeDescriptions(componentClass));
			list.ForEach(RemoveNode);
			UpdateNodes(NodeDescriptionRegistry.GetNodeDescriptionsByNotComponent(componentClass));
		}

		private void ClearNodes()
		{
			List<NodeDescription> list = new List<NodeDescription>(nodeDescriptionStorage.GetNodeDescriptions());
			list.ForEach(RemoveNode);
			nodeProvider.CleanNodes();
		}

		internal void RemoveNode(NodeDescription node)
		{
			SendNodeRemovedForCollectors(node);
			Flow.Current.NodeCollector.Detach(this, node);
			nodeDescriptionStorage.RemoveNode(node);
		}

		public bool Contains(NodeDescription node)
		{
			BitSet componentsBitId = ComponentsBitId;
			return componentsBitId.Mask(node.NodeComponentBitId) && componentsBitId.MaskNot(node.NotNodeComponentBitId);
		}

		private void SendNodeAddedForCollectors(NodeDescription nodeDescription)
		{
			Collections.Enumerator<EntityListener> enumerator = Collections.GetEnumerator(entityListeners);
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnNodeAdded(this, nodeDescription);
			}
		}

		private void SendNodeRemovedForCollectors(NodeDescription nodeDescription)
		{
			Collections.Enumerator<EntityListener> enumerator = Collections.GetEnumerator(entityListeners);
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnNodeRemoved(this, nodeDescription);
			}
		}

		protected bool Equals(EntityImpl other)
		{
			return id == other.id;
		}

		public override bool Equals(object obj)
		{
			if (obj is Node)
			{
				obj = ((Node)obj).Entity;
			}
			if (object.ReferenceEquals(null, obj))
			{
				return false;
			}
			if (object.ReferenceEquals(this, obj))
			{
				return true;
			}
			if (obj.GetType() != GetType())
			{
				return false;
			}
			return Equals((EntityImpl)obj);
		}

		public override int GetHashCode()
		{
			return hashCode;
		}

		private int calcHashCode()
		{
			return Id.GetHashCode();
		}

		public override string ToString()
		{
			return string.Format("{0}({1})", Id, Name);
		}

		public string ToStringWithComponentsClasses()
		{
			string[] value = (from c in ComponentClasses
				select c.Name into c
				orderby c
				select c).ToArray();
			return string.Format("Entity[id={0}, name={1}, components={2}]", Id, Name, string.Join(",", value));
		}

		public bool IsSameGroup<T>(Entity otherEntity) where T : GroupComponent
		{
			if (HasComponent<T>() && otherEntity.HasComponent<T>())
			{
				T component = GetComponent<T>();
				long key = component.Key;
				T component2 = otherEntity.GetComponent<T>();
				return key.Equals(component2.Key);
			}
			return false;
		}

		public void AddEntityListener(EntityListener entityListener)
		{
			entityListeners.Add(entityListener);
		}

		public virtual void RemoveEntityListener(EntityListener entityListener)
		{
			entityListeners.Remove(entityListener);
		}

		public void ScheduleEvent<T>() where T : Event, new()
		{
			EngineService.Engine.ScheduleEvent<T>(this);
		}

		public void ScheduleEvent(Event eventInstance)
		{
			EngineService.Engine.ScheduleEvent(eventInstance, this);
		}

		public T SendEvent<T>(T eventInstance) where T : Event
		{
			EngineService.Engine.ScheduleEvent(eventInstance, this);
			return eventInstance;
		}
	}
}
