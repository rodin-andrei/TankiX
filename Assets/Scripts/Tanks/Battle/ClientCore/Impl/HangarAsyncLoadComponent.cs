using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class HangarAsyncLoadComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public AsyncOperation AsyncOperation
		{
			get;
			set;
		}
	}
}
