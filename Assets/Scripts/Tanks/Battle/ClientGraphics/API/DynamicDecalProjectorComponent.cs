using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class DynamicDecalProjectorComponent : BehaviourComponent
	{
		[SerializeField]
		private Material material;

		[SerializeField]
		private Color color = new Color(0.5f, 0.5f, 0.5f, 0.5f);

		[SerializeField]
		private bool emit;

		[SerializeField]
		private float lifeTime = 20f;

		[SerializeField]
		private float halfSize = 1f;

		[SerializeField]
		private float randomKoef = 0.1f;

		[SerializeField]
		private bool randomRotation = true;

		[SerializeField]
		private int atlasHTilesCount = 1;

		[SerializeField]
		private int atlasVTilesCount = 1;

		[SerializeField]
		private float distance = 100f;

		[SerializeField]
		[HideInInspector]
		private int[] surfaceAtlasPositions = new int[5];

		public Material Material
		{
			get
			{
				return material;
			}
			set
			{
				material = value;
			}
		}

		public Color Color
		{
			get
			{
				return color;
			}
		}

		public bool Emmit
		{
			get
			{
				return emit;
			}
		}

		public float LifeTime
		{
			get
			{
				return lifeTime;
			}
		}

		public float HalfSize
		{
			get
			{
				return halfSize + Random.Range(0f, halfSize * randomKoef);
			}
		}

		public Vector3 Up
		{
			get
			{
				return (!randomRotation) ? Vector3.up : Random.insideUnitSphere;
			}
		}

		public int AtlasHTilesCount
		{
			get
			{
				return atlasHTilesCount;
			}
		}

		public int AtlasVTilesCount
		{
			get
			{
				return atlasVTilesCount;
			}
		}

		public float Distance
		{
			get
			{
				return distance;
			}
		}

		public int[] SurfaceAtlasPositions
		{
			get
			{
				return surfaceAtlasPositions;
			}
			set
			{
				surfaceAtlasPositions = value;
			}
		}
	}
}
