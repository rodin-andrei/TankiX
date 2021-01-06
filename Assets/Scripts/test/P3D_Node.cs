using System;
using UnityEngine;

[Serializable]
public class P3D_Node
{
	public Bounds Bound;
	public bool Split;
	public int PositiveIndex;
	public int NegativeIndex;
	public int TriangleIndex;
	public int TriangleCount;
}
