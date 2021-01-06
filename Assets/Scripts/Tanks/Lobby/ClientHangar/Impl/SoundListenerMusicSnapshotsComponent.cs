using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientHangar.Impl
{
	public class SoundListenerMusicSnapshotsComponent : BehaviourComponent
	{
		[SerializeField]
		private int hymnLoopSnapshot;
		[SerializeField]
		private int battleResultMusicSnapshot;
		[SerializeField]
		private int cardsContainerMusicSnapshot;
		[SerializeField]
		private int garageModuleMusicSnapshot;
	}
}
