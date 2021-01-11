namespace MIConvexHull
{
	internal sealed class ConnectorList
	{
		private FaceConnector first;

		private FaceConnector last;

		public FaceConnector First
		{
			get
			{
				return first;
			}
		}

		private void AddFirst(FaceConnector connector)
		{
			first.Previous = connector;
			connector.Next = first;
			first = connector;
		}

		public void Add(FaceConnector element)
		{
			if (last != null)
			{
				last.Next = element;
			}
			element.Previous = last;
			last = element;
			if (first == null)
			{
				first = element;
			}
		}

		public void Remove(FaceConnector connector)
		{
			if (connector.Previous != null)
			{
				connector.Previous.Next = connector.Next;
			}
			else if (connector.Previous == null)
			{
				first = connector.Next;
			}
			if (connector.Next != null)
			{
				connector.Next.Previous = connector.Previous;
			}
			else if (connector.Next == null)
			{
				last = connector.Previous;
			}
			connector.Next = null;
			connector.Previous = null;
		}
	}
}
