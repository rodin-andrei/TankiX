using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class GraffitiAntiSpamTimerComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public class GraffityInfo
		{
			public CreateGraffitiEvent CreateGraffitiEvent;

			public float Time;
		}

		public Dictionary<string, GraffityInfo> GraffitiDelayDictionary = new Dictionary<string, GraffityInfo>();

		public float SprayDelay
		{
			get;
			set;
		}
	}
}
