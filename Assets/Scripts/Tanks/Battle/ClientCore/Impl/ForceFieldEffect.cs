using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class ForceFieldEffect : MonoBehaviour
	{
		public float alpha;
		public MeshCollider outerMeshCollider;
		public MeshCollider innerMeshCollider;
		public MeshRenderer meshRenderer;
		public DomeWaveGenerator waveGenerator;
		public Material enemyMaterial;
		[SerializeField]
		private AudioSource hitSourceAsset;
		[SerializeField]
		private AudioClip[] hitClips;
	}
}
