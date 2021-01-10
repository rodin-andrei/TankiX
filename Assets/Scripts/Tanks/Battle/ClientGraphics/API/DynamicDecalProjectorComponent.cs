using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class DynamicDecalProjectorComponent : BehaviourComponent
	{
		[SerializeField]
		private Material material;
		[SerializeField]
		private Color color;
		[SerializeField]
		private bool emit;
		[SerializeField]
		private float lifeTime;
		[SerializeField]
		private float halfSize;
		[SerializeField]
		private float randomKoef;
		[SerializeField]
		private bool randomRotation;
		[SerializeField]
		private int atlasHTilesCount;
		[SerializeField]
		private int atlasVTilesCount;
		[SerializeField]
		private float distance;
		[SerializeField]
		private int[] surfaceAtlasPositions;
	}
}
