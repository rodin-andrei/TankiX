using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class BonusRegionClientConfigComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public float maxOpacityRadius = 20f;

		public float minOpacityRadius = 30f;

		public float opacityChangingSpeed = 1f;
	}
}
