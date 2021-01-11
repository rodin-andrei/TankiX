using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics
{
	public class MineSoundsComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private AudioSource dropGroundSound;

		[SerializeField]
		private AudioSource dropNonGroundSound;

		[SerializeField]
		private AudioSource deactivationSound;

		[SerializeField]
		private AudioSource explosionSound;

		public AudioSource DropGroundSound
		{
			get
			{
				return dropGroundSound;
			}
			set
			{
				dropGroundSound = value;
			}
		}

		public AudioSource DropNonGroundSound
		{
			get
			{
				return dropNonGroundSound;
			}
			set
			{
				dropNonGroundSound = value;
			}
		}

		public AudioSource DeactivationSound
		{
			get
			{
				return deactivationSound;
			}
			set
			{
				deactivationSound = value;
			}
		}

		public AudioSource ExplosionSound
		{
			get
			{
				return explosionSound;
			}
			set
			{
				explosionSound = value;
			}
		}
	}
}
