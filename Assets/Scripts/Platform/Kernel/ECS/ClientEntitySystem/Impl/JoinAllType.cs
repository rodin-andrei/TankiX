using System;
using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientDataStructures.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class JoinAllType : JoinType
	{
		public Optional<Type> ContextComponent
		{
			get
			{
				return Optional<Type>.empty();
			}
		}

		public ICollection<Entity> GetEntities(NodeCollectorImpl nodeCollector, NodeDescription nodeDescription, Entity key)
		{
			return nodeCollector.GetEntities(nodeDescription);
		}
	}
}
