using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientHangar.Impl
{
	public class SoundListenerMusicTransitionsComponent : BehaviourComponent
	{
		[SerializeField]
		private float musicTransitionSec = 0.5f;

		[SerializeField]
		private float transitionCardsContainerTheme = 0.2f;

		[SerializeField]
		private float transitionModuleTheme = 0.2f;

		public float MusicTransitionSec
		{
			get
			{
				return musicTransitionSec;
			}
		}

		public float TransitionCardsContainerTheme
		{
			get
			{
				return transitionCardsContainerTheme;
			}
		}

		public float TransitionModuleTheme
		{
			get
			{
				return transitionModuleTheme;
			}
		}
	}
}
