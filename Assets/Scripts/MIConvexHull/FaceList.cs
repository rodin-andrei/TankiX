namespace MIConvexHull
{
	internal sealed class FaceList
	{
		private ConvexFaceInternal first;

		private ConvexFaceInternal last;

		public ConvexFaceInternal First
		{
			get
			{
				return first;
			}
		}

		private void AddFirst(ConvexFaceInternal face)
		{
			face.InList = true;
			first.Previous = face;
			face.Next = first;
			first = face;
		}

		public void Add(ConvexFaceInternal face)
		{
			if (face.InList)
			{
				if (first.VerticesBeyond.Count < face.VerticesBeyond.Count)
				{
					Remove(face);
					AddFirst(face);
				}
				return;
			}
			face.InList = true;
			if (first != null && first.VerticesBeyond.Count < face.VerticesBeyond.Count)
			{
				first.Previous = face;
				face.Next = first;
				first = face;
				return;
			}
			if (last != null)
			{
				last.Next = face;
			}
			face.Previous = last;
			last = face;
			if (first == null)
			{
				first = face;
			}
		}

		public void Remove(ConvexFaceInternal face)
		{
			if (face.InList)
			{
				face.InList = false;
				if (face.Previous != null)
				{
					face.Previous.Next = face.Next;
				}
				else if (face.Previous == null)
				{
					first = face.Next;
				}
				if (face.Next != null)
				{
					face.Next.Previous = face.Previous;
				}
				else if (face.Next == null)
				{
					last = face.Previous;
				}
				face.Next = null;
				face.Previous = null;
			}
		}
	}
}
