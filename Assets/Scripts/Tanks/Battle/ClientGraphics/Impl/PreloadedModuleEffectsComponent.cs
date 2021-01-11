using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class PreloadedModuleEffectsComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Dictionary<string, GameObject> PreloadedEffects
		{
			get;
			set;
		}

		public PreloadedModuleEffectsComponent(Dictionary<string, GameObject> preloadedEffects)
		{
			PreloadedEffects = preloadedEffects;
		}
	}
}
