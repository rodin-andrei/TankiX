using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class ShotValidateComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public int BlockValidateMask
		{
			get;
			set;
		}

		public int UnderGroundValidateMask
		{
			get;
			set;
		}

		public GameObject[] RaycastExclusionGameObjects
		{
			get;
			set;
		}

		public ShotValidateComponent()
		{
			BlockValidateMask = LayerMasks.STATIC;
			UnderGroundValidateMask = LayerMasks.STATIC;
		}
	}
}
