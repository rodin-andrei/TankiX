using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientHangar.API;
using UnityEngine;

namespace Tanks.Lobby.ClientHangar.Impl
{
	public class HangarLocationsComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Dictionary<HangarLocation, Transform> Locations
		{
			get;
			set;
		}
	}
}
