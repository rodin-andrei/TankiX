using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class BonusClientConfigComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public float parachuteFoldingDuration = 1f;

		public float parachuteFoldingScaleByY = 0.67f;

		public float parachuteFoldingScaleByXZ = 1.25f;

		public float disappearingDuration = 5f;

		public float angleSpeed = 90f;
	}
}
