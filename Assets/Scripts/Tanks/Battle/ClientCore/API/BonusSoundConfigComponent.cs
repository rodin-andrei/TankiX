using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.API
{
	public class BonusSoundConfigComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private AudioSource bonusTakingSound;

		public AudioSource BonusTakingSound
		{
			get
			{
				return bonusTakingSound;
			}
			set
			{
				bonusTakingSound = value;
			}
		}
	}
}
