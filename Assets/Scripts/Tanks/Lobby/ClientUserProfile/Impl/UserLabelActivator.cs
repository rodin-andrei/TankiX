using Platform.Library.ClientUnityIntegration;
using Platform.Kernel.OSGi.ClientCore.API;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class UserLabelActivator : UnityAwareActivator<AutoCompleting>
	{
		[SerializeField]
		public GameObject UserLabel;
	}
}
