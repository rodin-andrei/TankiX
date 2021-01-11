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

		public WeaponFeedbackSoundBehaviour SmokyHitFeedbackSoundAsset
		{
			get
			{
				return smokyHitFeedbackSoundAsset;
			}
		}

		public WeaponFeedbackSoundBehaviour ThunderHitFeedbackSoundAsset
		{
			get
			{
				return thunderHitFeedbackSoundAsset;
			}
		}

		public WeaponFeedbackSoundBehaviour RailgunHitFeedbackSoundAsset
		{
			get
			{
				return railgunHitFeedbackSoundAsset;
			}
		}

		public WeaponFeedbackSoundBehaviour RicochetHitFeedbackSoundAsset
		{
			get
			{
				return ricochetHitFeedbackSoundAsset;
			}
		}

		public WeaponFeedbackSoundBehaviour ShaftHitFeedbackSoundAsset
		{
			get
			{
				return shaftHitFeedbackSoundAsset;
			}
		}

		public WeaponFeedbackSoundBehaviour HammerHitFeedbackSoundAsset
		{
			get
			{
				return hammerHitFeedbackSoundAsset;
			}
		}

		public SoundController IsisHealingFeedbackController
		{
			get
			{
				return isisHealingFeedbackController;
			}
		}

		public SoundController IsisAttackFeedbackController
		{
			get
			{
				return isisAttackFeedbackController;
			}
		}

		public SoundController FreezeWeaponAttackController
		{
			get
			{
				return freezeWeaponAttackController;
			}
		}

		public SoundController FlamethrowerWeaponAttackController
		{
			get
			{
				return flamethrowerWeaponAttackController;
			}
		}
	}
}
