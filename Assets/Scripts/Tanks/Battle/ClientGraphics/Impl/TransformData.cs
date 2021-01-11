using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct TransformData : IEquatable<TransformData>
	{
		public Vector3 Position
		{
			get;
			set;
		}

		public Quaternion Rotation
		{
			get;
			set;
		}

		public bool Equals(TransformData data)
		{
			return Position == data.Position && Rotation == data.Rotation;
		}

		public override bool Equals(object obj)
		{
			if (obj is TransformData)
			{
				return Equals((TransformData)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Position.GetHashCode() ^ Rotation.GetHashCode();
		}

		public static bool operator ==(TransformData transformData1, TransformData transformData2)
		{
			return transformData1.Equals(transformData2);
		}

		public static bool operator !=(TransformData transformData1, TransformData transformData2)
		{
			return !transformData1.Equals(transformData2);
		}
	}
}
