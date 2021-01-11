using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class CartridgeCaseEjectorComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject casePrefab;

		public float initialAngularSpeed;

		public float initialSpeed;
	}
}
