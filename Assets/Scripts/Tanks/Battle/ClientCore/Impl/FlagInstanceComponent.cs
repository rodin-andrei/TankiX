using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	[SerialVersionUID(635824353088195226L)]
	public class FlagInstanceComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject FlagInstance
		{
			get;
			set;
		}

		public GameObject FlagBeam
		{
			get;
			set;
		}
	}
}
