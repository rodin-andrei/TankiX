using Platform.Library.ClientUnityIntegration;
using Platform.Kernel.OSGi.ClientCore.API;
using UnityEngine;
using Platform.Library.ClientResources.API;

namespace Platform.Library.ClientResources.Impl
{
	public class SceneFromBundleLoaderActivator : UnityAwareActivator<ManuallyCompleting>
	{
		public GameObject progressBar;
		public AssetReference sceneListRef;
	}
}
