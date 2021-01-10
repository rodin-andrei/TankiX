using Platform.Library.ClientUnityIntegration;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientResources.API;
using Platform.Library.ClientUnityIntegration.API;

namespace Tanks.Lobby.ClientSettings.API
{
	public class SoundLoaderStartActivator : UnityAwareActivator<AutoCompleting>
	{
		public AssetReference audioResourcesRef;
		public EntityBehaviour entity;
	}
}
