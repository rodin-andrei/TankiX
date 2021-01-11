using System;
using UnityEngine;
using UnityEngine.Events;

namespace Tanks.Lobby.ClientControls.API
{
	public class Blinker : MonoBehaviour
	{
		[Serializable]
		public class OnBlinkEvent : UnityEvent<float>
		{
		}

		private const float FORWARD = 1f;

		private const float BACKWARD = -1f;

		public float maxValue = 1f;

		public float minValue;

		public float speedCoeff = 1f;

		public float initialBlinkTimeInterval = 1f;

		public float minBlinkTimeInterval = 1f;

		public float blinkTimeIntervalDecrement;

		public float timeOffset;

		private float speed;

		private float valueDelta;

		private float time;

		private float currentBlinkTimeInterval;

		private float value;

		private float timeBeforeBlink;

		public OnBlinkEvent onBlink;

		private void OnEnable()
		{
			Reset();
		}

		private void OnDisable()
		{
			StopBlink();
		}

		public void StartBlink()
		{
			Reset();
			onBlink.Invoke(maxValue);
			base.enabled = true;
		}

		public void StopBlink()
		{
			base.enabled = false;
			onBlink.Invoke(maxValue);
		}

		private void Reset()
		{
			timeBeforeBlink = timeOffset;
			currentBlinkTimeInterval = initialBlinkTimeInterval;
			valueDelta = maxValue - minValue;
			value = maxValue;
			speed = GetSpeed(-1f);
		}

		private void Update()
		{
			timeBeforeBlink -= Time.deltaTime;
			if (timeBeforeBlink > 0f)
			{
				return;
			}
			time += Time.deltaTime;
			value += speed * Time.deltaTime;
			if (value > maxValue)
			{
				value = maxValue;
			}
			if (value < minValue)
			{
				value = minValue;
			}
			if (time >= currentBlinkTimeInterval)
			{
				if (currentBlinkTimeInterval > minBlinkTimeInterval)
				{
					currentBlinkTimeInterval -= blinkTimeIntervalDecrement;
					if (currentBlinkTimeInterval < minBlinkTimeInterval)
					{
						currentBlinkTimeInterval = minBlinkTimeInterval;
					}
				}
				time = 0f;
				speed = GetSpeed((!(speed < 0f)) ? (-1f) : 1f);
			}
			onBlink.Invoke(value);
		}

		private float GetSpeed(float direction)
		{
			return direction * speedCoeff * valueDelta / currentBlinkTimeInterval;
		}
	}
}
