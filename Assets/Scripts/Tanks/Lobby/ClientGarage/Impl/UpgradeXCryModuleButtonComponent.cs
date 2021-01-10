using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class UpgradeXCryModuleButtonComponent : UpgradeModuleBaseButtonComponent
	{
		[SerializeField]
		private LocalizedField buyBlueprints;
		[SerializeField]
		private GameObject content;
	}
}
