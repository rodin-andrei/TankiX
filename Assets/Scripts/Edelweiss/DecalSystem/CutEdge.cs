using System;

namespace Edelweiss.DecalSystem
{
	internal struct CutEdge
	{
		public CutEdge(int a_Vertex1Index, int a_Vertex2Index) : this()
		{
		}

		public int vertex1Index;
		public int vertex2Index;
		public int newVertex1Index;
		public int newVertex2Index;
	}
}
