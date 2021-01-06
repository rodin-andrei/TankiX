using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class IsisRayEffectBehaviour : MonoBehaviour
	{
		[SerializeField]
		private ParticleSystem expandingBlob;
		[SerializeField]
		private ParticleSystem contractingBlob;
		[SerializeField]
		private LineRenderer[] rays;
		[SerializeField]
		private Material damagingBallMaterial;
		[SerializeField]
		private Material damagingRayMaterial;
		[SerializeField]
		private Material healingBallMaterial;
		[SerializeField]
		private Material healingRayMaterial;
		[SerializeField]
		private int curvesCount;
		[SerializeField]
		private float minCurveMagnitude;
		[SerializeField]
		private float maxCurveMagnitude;
		[SerializeField]
		private float offsetToCamera;
		[SerializeField]
		private float smoothingSpeed;
		[SerializeField]
		private float[] textureTilings;
		[SerializeField]
		private float[] textureOffsets;
		[SerializeField]
		private float verticesSpacing;
		[SerializeField]
		private float curveLength;
		[SerializeField]
		private float curveSpeed;
		[SerializeField]
		private Color healColor;
		[SerializeField]
		private Color damageColor;
		[SerializeField]
		private Material[] damagingRayMaterials;
		[SerializeField]
		private Material[] healingRayMaterials;
	}
}
