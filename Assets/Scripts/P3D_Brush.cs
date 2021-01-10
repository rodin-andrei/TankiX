using System;
using UnityEngine;

[Serializable]
public class P3D_Brush
{
	public string Name;
	public float Opacity;
	public float Angle;
	public Vector2 Offset;
	public Vector2 Size;
	public P3D_BlendMode Blend;
	public Texture2D Shape;
	public Color Color;
	public Vector2 Direction;
	public Texture2D Detail;
	public Vector2 DetailScale;
}
