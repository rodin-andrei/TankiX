using Platform.Library.ClientUnityIntegration;
using Platform.Kernel.OSGi.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ClientSoundActivator : UnityAwareActivator<AutoCompleting>
	{
		[SerializeField]
		private int minProcessorCount;
		[SerializeField]
		private int maxRealVoicesCountForWeakCPU;
		[SerializeField]
		private int[] maxRealVoicesByQualityIndex;
	}
}
