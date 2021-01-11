namespace MIConvexHull
{
	internal sealed class ConvexFaceInternal
	{
		public int Index;

		public int[] AdjacentFaces;

		public IndexBuffer VerticesBeyond;

		public int FurthestVertex;

		public int[] Vertices;

		public double[] Normal;

		public bool IsNormalFlipped;

		public double Offset;

		public int Tag;

		public ConvexFaceInternal Previous;

		public ConvexFaceInternal Next;

		public bool InList;

		public ConvexFaceInternal(int dimension, int index, IndexBuffer beyondList)
		{
			Index = index;
			AdjacentFaces = new int[dimension];
			VerticesBeyond = beyondList;
			Normal = new double[dimension];
			Vertices = new int[dimension];
		}
	}
}
