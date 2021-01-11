using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class VisualMountPointComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Transform MountPoint
		{
			get;
			set;
		}
	}
}
