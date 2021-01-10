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
	}
}
