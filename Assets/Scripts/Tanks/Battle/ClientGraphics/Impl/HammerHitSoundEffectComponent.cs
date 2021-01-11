using System.Collections.Generic;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class HammerHitSoundEffectComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject staticHitSoundAsset;

		[SerializeField]
		private GameObject targetHitSoundAsset;

		[SerializeField]
		private float staticHitSoundDuration;

		[SerializeField]
		private float targetHitSoundDuration;

		public GameObject StaticHitSoundAsset
		{
			get
			{
				return staticHitSoundAsset;
			}
			set
			{
				staticHitSoundAsset = value;
			}
		}

		public GameObject TargetHitSoundAsset
		{
			get
			{
				return targetHitSoundAsset;
			}
			set
			{
				targetHitSoundAsset = value;
			}
		}

		public float StaticHitSoundDuration
		{
			get
			{
				return staticHitSoundDuration;
			}
			set
			{
				staticHitSoundDuration = value;
			}
		}

		public float TargetHitSoundDuration
		{
			get
			{
				return targetHitSoundDuration;
			}
			set
			{
				targetHitSoundDuration = value;
			}
		}

		public List<HitTarget> DifferentTargetsByHit
		{
			get;
			set;
		}

		private void Awake()
		{
			DifferentTargetsByHit = new List<HitTarget>();
		}
	}
}
