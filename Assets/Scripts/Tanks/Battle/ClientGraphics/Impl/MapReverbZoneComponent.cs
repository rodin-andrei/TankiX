using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class MapReverbZoneComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject ReverbZoneRoot
		{
			get;
			set;
		}

		public MapReverbZoneComponent(GameObject reverbZoneRoot)
		{
			ReverbZoneRoot = reverbZoneRoot;
		}
	}
}
