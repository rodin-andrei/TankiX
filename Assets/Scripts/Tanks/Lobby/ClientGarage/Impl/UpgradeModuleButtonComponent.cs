using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class UpgradeModuleButtonComponent : UpgradeModuleBaseButtonComponent
	{
		[SerializeField]
		private LocalizedField notEnoughBlueprints;
		[SerializeField]
		private GameObject content;
	}
}
