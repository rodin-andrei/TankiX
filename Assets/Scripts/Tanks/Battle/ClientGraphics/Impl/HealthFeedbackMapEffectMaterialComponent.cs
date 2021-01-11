using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class HealthFeedbackMapEffectMaterialComponent : BehaviourComponent
	{
		[SerializeField]
		private Material sourceMaterial;

		[SerializeField]
		private float intensitySpeed = 2f;

		public float IntensitySpeed
		{
			get
			{
				return intensitySpeed;
			}
		}

		public Material SourceMaterial
		{
			get
			{
				return sourceMaterial;
			}
		}
	}
}
