using System;

namespace Edelweiss.DecalSystem
{
	internal struct OptimizeEdge
	{
		public OptimizeEdge(int a_Vertex1Index, int a_Vertex2Index, int a_Triangle1Index) : this()
		{
		}

		public int vertex1Index;
		public int vertex2Index;
		public int triangle1Index;
		public int triangle2Index;
	}
}
