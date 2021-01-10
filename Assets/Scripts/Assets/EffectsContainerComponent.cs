using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Assets
{
	public class EffectsContainerComponent : BehaviourComponent
	{
		[SerializeField]
		private RectTransform buffContainer;
		[SerializeField]
		private RectTransform debuffContainer;
		[SerializeField]
		private EntityBehaviour effectPrefab;
	}
}
