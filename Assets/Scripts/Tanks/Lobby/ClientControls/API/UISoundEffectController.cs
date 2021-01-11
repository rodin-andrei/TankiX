using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public abstract class UISoundEffectController : MonoBehaviour
	{
		private const string UI_SOUND_ROOT_NAME = "UISoundRoot";

		private const string SOUND_NAME_POSTFIX = "Sound";

		private static Transform uiTransformRoot;

		[SerializeField]
		private AudioClip clip;

		[SerializeField]
		private AudioSource sourceAsset;

		private AudioSource sourceInstance;

		protected bool alive;

		public static Transform UITransformRoot
		{
			get
			{
				if (uiTransformRoot == null)
				{
					uiTransformRoot = new GameObject("UISoundRoot").transform;
					Object.DontDestroyOnLoad(uiTransformRoot.gameObject);
					uiTransformRoot.position = Vector3.zero;
					uiTransformRoot.rotation = Quaternion.identity;
				}
				return uiTransformRoot;
			}
		}

		public abstract string HandlerName
		{
			get;
		}

		private void Awake()
		{
			alive = true;
			PrepareAudioSourceInstance();
		}

		private void OnApplicationQuit()
		{
			alive = false;
		}

		private void PrepareAudioSourceInstance()
		{
			if (!(sourceInstance != null))
			{
				sourceInstance = Object.Instantiate(sourceAsset);
				GameObject gameObject = sourceInstance.gameObject;
				Transform transform = sourceInstance.transform;
				transform.parent = UITransformRoot;
				transform.localPosition = Vector3.zero;
				transform.localRotation = Quaternion.identity;
				gameObject.name = string.Format("{0}_{1}_{2}", base.gameObject.name, HandlerName, "Sound");
				sourceInstance.clip = clip;
			}
		}

		private void OnDestroy()
		{
			if (alive && (bool)sourceInstance)
			{
				Object.Destroy(sourceInstance.gameObject);
			}
		}

		public void PlaySoundEffect()
		{
			PrepareAudioSourceInstance();
			sourceInstance.Stop();
			sourceInstance.Play();
		}
	}
}
