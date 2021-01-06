using UnityEngine;
using Tanks.Battle.ClientGraphics.Impl;
using System.Collections.Generic;

namespace Tanks.Battle.ClientGraphics.API
{
	public class GrassGenerator : MonoBehaviour
	{
		public GrassLocationParams grassLocationParams;
		public List<GrassPrefabData> grassPrefabDataList;
		public List<GrassCell> grassCells;
		public float farCullingDistance;
		public float nearCullingDistance;
		public float fadeRange;
		public float denstyMultipler;
	}
}
