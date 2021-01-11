using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Battle.ClientCore.API
{
	[Shared]
	[SerialVersionUID(196833391289212110L)]
	public class SelfSplashHitEvent : SelfHitEvent
	{
		[ProtocolOptional]
		public List<HitTarget> SplashTargets
		{
			get;
			set;
		}

		public SelfSplashHitEvent()
		{
		}

		public SelfSplashHitEvent(List<HitTarget> targets, StaticHit staticHit, List<HitTarget> splashTargets)
			: base(targets, staticHit)
		{
			SplashTargets = splashTargets;
		}
	}
}
