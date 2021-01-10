using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class HitFeedbackSoundsComponent : BehaviourComponent
	{
		[SerializeField]
		private WeaponFeedbackSoundBehaviour hammerHitFeedbackSoundAsset;
		[SerializeField]
		private WeaponFeedbackSoundBehaviour smokyHitFeedbackSoundAsset;
		[SerializeField]
		private WeaponFeedbackSoundBehaviour thunderHitFeedbackSoundAsset;
		[SerializeField]
		private WeaponFeedbackSoundBehaviour railgunHitFeedbackSoundAsset;
		[SerializeField]
		private WeaponFeedbackSoundBehaviour ricochetHitFeedbackSoundAsset;
		[SerializeField]
		private WeaponFeedbackSoundBehaviour shaftHitFeedbackSoundAsset;
		[SerializeField]
		private SoundController isisHealingFeedbackController;
		[SerializeField]
		private SoundController isisAttackFeedbackController;
		[SerializeField]
		private SoundController freezeWeaponAttackController;
		[SerializeField]
		private SoundController flamethrowerWeaponAttackController;
	}
}
