using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	[ExecuteInEditMode]
	public class AnimatedDiffRadialProgress : MonoBehaviour
	{
		[SerializeField]
		private AnimationCurve curve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		[SerializeField]
		private Image fill;

		[SerializeField]
		private Image background;

		[SerializeField]
		private Image diff;

		[SerializeField]
		private float duration = 0.15f;

		[SerializeField]
		private float normalizedValue;

		[SerializeField]
		private float newValue;

		private Coroutine coroutine;

		private void Awake()
		{
			fill.fillAmount = 0f;
			diff.fillAmount = 0f;
		}

		public void Set(float value, float newValue)
		{
			if (coroutine != null)
			{
				StopCoroutine(coroutine);
				coroutine = null;
			}
			if (base.gameObject.activeInHierarchy)
			{
				coroutine = StartCoroutine(AnimateTo(normalizedValue, value, value, newValue));
			}
			normalizedValue = value;
			this.newValue = newValue;
		}

		private void OnEnable()
		{
			StartCoroutine(AnimateTo(0f, normalizedValue, normalizedValue, newValue));
		}

		private void Update()
		{
			if (!Application.isPlaying)
			{
				diff.fillAmount = normalizedValue;
				fill.fillAmount = normalizedValue + (newValue - normalizedValue);
			}
		}

		private IEnumerator AnimateTo(float startValue, float targetValue, float startNewValue, float targetNewValue)
		{
			float time = 0f;
			float value2 = startValue;
			for (; time < duration; time += Time.deltaTime)
			{
				value2 = startValue + (targetValue - startValue) * curve.Evaluate(Mathf.Clamp01(time / duration));
				diff.fillAmount = value2;
				fill.fillAmount = startNewValue + (targetNewValue - startNewValue) * curve.Evaluate(Mathf.Clamp01(time / duration));
				yield return null;
			}
		}
	}
}
