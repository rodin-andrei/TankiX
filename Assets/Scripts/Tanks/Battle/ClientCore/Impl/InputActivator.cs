using Platform.Library.ClientUnityIntegration;
using Platform.Kernel.OSGi.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class InputActivator : UnityAwareActivator<AutoCompleting>
	{
		public GameObject[] inputBinding;
	}
}
