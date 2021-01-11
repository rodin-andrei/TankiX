using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class KillTankSoundEffectComponent : BehaviourComponent
	{
		[SerializeField]
		private KillTankSoundEffectBehaviour effectPrefab;

		public KillTankSoundEffectBehaviour EffectPrefab
		{
			get
			{
				return effectPrefab;
			}
		}
	}
}
