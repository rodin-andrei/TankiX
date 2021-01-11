using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TrackDustComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[NonSerialized]
		public float[] leftTrackDustDelay;

		[NonSerialized]
		public float[] rightTrackDustDelay;
	}
}
