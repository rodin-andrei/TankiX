using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class WeaponStreamTracerEffectComponent : BehaviourComponent
	{
		[SerializeField]
		private float tracerMaxLength = 222.22f;

		[SerializeField]
		private float startTracerOffset = 0.5f;

		[SerializeField]
		private GameObject tracer;

		public float StartTracerOffset
		{
			get
			{
				return startTracerOffset;
			}
			set
			{
				startTracerOffset = value;
			}
		}

		public float TracerMaxLength
		{
			get
			{
				return tracerMaxLength;
			}
			set
			{
				tracerMaxLength = value;
			}
		}

		public GameObject Tracer
		{
			get
			{
				return tracer;
			}
			set
			{
				tracer = value;
			}
		}
	}
}
