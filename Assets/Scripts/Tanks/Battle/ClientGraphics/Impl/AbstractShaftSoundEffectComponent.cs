using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public abstract class AbstractShaftSoundEffectComponent<T> : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component where T : UnityEngine.Component
	{
		[SerializeField]
		private GameObject shaftSoundEffectAsset;

		protected T soundComponent;

		public void Init(Transform soundRoot)
		{
			GameObject original = shaftSoundEffectAsset;
			GameObject gameObject = Object.Instantiate(original);
			Transform transform = gameObject.transform;
			transform.parent = soundRoot;
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			soundComponent = gameObject.GetComponent<T>();
		}

		public abstract void Play();

		public abstract void Stop();
	}
}
