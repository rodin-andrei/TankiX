using Platform.Library.ClientUnityIntegration;
using Platform.Kernel.OSGi.ClientCore.API;

namespace Tanks.Lobby.ClientEntrance.Impl
{
	public class ConnectionReportActivator : UnityAwareActivator<AutoCompleting>
	{
		public float connectionWaitTime;
	}
}
