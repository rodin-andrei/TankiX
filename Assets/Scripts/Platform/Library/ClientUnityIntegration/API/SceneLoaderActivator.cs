using Platform.Library.ClientUnityIntegration;
using Platform.Kernel.OSGi.ClientCore.API;
using System.Collections.Generic;

namespace Platform.Library.ClientUnityIntegration.API
{
	public class SceneLoaderActivator : UnityAwareActivator<ManuallyCompleting>
	{
		public List<string> environmentSceneNames;
		public float progress;
	}
}
