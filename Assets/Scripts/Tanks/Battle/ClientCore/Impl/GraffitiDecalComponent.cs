using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	[Shared]
	[SerialVersionUID(636100801609006236L)]
	public class GraffitiDecalComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Vector3 SprayPosition
		{
			get;
			set;
		}

		public Vector3 SprayDirection
		{
			get;
			set;
		}

		public Vector3 SprayUpDirection
		{
			get;
			set;
		}

		public GraffitiDecalComponent()
		{
		}

		public GraffitiDecalComponent(Vector3 sprayPosition, Vector3 sprayDirection, Vector3 sprayUpDirection)
		{
			SprayPosition = sprayPosition;
			SprayDirection = sprayDirection;
			SprayUpDirection = sprayUpDirection;
		}
	}
}
