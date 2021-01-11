using System.Collections.Generic;
using LeopotamGroup.Pooling;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class MainPoolContainerComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Transform MainContainerTransform;

		public readonly Dictionary<GameObject, PoolContainer> PrefabToPoolDict = new Dictionary<GameObject, PoolContainer>();
	}
}
