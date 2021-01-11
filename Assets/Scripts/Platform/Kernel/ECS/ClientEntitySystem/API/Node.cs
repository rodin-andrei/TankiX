namespace Platform.Kernel.ECS.ClientEntitySystem.API
{
	public class Node
	{
		private Entity entity;

		public virtual Entity Entity
		{
			get
			{
				return entity;
			}
			set
			{
				entity = value;
			}
		}

		public T SendEvent<T>(T eventInstance) where T : Event
		{
			return Entity.SendEvent(eventInstance);
		}

		public override bool Equals(object o)
		{
			if (this == o)
			{
				return true;
			}
			if (o is Entity)
			{
				return entity.Equals(o);
			}
			if (o == null || GetType() != o.GetType())
			{
				return false;
			}
			Node node = (Node)o;
			if ((entity == null) ? (node.entity != null) : (!entity.Equals(node.entity)))
			{
				return false;
			}
			return true;
		}

		public override int GetHashCode()
		{
			return (entity != null) ? entity.GetHashCode() : 0;
		}

		public override string ToString()
		{
			return Entity.ToString();
		}
	}
}
