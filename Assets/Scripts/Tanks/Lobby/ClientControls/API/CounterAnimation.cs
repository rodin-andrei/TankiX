using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	[RequireComponent(typeof(Text))]
	public class CounterAnimation : MonoBehaviour
	{
		[Range(0f, 1f)]
		public float value;

		private int targetValue;

		private Text text;

		private void OnEnable()
		{
			text = GetComponent<Text>();
			targetValue = int.Parse(text.text);
		}

		private void Update()
		{
			text.text = ((int)(value * (float)targetValue)).ToStringSeparatedByThousands();
		}
	}
}
