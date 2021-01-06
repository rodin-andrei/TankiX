using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class WeaponStreamTracerEffectComponent : BehaviourComponent
	{
		[SerializeField]
		private float tracerMaxLength;
		[SerializeField]
		private float startTracerOffset;
		[SerializeField]
		private GameObject tracer;
	}
}
