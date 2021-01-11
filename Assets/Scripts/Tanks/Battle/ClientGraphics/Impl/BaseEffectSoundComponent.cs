using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public abstract class BaseEffectSoundComponent<T> : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component where T : UnityEngine.Component
	{
		[SerializeField]
		private GameObject startSoundAsset;

		[SerializeField]
		private GameObject stopSoundAsset;

		public GameObject StartSoundAsset
		{
			get
			{
				return startSoundAsset;
			}
			set
			{
				startSoundAsset = value;
			}
		}

		public GameObject StopSoundAsset
		{
			get
			{
				return stopSoundAsset;
			}
			set
			{
				stopSoundAsset = value;
			}
		}

		public T StartSound
		{
			get;
			set;
		}

		public T StopSound
		{
			get;
			set;
		}

		public abstract void BeginEffect();

		public abstract void StopEffect();

		public void Init(Transform root)
		{
			StartSound = Init(StartSoundAsset, root);
			StopSound = Init(StopSoundAsset, root);
		}

		private T Init(GameObject go, Transform root)
		{
			GameObject gameObject = Object.Instantiate(go);
			gameObject.transform.parent = root;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			return gameObject.GetComponent<T>();
		}
	}
}
