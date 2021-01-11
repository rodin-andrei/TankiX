using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class DailyBonusSoundsBehaviour : MonoBehaviour
	{
		[SerializeField]
		private AudioSource upgrade;

		[SerializeField]
		private AudioSource click;

		[SerializeField]
		private AudioSource hover;

		[SerializeField]
		private AudioSource take;

		public void PlayUpgrade()
		{
			Play(upgrade);
		}

		public void PlayClick()
		{
			Play(click);
		}

		public void PlayHover()
		{
			Play(hover);
		}

		public void PlayTake()
		{
			Play(take);
		}

		private void Play(AudioSource source)
		{
			source.Stop();
			source.Play();
		}
	}
}
