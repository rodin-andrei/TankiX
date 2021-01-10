using System;
using UnityEngine;

[Serializable]
public struct P3D_GroupMask
{
	public P3D_GroupMask(int newMask) : this()
	{
	}

	[SerializeField]
	private int mask;
}
