using System;
using UnityEngine;

[Serializable]
public struct P3D_Group
{
	public P3D_Group(int newIndex) : this()
	{
	}

	[SerializeField]
	private int index;
}
