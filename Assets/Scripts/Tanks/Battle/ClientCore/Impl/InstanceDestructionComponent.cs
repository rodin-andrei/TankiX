using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	[SerialVersionUID(635824352950915226L)]
	public class InstanceDestructionComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject GameObject
		{
			get;
			set;
		}

		public InstanceDestructionComponent()
		{
		}

		public InstanceDestructionComponent(GameObject gameObject)
		{
			GameObject = gameObject;
		}
	}
}
