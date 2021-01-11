using System.Collections;
using Platform.Library.ClientLocale.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class AnimatedLong : MonoBehaviour
	{
		[SerializeField]
		private AnimationCurve curve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		[SerializeField]
		private float duration = 0.15f;

		[SerializeField]
		private TextMeshProUGUI numberText;

		[SerializeField]
		private string format = "{0:#}";

		private long value = -1L;

		private Coroutine coroutine;

		private Animator animator;

		private bool immediatePending;

		public long Value
		{
			get
			{
				return value;
			}
			set
			{
				if (this.value != value)
				{
					if (coroutine != null)
					{
						StopCoroutine(coroutine);
						coroutine = null;
					}
					StopAnimation();
					if (base.gameObject.activeInHierarchy)
					{
						coroutine = StartCoroutine(AnimateTo(this.value, value));
					}
					this.value = value;
				}
			}
		}

		public void SetFormat(string newFormat)
		{
			format = newFormat;
		}

		public void SetImmediate(long value)
		{
			if (coroutine != null)
			{
				StopCoroutine(coroutine);
				coroutine = null;
			}
			StopAnimation();
			this.value = value;
			SetText(value);
			immediatePending = !base.gameObject.activeInHierarchy;
		}

		private void OnEnable()
		{
			animator = GetComponent<Animator>();
			if (!immediatePending)
			{
				coroutine = StartCoroutine(AnimateTo(0L, value));
			}
			immediatePending = false;
		}

		private IEnumerator AnimateTo(long startValue, long targetValue)
		{
			if (targetValue > startValue)
			{
				StartAnimation();
			}
			float time = 0f;
			long val = startValue;
			while (!Mathf.Approximately(val, targetValue))
			{
				val = startValue + (long)((float)(targetValue - startValue) * curve.Evaluate(Mathf.Clamp01(time / duration)));
				SetText(val);
				yield return null;
				time += Time.deltaTime;
			}
			StopAnimation();
		}

		private void SetText(long val)
		{
			numberText.text = string.Format(LocaleUtils.GetCulture(), format, val);
		}

		private void StartAnimation()
		{
			if (animator != null)
			{
				animator.SetBool("animated", true);
			}
		}

		private void StopAnimation()
		{
			if (animator != null)
			{
				animator.SetBool("animated", false);
			}
		}
	}
}
