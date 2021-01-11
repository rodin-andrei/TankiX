using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl.Batching.Zones
{
	public sealed class Zone
	{
		public List<Submesh> contents;

		public Bounds bounds;

		public Material material
		{
			get
			{
				return contents[0].material;
			}
		}

		public int lightmapIndex
		{
			get
			{
				return contents[0].lightmapIndex;
			}
		}
	}
}
