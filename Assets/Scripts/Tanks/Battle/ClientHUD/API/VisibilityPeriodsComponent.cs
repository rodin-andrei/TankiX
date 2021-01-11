using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.API
{
	public class VisibilityPeriodsComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public int firstIntervalInSec = 30;

		public int lastIntervalInSec = 30;

		public int spaceIntervalInSec = 5;

		public int lastBlinkingIntervalInSec = 10;
	}
}
