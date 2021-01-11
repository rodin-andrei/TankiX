using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class MineActivationGraphicsComponent : Component
	{
		public float ActivationStartTime
		{
			get;
			set;
		}

		public MineActivationGraphicsComponent()
		{
		}

		public MineActivationGraphicsComponent(float activationStartTime)
		{
			ActivationStartTime = activationStartTime;
		}
	}
}
