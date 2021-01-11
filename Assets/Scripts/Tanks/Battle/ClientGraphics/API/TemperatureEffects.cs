using Tanks.Battle.ClientGraphics.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	[RequireComponent(typeof(TemperatureVisualControllerComponent))]
	public class TemperatureEffects : MonoBehaviour, TemperatureChangeListener
	{
		[SerializeField]
		private GameObject freezingPrefab;

		[SerializeField]
		private GameObject burningPrefab;

		[SerializeField]
		private Transform mountPoint;

		private TemperatureEffect freezingEffect;

		private TemperatureEffect burningEffect;

		private void Awake()
		{
			burningEffect = InstansiateEffect(burningPrefab);
			freezingEffect = InstansiateEffect(freezingPrefab);
			GetComponent<TemperatureVisualControllerComponent>().listeners.Add(this);
		}

		public void TemperatureChanged(float temperature)
		{
			UpdateBurningEffect(temperature);
			UpdateFreezingEffect(temperature);
		}

		private void UpdateBurningEffect(float temperature)
		{
			bool flag = temperature > 0f;
			burningEffect.gameObject.SetActive(flag);
			if (flag)
			{
				burningEffect.SetTemperature(temperature);
			}
		}

		private void UpdateFreezingEffect(float temperature)
		{
			bool flag = temperature < 0f;
			freezingEffect.gameObject.SetActive(flag);
			if (flag)
			{
				freezingEffect.SetTemperature(temperature);
			}
		}

		private TemperatureEffect InstansiateEffect(GameObject prefab)
		{
			GameObject gameObject = Object.Instantiate(prefab);
			gameObject.transform.SetParent(mountPoint, false);
			gameObject.SetActive(false);
			return gameObject.GetComponent<TemperatureEffect>();
		}
	}
}
