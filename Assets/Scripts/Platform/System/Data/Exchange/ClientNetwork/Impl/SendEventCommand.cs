using System.Linq;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Library.ClientProtocol.API;

namespace Platform.System.Data.Exchange.ClientNetwork.Impl
{
	public class SendEventCommand : AbstractCommand
	{
		[ProtocolVaried]
		[ProtocolParameterOrder(0)]
		public Event E
		{
			get;
			set;
		}

		[ProtocolParameterOrder(1)]
		public Entity[] Entities
		{
			get;
			set;
		}

		public SendEventCommand()
		{
		}

		public SendEventCommand(Entity[] entities, Event e)
		{
			Entities = entities;
			E = e;
		}

		public SendEventCommand Init(Entity[] entities, Event e)
		{
			Entities = entities;
			E = e;
			return this;
		}

		public override void Execute(Engine engine)
		{
			Flow.Current.SendEventSilent(E, Entities);
		}

		protected bool Equals(SendEventCommand other)
		{
			return E.Equals(other.E) && EqualsCollection(Entities, other.Entities);
		}

		private bool EqualsCollection(Entity[] a, Entity[] b)
		{
			if (a.Length != b.Length)
			{
				return false;
			}
			for (int i = 0; i < a.Length; i++)
			{
				if (!a.Contains(b[i]))
				{
					return false;
				}
			}
			return true;
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
			return Equals((SendEventCommand)obj);
		}

		public override int GetHashCode()
		{
			return (((E != null) ? E.GetHashCode() : 0) * 397) ^ ((Entities != null) ? CalculateHashCode() : 0);
		}

		private int CalculateHashCode()
		{
			int num = 0;
			Entity[] entities = Entities;
			foreach (Entity entity in entities)
			{
				num += entity.GetHashCode();
			}
			return num;
		}

		public override string ToString()
		{
			return string.Format("SendEventCommand: Event={0} Entities={1}", E, EcsToStringUtil.EnumerableWithoutTypeToString(Entities, ", "));
		}
	}
}
