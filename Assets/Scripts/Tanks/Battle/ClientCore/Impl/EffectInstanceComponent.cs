using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class EffectInstanceComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject GameObject
		{
			get;
			set;
		}

		public EffectInstanceComponent(GameObject gameObject)
		{
			GameObject = gameObject;
			Object.DontDestroyOnLoad(gameObject);
		}
	}
}
