using System;
using System.Collections.Generic;
using System.Linq;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientDataStructures.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class AbstractNodeDescription : NodeDescription, IComparable<NodeDescription>
	{
		public static readonly AbstractNodeDescription EMPTY = new AbstractNodeDescription(Collections.EmptyList<Type>());

		private readonly ICollection<Type> baseComponents;

		private readonly ICollection<Type> components;

		private readonly ICollection<Type> notComponents;

		private readonly int hashCode;

		[Inject]
		public static ComponentBitIdRegistry ComponentBitIdRegistry
		{
			get;
			set;
		}

		public bool IsEmpty
		{
			get;
			private set;
		}

		public BitSet NodeComponentBitId
		{
			get;
			private set;
		}

		public BitSet NotNodeComponentBitId
		{
			get;
			private set;
		}

		public bool isAdditionalComponents
		{
			get
			{
				return baseComponents.Count != components.Count;
			}
		}

		public ICollection<Type> BaseComponents
		{
			get
			{
				return baseComponents;
			}
		}

		public ICollection<Type> Components
		{
			get
			{
				return components;
			}
		}

		public ICollection<Type> NotComponents
		{
			get
			{
				return notComponents;
			}
		}

		protected AbstractNodeDescription(ICollection<Type> components)
			: this(components, Collections.EmptyList<Type>())
		{
		}

		protected AbstractNodeDescription(ICollection<Type> components, ICollection<Type> notComponents, ICollection<Type> additionalComponents = null)
		{
			baseComponents = components.ToArray();
			this.components = components;
			this.notComponents = notComponents;
			if (additionalComponents != null && additionalComponents.Count > 0)
			{
				foreach (Type item in additionalComponents.Where((Type c) => !baseComponents.Contains(c)))
				{
					components.Add(item);
				}
			}
			NodeComponentBitId = new BitSet();
			NotNodeComponentBitId = new BitSet();
			CalcCode(components, NodeComponentBitId);
			CalcCode(notComponents, NotNodeComponentBitId);
			hashCode = CalcGetHashCode();
			IsEmpty = components.Count == 0 && notComponents.Count == 0;
		}

		private int CalcGetHashCode()
		{
			int num = NodeComponentBitId.GetHashCode();
			return 31 * num + NotNodeComponentBitId.GetHashCode();
		}

		private void CalcCode(ICollection<Type> components, BitSet componentCode)
		{
			Collections.Enumerator<Type> enumerator = Collections.GetEnumerator(components);
			while (enumerator.MoveNext())
			{
				componentCode.Set(ComponentBitIdRegistry.GetComponentBitId(enumerator.Current));
			}
		}

		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(this, obj))
			{
				return true;
			}
			if (!(obj is AbstractNodeDescription))
			{
				return false;
			}
			AbstractNodeDescription abstractNodeDescription = (AbstractNodeDescription)obj;
			if (hashCode != abstractNodeDescription.hashCode)
			{
				return false;
			}
			if (!NodeComponentBitId.Equals(abstractNodeDescription.NodeComponentBitId))
			{
				return false;
			}
			if (!NotNodeComponentBitId.Equals(abstractNodeDescription.NotNodeComponentBitId))
			{
				return false;
			}
			return true;
		}

		public override int GetHashCode()
		{
			return hashCode;
		}

		public int CompareTo(NodeDescription other)
		{
			return getKey().CompareTo(((AbstractNodeDescription)other).getKey());
		}

		private string getKey()
		{
			return string.Join(":", (from c in components
				select c.FullName into n
				orderby n
				select n).ToArray()) + "-NOT-" + string.Join(":", (from c in notComponents
				select c.FullName into n
				orderby n
				select n).ToArray());
		}

		public override string ToString()
		{
			return "AbstractNodeDescription components: " + EcsToStringUtil.ToString(Components) + " notComponents: " + EcsToStringUtil.ToString(NotComponents);
		}
	}
}
