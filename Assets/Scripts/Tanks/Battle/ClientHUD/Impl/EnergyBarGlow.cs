using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class EnergyBarGlow : HUDBar
	{
		[SerializeField]
		private Ruler fill;
		[SerializeField]
		private Ruler glow;
		[SerializeField]
		private Ruler energyInjectionGlow;
		[SerializeField]
		private BarFillEnd barFillEnd;
	}
}
