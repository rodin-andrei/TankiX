using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TankSoundRootComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Transform SoundRootTransform
		{
			get;
			set;
		}

		public TankSoundRootComponent()
		{
		}

		public TankSoundRootComponent(Transform soundRootTransform)
		{
			SoundRootTransform = soundRootTransform;
		}
	}
}
