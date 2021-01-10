using System;
using UnityEngine;

namespace Platform.Library.ClientUnityIntegration.Impl
{
	[Serializable]
	public class SceneDesc
	{
		public bool initAfterLoading;
		public string sceneName;
		public Object scene;
	}
}
