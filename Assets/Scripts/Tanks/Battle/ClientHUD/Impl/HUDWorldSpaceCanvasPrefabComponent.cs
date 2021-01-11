using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class HUDWorldSpaceCanvasPrefabComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject hudWorldSpaceCanvasPrefab;
	}
}
