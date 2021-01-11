using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TankFrictionSoundEffectComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private float minValuableFrictionPower;

		[SerializeField]
		private float maxValuableFrictionPower = 1f;

		[SerializeField]
		private SoundController metallFrictionSourcePrefab;

		[SerializeField]
		private SoundController stoneFrictionSourcePrefab;

		[SerializeField]
		private SoundController frictionContactSourcePrefab;

		public SoundController MetallFrictionSourcePrefab
		{
			get
			{
				return metallFrictionSourcePrefab;
			}
			set
			{
				metallFrictionSourcePrefab = value;
			}
		}

		public SoundController StoneFrictionSourcePrefab
		{
			get
			{
				return stoneFrictionSourcePrefab;
			}
			set
			{
				stoneFrictionSourcePrefab = value;
			}
		}

		public SoundController FrictionContactSourcePrefab
		{
			get
			{
				return frictionContactSourcePrefab;
			}
			set
			{
				frictionContactSourcePrefab = value;
			}
		}

		public float MinValuableFrictionPower
		{
			get
			{
				return minValuableFrictionPower;
			}
			set
			{
				minValuableFrictionPower = value;
			}
		}

		public float MaxValuableFrictionPower
		{
			get
			{
				return maxValuableFrictionPower;
			}
			set
			{
				maxValuableFrictionPower = value;
			}
		}

		public SoundController MetallFrictionSourceInstance
		{
			get;
			set;
		}

		public SoundController StoneFrictionSourceInstance
		{
			get;
			set;
		}

		public SoundController FrictionContactSourceInstance
		{
			get;
			set;
		}
	}
}
