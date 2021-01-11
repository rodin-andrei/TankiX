using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class EffectRemovingSoundComponent : BehaviourComponent
	{
		[SerializeField]
		private AudioSource sound;

		public AudioSource Sound
		{
			get
			{
				return sound;
			}
		}
	}
}
