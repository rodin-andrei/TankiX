using System;
using UnityEngine;

namespace Platform.Library.ClientUnityIntegration.Impl
{
	[Serializable]
	public class SceneDesc
	{
		public bool initAfterLoading = true;

		public string sceneName;

		public UnityEngine.Object scene;

		[NonSerialized]
		public UnityEngine.Object sceneAsset;
	}
}
