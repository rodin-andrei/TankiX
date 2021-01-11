using System.Collections;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.Impl
{
	public class AnimationTriggerDelayBehaviour : MonoBehaviour
	{
		public float dealy;

		public Animator animator;

		public string trigger;

		private void Start()
		{
			StartCoroutine(ExecuteAfterTime(dealy));
		}

		private IEnumerator ExecuteAfterTime(float time)
		{
			yield return new WaitForSeconds(time);
			animator.SetTrigger(trigger);
		}
	}
}
