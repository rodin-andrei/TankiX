using Platform.Kernel.OSGi.ClientCore.API;
using UnityEngine;
using UnityEngine.UI;

namespace Platform.Library.ClientUnityIntegration.API
{
	public class ActivatorScreen : UnityAwareActivator<AutoCompleting>
	{
		private enum State
		{
			IDLE,
			PREPARED,
			PREPARED_IDLE,
			FADE_OUT
		}

		[SerializeField]
		private CanvasGroup backgroundGroup;

		[SerializeField]
		private Text entranceMessage;

		[SerializeField]
		private float fadeOutTimeSec = 1f;

		private State state;

		private float fadeOutSpeed;

		private new void OnEnable()
		{
			fadeOutSpeed = -1f / fadeOutTimeSec;
			backgroundGroup.alpha = 1f;
			state = State.IDLE;
		}

		private void Update()
		{
			float alpha = backgroundGroup.alpha;
			switch (state)
			{
			case State.FADE_OUT:
				alpha += fadeOutSpeed * Time.deltaTime;
				if (alpha <= 0f)
				{
					Object.Destroy(base.gameObject);
				}
				else
				{
					backgroundGroup.alpha = alpha;
				}
				break;
			case State.PREPARED:
				state = State.PREPARED_IDLE;
				break;
			case State.PREPARED_IDLE:
				entranceMessage.gameObject.SetActive(false);
				state = State.FADE_OUT;
				break;
			}
		}

		protected override void Activate()
		{
			state = State.PREPARED;
		}
	}
}
