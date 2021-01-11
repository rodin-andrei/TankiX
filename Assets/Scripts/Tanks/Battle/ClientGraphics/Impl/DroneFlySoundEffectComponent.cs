using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class DroneFlySoundEffectComponent : BehaviourComponent
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
