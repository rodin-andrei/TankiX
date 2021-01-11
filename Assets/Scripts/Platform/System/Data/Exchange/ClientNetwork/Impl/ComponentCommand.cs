using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Platform.System.Data.Exchange.ClientNetwork.Impl
{
	public abstract class ComponentCommand : EntityCommand
	{
		[ProtocolVaried]
		[ProtocolParameterOrder(1)]
		public Type ComponentType
		{
			get;
			set;
		}

		public ComponentCommand()
		{
		}

		public ComponentCommand(Entity entity, Type componentType)
			: base(entity)
		{
			ComponentType = componentType;
		}

		protected bool Equals(ComponentCommand other)
		{
			return object.Equals(ComponentType, other.ComponentType);
		}

		public override bool Equals(object obj)
		{
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
			return Equals((ComponentCommand)obj);
		}

		public override int GetHashCode()
		{
			return (ComponentType != null) ? ComponentType.GetHashCode() : 0;
		}
	}
}
