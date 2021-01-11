using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class HealthFeedbackCameraPreparedComponent : Component
	{
		public float TargetIntensity
		{
			get;
			set;
		}

		public HealthFeedbackPostEffect HealthFeedbackPostEffect
		{
			get;
			set;
		}

		public HealthFeedbackCameraPreparedComponent(HealthFeedbackPostEffect healthFeedbackPostEffect)
		{
			HealthFeedbackPostEffect = healthFeedbackPostEffect;
		}
	}
}
