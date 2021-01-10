using UnityEngine;

namespace Edelweiss.DecalSystem
{
	public class DecalProjectorComponent : GenericDecalProjectorComponent<Decals, DecalProjectorBase, DecalsMesh>
	{
		public bool ignoreMeshMinimizer;
		public bool useCustomMeshMinimizerMaximumErrors;
		[SerializeField]
		private float m_MeshMinimizerMaximumAbsoluteError;
		[SerializeField]
		private float m_MeshMinimizerMaximumRelativeError;
		public bool affectMeshes;
		public bool affectTerrains;
		public bool useTerrainDensity;
		public float terrainDensity;
	}
}
