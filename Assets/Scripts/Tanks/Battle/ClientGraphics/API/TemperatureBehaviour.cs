using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class TemperatureBehaviour : MonoBehaviour
	{
		public List<TemperatureVisualControllerComponent> temperatureControllers;

		private float temperature;

		private float tempDelta = 0.003f;

		private bool plusPressed;

		private bool minusPressed;

		public void Update()
		{
			bool keyDown = Input.GetKeyDown(KeyCode.KeypadPlus);
			bool keyUp = Input.GetKeyUp(KeyCode.KeypadPlus);
			plusPressed = keyDown || (plusPressed && !keyUp);
			if (plusPressed)
			{
				temperature += tempDelta;
			}
			bool keyDown2 = Input.GetKeyDown(KeyCode.KeypadMinus);
			bool keyUp2 = Input.GetKeyUp(KeyCode.KeypadMinus);
			minusPressed = keyDown2 || (minusPressed && !keyUp2);
			if (minusPressed)
			{
				temperature -= tempDelta;
			}
			temperature = Mathf.Clamp(temperature, -1f, 1f);
			if (Input.GetKeyDown(KeyCode.Space))
			{
				temperature = 0f;
			}
			foreach (TemperatureVisualControllerComponent temperatureController in temperatureControllers)
			{
				temperatureController.Temperature = temperature;
			}
		}
	}
}
