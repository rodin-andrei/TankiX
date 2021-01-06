using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientHangar.Impl
{
	public class SoundListenerMusicTransitionsComponent : BehaviourComponent
	{
		[SerializeField]
		private float musicTransitionSec;
		[SerializeField]
		private float transitionCardsContainerTheme;
		[SerializeField]
		private float transitionModuleTheme;
	}
}
