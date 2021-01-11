using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class CollectSplashTargetsEvent : Event
	{
		public SplashHitData SplashHit
		{
			get;
			set;
		}

		public CollectSplashTargetsEvent()
		{
		}

		public CollectSplashTargetsEvent(SplashHitData splashHit)
		{
			SplashHit = splashHit;
		}
	}
}
