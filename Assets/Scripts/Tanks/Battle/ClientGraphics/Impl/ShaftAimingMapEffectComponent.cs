using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShaftAimingMapEffectComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private float shrubsHidingRadiusMin = 20f;

		[SerializeField]
		private float shrubsHidingRadiusMax = 80f;

		[SerializeField]
		private Shader hidingLeavesShader;

		[SerializeField]
		private Shader defaultLeavesShader;

		[SerializeField]
		private Shader hidingBillboardTreesShader;

		[SerializeField]
		private Shader defaultBillboardTreesShader;

		public float ShrubsHidingRadiusMin
		{
			get
			{
				return shrubsHidingRadiusMin;
			}
			set
			{
				shrubsHidingRadiusMin = value;
			}
		}

		public float ShrubsHidingRadiusMax
		{
			get
			{
				return shrubsHidingRadiusMax;
			}
			set
			{
				shrubsHidingRadiusMax = value;
			}
		}

		public Shader HidingLeavesShader
		{
			get
			{
				return hidingLeavesShader;
			}
			set
			{
				hidingLeavesShader = value;
			}
		}

		public Shader DefaultLeavesShader
		{
			get
			{
				return defaultLeavesShader;
			}
			set
			{
				defaultLeavesShader = value;
			}
		}

		public Shader HidingBillboardTreesShader
		{
			get
			{
				return hidingBillboardTreesShader;
			}
			set
			{
				hidingBillboardTreesShader = value;
			}
		}

		public Shader DefaultBillboardTreesShader
		{
			get
			{
				return defaultBillboardTreesShader;
			}
			set
			{
				defaultBillboardTreesShader = value;
			}
		}
	}
}
