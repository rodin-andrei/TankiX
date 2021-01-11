using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class SelfUserRankSoundEffectInstanceComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public AudioSource Source
		{
			get;
			set;
		}

		public SelfUserRankSoundEffectInstanceComponent(AudioSource source)
		{
			Source = source;
		}
	}
}
