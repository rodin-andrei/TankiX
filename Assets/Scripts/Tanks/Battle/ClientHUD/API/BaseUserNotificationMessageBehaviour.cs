using UnityEngine;

namespace Tanks.Battle.ClientHUD.API
{
	public abstract class BaseUserNotificationMessageBehaviour : MonoBehaviour
	{
		[SerializeField]
		protected Animator animator;

		[SerializeField]
		private float lifeTime = 3f;

		private float timer;

		private bool destroyTriggerSend;

		private bool isDestroying;

		private void OnEnable()
		{
			isDestroying = false;
			destroyTriggerSend = false;
			timer = lifeTime;
		}

		private void Update()
		{
			if (isDestroying && !destroyTriggerSend)
			{
				if (timer <= 0f)
				{
					animator.SetTrigger("FadeOut");
					destroyTriggerSend = true;
				}
				else
				{
					timer -= Time.deltaTime;
				}
			}
		}

		private void OnNotificationFadeIn()
		{
			isDestroying = true;
		}

		private void OnNotificationFadeOut()
		{
			SendMessageUpwards("OnUserNotificationFadeOut", SendMessageOptions.RequireReceiver);
			Object.DestroyObject(base.gameObject);
		}

		public void Play()
		{
			base.gameObject.SetActive(true);
		}
	}
}
