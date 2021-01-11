using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class RemoveEffectGraphicsComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject effectPrefab;

		[SerializeField]
		private float effectLifeTime = 2f;

		[SerializeField]
		private Vector3 origin = Vector3.up;

		public GameObject EffectPrefab
		{
			get
			{
				return effectPrefab;
			}
			set
			{
				effectPrefab = value;
			}
		}

		public float EffectLifeTime
		{
			get
			{
				return effectLifeTime;
			}
		}

		public Vector3 Origin
		{
			get
			{
				return origin;
			}
		}
	}
}
