using System;
using UnityEngine;

[Serializable]
public class P3D_PaintableTexture
{
	public P3D_Group Group;
	public int MaterialIndex;
	public string TextureName;
	public P3D_CoordType Coord;
	public bool DuplicateOnAwake;
	public bool CreateOnAwake;
	public int CreateWidth;
	public int CreateHeight;
	public P3D_Format CreateFormat;
	public Color CreateColor;
	public bool CreateMipMaps;
	public string CreateKeyword;
	[SerializeField]
	private P3D_Painter painter;
}
