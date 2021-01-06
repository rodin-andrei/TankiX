using Platform.Library.ClientUnityIntegration;
using Platform.Kernel.OSGi.ClientCore.API;
using UnityEngine;
using Tanks.Lobby.ClientSettings.API;

namespace Tanks.Lobby.ClientSettings.Impl
{
	public class GraphicsSettingsActivator : UnityAwareActivator<AutoCompleting>
	{
		[SerializeField]
		private float defaultSaturationLevel;
		[SerializeField]
		private int defaultVegetationLevel;
		[SerializeField]
		private int defaultGrassLevel;
		[SerializeField]
		private int defaultAntialiasingQuality;
		[SerializeField]
		private int defaultRenderResolutionQuality;
		[SerializeField]
		private int defaultAnisotropicQuality;
		[SerializeField]
		private int defaultTextureQuality;
		[SerializeField]
		private int defaultShadowQuality;
		[SerializeField]
		private int defaultParticleQuality;
		[SerializeField]
		private int defaultCartridgeCaseAmount;
		[SerializeField]
		private int defaultVsyncQuality;
		[SerializeField]
		private bool isWindowedByDefault;
		[SerializeField]
		private int minHeight;
		[SerializeField]
		private int minWidth;
		[SerializeField]
		private string configPath;
		[SerializeField]
		private GraphicsSettingsAnalyzer graphicsSettingsAnalyzer;
	}
}
