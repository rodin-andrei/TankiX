using UnityEngine;
using System.Collections.Generic;

public class P3D_Tree
{
	[SerializeField]
	private Mesh mesh;
	[SerializeField]
	private int vertexCount;
	[SerializeField]
	private int subMeshIndex;
	[SerializeField]
	private List<P3D_Node> nodes;
	[SerializeField]
	private List<P3D_Triangle> triangles;
}
