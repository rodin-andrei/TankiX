using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class MountModuleButtonComponent : BehaviourComponent
	{
		[SerializeField]
		private LocalizedField mountButtonLocalizedField;
		[SerializeField]
		private LocalizedField unmountButtonLocalizedField;
		public bool mount;
	}
}
