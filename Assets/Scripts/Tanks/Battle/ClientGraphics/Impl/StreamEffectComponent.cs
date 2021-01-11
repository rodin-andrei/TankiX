using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientGraphics.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class StreamEffectComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject effectPrefab;

		public StreamEffectBehaviour Instance
		{
			get;
			private set;
		}

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

		public void Init(MuzzlePointComponent muzzlePoint)
		{
			GameObject gameObject = Object.Instantiate(effectPrefab);
			UnityUtil.InheritAndEmplace(gameObject.transform, muzzlePoint.Current);
			Instance = gameObject.GetComponent<StreamEffectBehaviour>();
			CustomRenderQueue.SetQueue(gameObject, 3150);
		}
	}
}
