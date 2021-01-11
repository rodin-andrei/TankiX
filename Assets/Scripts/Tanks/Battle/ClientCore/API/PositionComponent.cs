using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	[Shared]
	[SerialVersionUID(4605414188335188027L)]
	public class PositionComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Vector3 Position
		{
			get;
			set;
		}

		public PositionComponent()
		{
		}

		public PositionComponent(Vector3 position)
		{
			Position = position;
		}
	}
}
