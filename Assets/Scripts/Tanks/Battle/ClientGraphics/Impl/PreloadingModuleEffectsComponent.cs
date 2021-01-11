using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class PreloadingModuleEffectsComponent : BehaviourComponent
	{
		[SerializeField]
		private Transform preloadedModuleEffectsRoot;

		[SerializeField]
		private PreloadingModuleEffectData[] preloadingModuleEffects;

		public Transform PreloadedModuleEffectsRoot
		{
			get
			{
				return preloadedModuleEffectsRoot;
			}
		}

		public PreloadingModuleEffectData[] PreloadingModuleEffects
		{
			get
			{
				return preloadingModuleEffects;
			}
		}

		public Dictionary<string, GameObject> PreloadingBuffer
		{
			get;
			set;
		}

		public List<Entity> EntitiesForEffectsLoading
		{
			get;
			set;
		}
	}
}
