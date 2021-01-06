using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class EnergyBar : HUDBar
	{
		[SerializeField]
		private Ruler stroke;
		[SerializeField]
		private Ruler fill;
		[SerializeField]
		private Ruler glow;
		[SerializeField]
		private Ruler energyInjectionGlow;
		[SerializeField]
		private TankPartItemIcon turretIcon;
	}
}
