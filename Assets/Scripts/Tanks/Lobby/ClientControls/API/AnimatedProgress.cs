using System.Collections;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class AnimatedProgress : MonoBehaviour
	{
		[SerializeField]
		private AnimationCurve curve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		[SerializeField]
		private UIRectClipper fill;

		[SerializeField]
		private UIRectClipper background;

		[SerializeField]
		private float duration = 0.15f;

		private float normalizedValue;

		private Coroutine coroutine;

		public float NormalizedValue
		{
			get
			{
				return normalizedValue;
			}
			set
			{
				if (coroutine != null)
				{
					StopCoroutine(coroutine);
					coroutine = null;
				}
				if (base.gameObject.activeInHierarchy)
				{
					coroutine = StartCoroutine(AnimateTo(normalizedValue, value));
				}
				normalizedValue = value;
			}
		}

		public float InitialNormalizedValue
		{
			set
			{
				normalizedValue = value;
				fill.ToX = value;
				background.FromX = value;
			}
		}

		private void Awake()
		{
			fill.FromX = 0f;
			fill.ToX = 0f;
			background.FromX = 0f;
			background.ToX = 1f;
		}

		private void OnEnable()
		{
			StartCoroutine(AnimateTo(0f, normalizedValue));
		}

		private IEnumerator AnimateTo(float startValue, float targetValue)
		{
			float time = 0f;
			float value = startValue;
			while (!Mathf.Approximately(value, targetValue))
			{
				value = startValue + (targetValue - startValue) * curve.Evaluate(Mathf.Clamp01(time / duration));
				fill.ToX = value;
				background.FromX = value;
				yield return null;
				time += Time.deltaTime;
			}
			fill.ToX = targetValue;
			background.FromX = targetValue;
		}
	}
}
