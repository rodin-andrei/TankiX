using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class AnimatedNumber : MonoBehaviour
	{
		[SerializeField]
		private AnimationCurve curve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		[SerializeField]
		private TextMeshProUGUI numberText;

		[SerializeField]
		private string format = "{0:#}";

		[SerializeField]
		private float duration = 0.15f;

		private float time;

		private float _currentValue;

		private float targetValue = -1f;

		private bool immediatePending;

		private float currentValue
		{
			get
			{
				return _currentValue;
			}
			set
			{
				_currentValue = value;
				numberText.text = string.Format(format, currentValue);
			}
		}

		public float Value
		{
			get
			{
				return targetValue;
			}
			set
			{
				targetValue = value;
				time = 0f;
			}
		}

		public void SetFormat(string newFormat)
		{
			format = newFormat;
		}

		public void SetImmediate(float value)
		{
			targetValue = value;
			currentValue = targetValue;
			numberText.text = string.Format(format, value);
			immediatePending = !base.gameObject.activeInHierarchy;
		}

		private void OnEnable()
		{
			if (!immediatePending)
			{
				currentValue = 0f;
			}
			immediatePending = false;
		}

		private void Update()
		{
			if (currentValue != targetValue)
			{
				currentValue = Mathf.Lerp(currentValue, targetValue, curve.Evaluate(Mathf.Clamp01(time / duration)));
				time += Time.deltaTime;
			}
		}
	}
}
