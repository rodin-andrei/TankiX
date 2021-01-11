using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	public class AnimatedDiffProgress : MonoBehaviour
	{
		[SerializeField]
		private AnimationCurve curve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		[SerializeField]
		private UIRectClipper fill;

		[SerializeField]
		private UIRectClipper background;

		[SerializeField]
		private UIRectClipper diff;

		[SerializeField]
		private float duration = 0.15f;

		private float normalizedValue;

		private float newValue;

		private Coroutine coroutine;

		public Image FillImage
		{
			get
			{
				return fill.GetComponent<Image>();
			}
		}

		public Image DiffImage
		{
			get
			{
				return diff.GetComponent<Image>();
			}
		}

		private void Awake()
		{
			fill.FromX = 0f;
			fill.ToX = 0f;
			diff.FromX = 0f;
			diff.ToX = 0f;
			if (background != null)
			{
				background.FromX = 0f;
				background.ToX = 1f;
			}
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

		private IEnumerator AnimateTo(float startValue, float targetValue, float startNewValue, float targetNewValue)
		{
			float time = 0f;
			float value2 = startValue;
			diff.ToX = startNewValue;
			diff.FromX = value2;
			for (; time < duration; time += Time.deltaTime)
			{
				value2 = startValue + (targetValue - startValue) * curve.Evaluate(Mathf.Clamp01(time / duration));
				fill.ToX = value2;
				diff.FromX = value2;
				diff.ToX = startNewValue + (targetNewValue - startNewValue) * curve.Evaluate(Mathf.Clamp01(time / duration));
				if (background != null)
				{
					background.FromX = diff.ToX;
				}
				yield return null;
			}
			fill.ToX = targetValue;
			diff.FromX = targetValue;
			diff.ToX = targetNewValue;
			if (background != null)
			{
				background.FromX = targetNewValue;
			}
		}
	}
}
