using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TankExplosionSoundComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public AudioSource Sound
		{
			get;
			set;
		}

		public TankExplosionSoundComponent()
		{
		}

		public TankExplosionSoundComponent(AudioSource sound)
		{
			Sound = sound;
		}
	}
}
