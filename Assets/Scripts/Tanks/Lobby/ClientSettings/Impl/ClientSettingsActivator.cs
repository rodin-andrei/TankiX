using Platform.Library.ClientUnityIntegration;
using Platform.Kernel.OSGi.ClientCore.API;
using UnityEngine;

namespace Tanks.Lobby.ClientSettings.Impl
{
	public class ClientSettingsActivator : UnityAwareActivator<AutoCompleting>
	{
		[SerializeField]
		private string saturationLevelTemplatePath;
		[SerializeField]
		private string antialiasingQualityTemplatePath;
		[SerializeField]
		private string renderResolutionQualityTemplatePath;
		[SerializeField]
		private string shadowQualityTemplatePath;
		[SerializeField]
		private string particleQualityTemplatePath;
		[SerializeField]
		private string textureQualityTemplatePath;
		[SerializeField]
		private string anisotropicQualityTemplatePath;
		[SerializeField]
		private string vegetationSettingsTemplatePath;
		[SerializeField]
		private string grassSettingsTemplatePath;
		[SerializeField]
		private string cartridgeCaseAmountTemplatePath;
		[SerializeField]
		private string vsyncTemplatePath;
	}
}
