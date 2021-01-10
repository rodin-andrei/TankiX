using UnityEngine;

namespace Edelweiss.DecalSystem
{
	public class Decals : GenericDecals<Decals, DecalProjectorBase, DecalsMesh>
	{
		[SerializeField]
		private MeshMinimizerMode m_MeshMinimizerMode;
		[SerializeField]
		private float m_MeshMinimizerMaximumAbsoluteError;
		[SerializeField]
		private float m_MeshMinimizerMaximumRelativeError;
	}
}
