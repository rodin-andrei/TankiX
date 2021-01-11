using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.Video;

namespace Tanks.Lobby.ClientLoading.Impl
{
	public class IntroCinematicComponent : BehaviourComponent
	{
		private VideoPlayer player;

		private bool hintVisible;

		private GameObject videoPrefab;

		private Animator animator;

		private void OnEnable()
		{
			player = GetComponentInChildren<VideoPlayer>(true);
			player.Prepare();
		}

		private void OnVideoLoaded(Object obj)
		{
			player.clip = (VideoClip)obj;
		}

		private void OnGUI()
		{
			if (!(player == null) && player.isPlaying && (Event.current.type == EventType.KeyDown || Event.current.type == EventType.MouseDown))
			{
				if (hintVisible && Event.current.keyCode == KeyCode.Space)
				{
					animator.SetTrigger("HideVideo");
					return;
				}
				animator.SetTrigger("ShowHint");
				hintVisible = true;
			}
		}

		public void OnIntroHide()
		{
			Object.Destroy(base.gameObject);
		}

		public void Play()
		{
			animator = GetComponent<Animator>();
			animator.SetTrigger("ShowVideo");
			player.SetTargetAudioSource(0, player.GetComponent<AudioSource>());
			player.loopPointReached += OnFinishPlay;
			if (player.isPrepared)
			{
				player.Play();
				return;
			}
			player.prepareCompleted += delegate(VideoPlayer source)
			{
				source.Play();
			};
		}

		private void OnFinishPlay(VideoPlayer _)
		{
			animator.SetTrigger("HideVideo");
		}
	}
}
