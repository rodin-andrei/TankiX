using System;
using UnityEngine;

[Serializable]
public class P3D_UndoState
{
	public P3D_UndoState(Texture2D newTexture)
	{
	}

	public Texture2D Texture;
	public int Width;
	public int Height;
	public Color32[] Pixels;
}
