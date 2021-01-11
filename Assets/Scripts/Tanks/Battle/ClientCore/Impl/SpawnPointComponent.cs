using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class SpawnPointComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Vector3 Position
		{
			get;
			set;
		}

		public Quaternion Rotation
		{
			get;
			set;
		}
	}
}
