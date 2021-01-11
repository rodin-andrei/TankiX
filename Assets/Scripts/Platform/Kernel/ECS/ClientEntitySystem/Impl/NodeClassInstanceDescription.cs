using System;
using System.Collections.Generic;
using System.Reflection;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientDataStructures.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class NodeClassInstanceDescription
	{
		public static readonly NodeClassInstanceDescription EMPTY = new NodeClassInstanceDescription(typeof(Node), AbstractNodeDescription.EMPTY);

		private readonly Type nodeClass;

		private NodeDescription nodeDescription;

		private readonly IDictionary<Type, FieldInfo> fieldByComponent;

		[Inject]
		public static FlowInstancesCache Cache
		{
			get;
			set;
		}

		public NodeDescription NodeDescription
		{
			get
			{
				return nodeDescription;
			}
			set
			{
				nodeDescription = value;
			}
		}

		public Type NodeClass
		{
			get
			{
				return nodeClass;
			}
		}

		public NodeClassInstanceDescription(Type nodeClass, NodeDescription nodeDescription)
		{
			this.nodeClass = nodeClass;
			this.nodeDescription = nodeDescription;
			fieldByComponent = CreateAndPopulateFieldByComponent();
		}

		private IDictionary<Type, FieldInfo> CreateAndPopulateFieldByComponent()
		{
			IDictionary<Type, FieldInfo> dictionary = new Dictionary<Type, FieldInfo>();
			FieldInfo[] fields = nodeClass.GetFields();
			foreach (FieldInfo fieldInfo in fields)
			{
				if (typeof(Component).IsAssignableFrom(fieldInfo.FieldType))
				{
					dictionary[fieldInfo.FieldType] = fieldInfo;
				}
			}
			return dictionary;
		}

		public void SetComponent(Node node, Type componentClass, Component component)
		{
			if (fieldByComponent.ContainsKey(componentClass))
			{
				fieldByComponent[componentClass].SetValue(node, component);
			}
		}

		public Node CreateNode(EntityInternal entity)
		{
			Node nodeInstance = Cache.GetNodeInstance(nodeClass);
			nodeInstance.Entity = entity;
			try
			{
				Collections.Enumerator<Type> enumerator = Collections.GetEnumerator(nodeDescription.Components);
				while (enumerator.MoveNext())
				{
					Type current = enumerator.Current;
					SetComponent(nodeInstance, current, entity.GetComponent(current));
				}
				return nodeInstance;
			}
			catch (Exception e)
			{
				throw new ConvertEntityToNodeException(nodeClass, entity, e);
			}
		}

		public void FreeNode(Node node)
		{
			Cache.FreeNodeInstance(node);
		}

		public override bool Equals(object o)
		{
			if (this == o)
			{
				return true;
			}
			if (o == null || GetType() != o.GetType())
			{
				return false;
			}
			NodeClassInstanceDescription nodeClassInstanceDescription = (NodeClassInstanceDescription)o;
			return NodeClass == nodeClassInstanceDescription.NodeClass;
		}

		public override int GetHashCode()
		{
			return 629 + NodeClass.GetHashCode();
		}
	}
}
