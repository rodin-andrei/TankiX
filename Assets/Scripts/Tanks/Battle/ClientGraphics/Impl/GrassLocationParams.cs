using System;
using UnityEngine;
using System.Collections.Generic;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[Serializable]
	public class GrassLocationParams
	{
		public Texture2D uvMask;
		public bool whiteAsEmpty;
		public float blackThreshold;
		public List<GameObject> terrainObjects;
		public float densityPerMeter;
		public float grassCombineWidth;
	}
}
