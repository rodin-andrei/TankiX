using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class RemoveEffectGraphicsComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject effectPrefab;
		[SerializeField]
		private float effectLifeTime;
		[SerializeField]
		private Vector3 origin;
	}
}
