using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class EnergyInjectionSoundEffectComponent : BehaviourComponent
	{
		[SerializeField]
		private SoundController sound;

		public SoundController Sound
		{
			get
			{
				return sound;
			}
		}
	}
}
