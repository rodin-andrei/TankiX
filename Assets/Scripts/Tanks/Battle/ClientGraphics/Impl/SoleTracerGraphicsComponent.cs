using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class SoleTracerGraphicsComponent : MonoBehaviour
	{
		[SerializeField]
		private ParticleSystem tracer;
		[SerializeField]
		private float maxTime;
	}
}
