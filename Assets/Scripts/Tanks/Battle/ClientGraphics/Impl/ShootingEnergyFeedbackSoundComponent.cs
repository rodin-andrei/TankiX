using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShootingEnergyFeedbackSoundComponent : BehaviourComponent
	{
		[SerializeField]
		private WeaponFeedbackSoundBehaviour lowEnergyFeedbackSoundAsset;

		public WeaponFeedbackSoundBehaviour LowEnergyFeedbackSoundAsset
		{
			get
			{
				return lowEnergyFeedbackSoundAsset;
			}
		}

		public WeaponFeedbackSoundBehaviour Instance
		{
			get;
			set;
		}
	}
}
