using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[SerialVersionUID(635824352209995226L)]
	public class ShaftAimingReticleEffectComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject assetReticle;

		public GameObject AssetReticle
		{
			get
			{
				return assetReticle;
			}
			set
			{
				assetReticle = value;
			}
		}

		public Animator ReticleAnimator
		{
			get;
			set;
		}

		public GameObject InstanceReticle
		{
			get;
			set;
		}

		public Transform DynamicReticle
		{
			get;
			set;
		}

		public CanvasGroup ReticleGroup
		{
			get;
			set;
		}

		public ShaftReticleSpotBehaviour ShaftReticleSpotBehaviour
		{
			get;
			set;
		}

		public Material ReticleSpotMaterialInstance
		{
			get;
			set;
		}

		public Vector2 CanvasSize
		{
			get;
			set;
		}
	}
}
