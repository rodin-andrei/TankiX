using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class LogicToVisualTemperatureConverterComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private AnimationCurve logicTemperatureToVisualTemperature;

		public float ConvertToVisualTemperature(float logicTemperature)
		{
			return logicTemperatureToVisualTemperature.Evaluate(logicTemperature);
		}
	}
}
