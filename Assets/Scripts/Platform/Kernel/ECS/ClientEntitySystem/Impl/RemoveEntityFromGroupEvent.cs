using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	[SerialVersionUID(1431504381185L)]
	public class RemoveEntityFromGroupEvent : Event
	{
		public Type GroupComponentType
		{
			get;
			private set;
		}

		public RemoveEntityFromGroupEvent(Type groupComponentType)
		{
			GroupComponentType = groupComponentType;
		}
	}
}
