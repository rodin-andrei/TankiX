using System;

[Serializable]
public struct P3D_Rect
{
	public P3D_Rect(int newXMin, int newXMax, int newYMin, int newYMax) : this()
	{
	}

	public int XMin;
	public int XMax;
	public int YMin;
	public int YMax;
}
