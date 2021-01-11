using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientDataStructures.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class JoinAllLogPart : LogPart
	{
		private readonly ICollection<Entity> resolvedEntities;

		private readonly HandlerArgument handlerArgument;

		private string GetNodeClassName
		{
			get
			{
				return handlerArgument.ClassInstanceDescription.NodeClass.Name;
			}
		}

		public JoinAllLogPart(HandlerArgument handlerArgument, ICollection<Entity> resolvedEntities)
		{
			this.resolvedEntities = resolvedEntities;
			this.handlerArgument = handlerArgument;
		}

		public Optional<string> GetSkipReason()
		{
			return (resolvedEntities.Count != 0) ? Optional<string>.empty() : Optional<string>.of(string.Format("\tMissing JoinAll node={0}, parameter=[{1}]\n\t", GetNodeClassName, handlerArgument.NodeNumber + 1));
		}
	}
}
