using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class GoldSoundConfigComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private AudioSource goldNotificationSound;

		public AudioSource GoldNotificationSound
		{
			get
			{
				return goldNotificationSound;
			}
			set
			{
				goldNotificationSound = value;
			}
		}
	}
}
