using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class CalculateSplashCenterEvent : Event
	{
		public SplashHitData SplashHit
		{
			get;
			set;
		}

		public CalculateSplashCenterEvent()
		{
		}

		public CalculateSplashCenterEvent(SplashHitData splashHit)
		{
			SplashHit = splashHit;
		}
	}
}
