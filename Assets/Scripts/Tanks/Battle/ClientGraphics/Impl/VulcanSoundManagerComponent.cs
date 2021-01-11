using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class VulcanSoundManagerComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public AudioSource CurrentSound
		{
			get;
			set;
		}

		public Dictionary<AudioSource, float> SoundsWithDelay
		{
			get;
			set;
		}

		public VulcanSoundManagerComponent()
		{
			SoundsWithDelay = new Dictionary<AudioSource, float>();
		}
	}
}
