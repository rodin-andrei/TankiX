using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class GraphicEffectComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject EffectObject
		{
			get;
			set;
		}

		public GraphicEffectComponent()
		{
		}

		public GraphicEffectComponent(GameObject effectObject)
		{
			EffectObject = effectObject;
		}
	}
}
