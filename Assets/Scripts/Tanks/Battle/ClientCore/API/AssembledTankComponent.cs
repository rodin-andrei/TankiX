using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	[SerialVersionUID(635824352905635226L)]
	public class AssembledTankComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject AssemblyRoot
		{
			get;
			set;
		}

		public AssembledTankComponent()
		{
		}

		public AssembledTankComponent(GameObject assemblyRoot)
		{
			AssemblyRoot = assemblyRoot;
		}
	}
}
