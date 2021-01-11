using System;
using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientDataStructures.API;
using Platform.Library.ClientProtocol.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class NodeDescriptionRegistryImpl : NodeDescriptionRegistry
	{
		private readonly IDictionary<Type, ICollection<NodeDescription>> nodeDescriptionsByAnyComponent;

		private readonly IDictionary<Type, ICollection<NodeDescription>> nodeDescriptionsByNotComponent;

		private readonly ICollection<NodeDescription> nodeDescriptionsWithNotComponentsOnly;

		private readonly ICollection<NodeDescription> nodeDescriptions;

		private readonly IDictionary<Type, NodeClassInstanceDescription> nodeClassDescByNodeClass = new Dictionary<Type, NodeClassInstanceDescription>();

		private readonly MultiMap<Type, NodeClassInstanceDescription> nodeClassDescsByComponent = new MultiMap<Type, NodeClassInstanceDescription>();

		private readonly Dictionary<NodeDescription, NodeDescription> nodeDescriptionStorage = new Dictionary<NodeDescription, NodeDescription>();

		[Inject]
		public static Protocol Protocol
		{
			get;
			set;
		}

		public ICollection<NodeDescription> NodeDescriptions
		{
			get
			{
				HashSet<NodeDescription> result = new HashSet<NodeDescription>();
				nodeDescriptionsByAnyComponent.Values.ForEach(delegate(ICollection<NodeDescription> x)
				{
					result.UnionWith(x);
				});
				return result;
			}
		}

		public NodeDescriptionRegistryImpl()
		{
			nodeDescriptionsByAnyComponent = new Dictionary<Type, ICollection<NodeDescription>>();
			nodeDescriptionsByNotComponent = new Dictionary<Type, ICollection<NodeDescription>>();
			nodeDescriptionsWithNotComponentsOnly = new HashSet<NodeDescription>();
			nodeDescriptions = new HashSet<NodeDescription>();
		}

		public void AddNodeDescription(NodeDescription nodeDescription)
		{
			if (!nodeDescription.IsEmpty)
			{
				nodeDescription = (StandardNodeDescription)nodeDescriptionStorage.ComputeIfAbsent(nodeDescription, (NodeDescription d) => d);
				nodeDescription.Components.ForEach(delegate(Type clazz)
				{
					nodeDescriptionsByAnyComponent.ComputeIfAbsent(clazz, (Type k) => new HashSet<NodeDescription>()).Add(nodeDescription);
				});
				nodeDescription.NotComponents.ForEach(delegate(Type clazz)
				{
					nodeDescriptionsByAnyComponent.ComputeIfAbsent(clazz, (Type k) => new HashSet<NodeDescription>()).Add(nodeDescription);
				});
				nodeDescription.NotComponents.ForEach(delegate(Type clazz)
				{
					nodeDescriptionsByNotComponent.ComputeIfAbsent(clazz, (Type k) => new HashSet<NodeDescription>()).Add(nodeDescription);
				});
				if (nodeDescription.Components.Count == 0)
				{
					nodeDescriptionsWithNotComponentsOnly.Add(nodeDescription);
				}
				nodeDescriptions.Add(nodeDescription);
			}
			if (Protocol == null)
			{
				return;
			}
			foreach (Type component in nodeDescription.Components)
			{
				if (SerializationUidUtils.HasSelfUid(component))
				{
					Protocol.RegisterTypeWithSerialUid(component);
				}
			}
		}

		public ICollection<NodeDescription> GetNodeDescriptions(Type componentClass)
		{
			return nodeDescriptionsByAnyComponent.GetOrDefault(componentClass, Collections.EmptyList<NodeDescription>);
		}

		public ICollection<NodeDescription> GetNodeDescriptionsByNotComponent(Type componentClass)
		{
			return nodeDescriptionsByNotComponent.GetOrDefault(componentClass, Collections.EmptyList<NodeDescription>);
		}

		public ICollection<NodeDescription> GetNodeDescriptionsWithNotComponentsOnly()
		{
			return nodeDescriptionsWithNotComponentsOnly;
		}

		public void AssertRegister(NodeDescription nodeDescription)
		{
			if (!nodeDescriptions.Contains(nodeDescription))
			{
				throw new NodeNotRegisteredException(nodeDescription);
			}
		}

		public NodeClassInstanceDescription GetOrCreateNodeClassDescription(Type nodeClass, ICollection<Type> additionalComponents = null)
		{
			StandardNodeDescription nodeDesc = new StandardNodeDescription(nodeClass, additionalComponents);
			if (nodeDesc.IsEmpty)
			{
				return NodeClassInstanceDescription.EMPTY;
			}
			nodeDesc = (StandardNodeDescription)nodeDescriptionStorage.ComputeIfAbsent(nodeDesc, (NodeDescription d) => d);
			NodeClassInstanceDescription nodeClassInstanceDescription = null;
			nodeClassInstanceDescription = ((!nodeDesc.isAdditionalComponents) ? nodeClassDescByNodeClass.ComputeIfAbsent(nodeClass, (Type k) => new NodeClassInstanceDescription(k, nodeDesc)) : new NodeClassInstanceDescription(nodeClass, nodeDesc));
			Collections.Enumerator<Type> enumerator = Collections.GetEnumerator(nodeClassInstanceDescription.NodeDescription.Components);
			while (enumerator.MoveNext())
			{
				nodeClassDescsByComponent.Add(enumerator.Current, nodeClassInstanceDescription);
			}
			return nodeClassInstanceDescription;
		}

		public ICollection<NodeClassInstanceDescription> GetClassInstanceDescriptionByComponent(Type component)
		{
			HashSet<NodeClassInstanceDescription> value;
			if (nodeClassDescsByComponent.TryGetValue(component, out value))
			{
				return value;
			}
			return Collections.EmptyList<NodeClassInstanceDescription>();
		}
	}
}
