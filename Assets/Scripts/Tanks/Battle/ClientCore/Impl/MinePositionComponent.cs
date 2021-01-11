using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	[Shared]
	[SerialVersionUID(1431673085710L)]
	public class MinePositionComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Vector3 Position
		{
			get;
			set;
		}
	}
}
