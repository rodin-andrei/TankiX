using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class ValidateSplashHitPointsEvent : Platform.Kernel.ECS.ClientEntitySystem.API.Event
	{
		public SplashHitData SplashHit
		{
			get;
			set;
		}

		public List<GameObject> excludeObjects
		{
			get;
			set;
		}

		public ValidateSplashHitPointsEvent()
		{
		}

		public ValidateSplashHitPointsEvent(SplashHitData splashHit, List<GameObject> excludeObjects)
		{
			SplashHit = splashHit;
			this.excludeObjects = excludeObjects;
		}
	}
}
