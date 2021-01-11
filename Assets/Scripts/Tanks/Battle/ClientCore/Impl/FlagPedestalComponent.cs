using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	[Shared]
	[SerialVersionUID(4898317045808451550L)]
	public class FlagPedestalComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Vector3 Position
		{
			get;
			set;
		}
	}
}
