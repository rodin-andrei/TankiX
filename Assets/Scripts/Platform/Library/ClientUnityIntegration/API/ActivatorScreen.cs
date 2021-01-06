using Platform.Library.ClientUnityIntegration;
using Platform.Kernel.OSGi.ClientCore.API;
using UnityEngine;
using UnityEngine.UI;

namespace Platform.Library.ClientUnityIntegration.API
{
	public class ActivatorScreen : UnityAwareActivator<AutoCompleting>
	{
		[SerializeField]
		private CanvasGroup backgroundGroup;
		[SerializeField]
		private Text entranceMessage;
		[SerializeField]
		private float fadeOutTimeSec;
	}
}
