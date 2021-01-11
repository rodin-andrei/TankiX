using UnityEngine;

namespace Platform.Library.ClientUnityIntegration.API
{
	public class DelayedSelfDestroyBehaviour : MonoBehaviour
	{
		[SerializeField]
		private float delay;

		private float destroyTime;

		public float Delay
		{
			get
			{
				return delay;
			}
			set
			{
				delay = value;
			}
		}

		private void Start()
		{
			destroyTime = Time.time + delay;
		}

		private void Update()
		{
			if (Time.time > destroyTime)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
