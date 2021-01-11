using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientHangar.Impl
{
	public class SoundListenerMusicSnapshotsComponent : BehaviourComponent
	{
		[SerializeField]
		private int hymnLoopSnapshot;

		[SerializeField]
		private int battleResultMusicSnapshot = 1;

		[SerializeField]
		private int cardsContainerMusicSnapshot = 2;

		[SerializeField]
		private int garageModuleMusicSnapshot = 3;

		public int HymnLoopSnapshot
		{
			get
			{
				return hymnLoopSnapshot;
			}
		}

		public int BattleResultMusicSnapshot
		{
			get
			{
				return battleResultMusicSnapshot;
			}
		}

		public int CardsContainerMusicSnapshot
		{
			get
			{
				return cardsContainerMusicSnapshot;
			}
		}

		public int GarageModuleMusicSnapshot
		{
			get
			{
				return garageModuleMusicSnapshot;
			}
		}
	}
}
