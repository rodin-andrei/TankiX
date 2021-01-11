using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class ShellInstanceComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject ShellInstance
		{
			get;
			set;
		}

		public ShellInstanceComponent()
		{
		}

		public ShellInstanceComponent(GameObject shellInstance)
		{
			ShellInstance = shellInstance;
		}
	}
}
