using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TankJumpSoundComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public AudioSource Sound
		{
			get;
			set;
		}

		public TankJumpSoundComponent()
		{
		}

		public TankJumpSoundComponent(AudioSource sound)
		{
			Sound = sound;
		}
	}
}
