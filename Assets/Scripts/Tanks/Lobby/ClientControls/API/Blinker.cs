using UnityEngine;
using System;
using UnityEngine.Events;

namespace Tanks.Lobby.ClientControls.API
{
	public class Blinker : MonoBehaviour
	{
		[Serializable]
		public class OnBlinkEvent : UnityEvent<float>
		{
		}

		public float maxValue;
		public float minValue;
		public float speedCoeff;
		public float initialBlinkTimeInterval;
		public float minBlinkTimeInterval;
		public float blinkTimeIntervalDecrement;
		public float timeOffset;
		public OnBlinkEvent onBlink;
	}
}
