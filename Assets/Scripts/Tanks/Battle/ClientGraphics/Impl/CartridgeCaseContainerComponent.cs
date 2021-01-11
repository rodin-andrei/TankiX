using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[SerialVersionUID(635824352101335226L)]
	public class CartridgeCaseContainerComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public readonly Queue<GameObject> Cartridges = new Queue<GameObject>();
	}
}
