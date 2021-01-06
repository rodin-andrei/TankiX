using System;
using UnityEngine;

[Serializable]
public class P3D_Painter
{
	public bool Dirty;
	public Texture2D Canvas;
	public Vector2 Tiling;
	public Vector2 Offset;
}
