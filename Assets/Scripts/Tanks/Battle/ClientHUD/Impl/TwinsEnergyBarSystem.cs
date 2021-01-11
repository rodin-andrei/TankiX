using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class TwinsEnergyBarSystem : ECSSystem
	{
		public class TwinsWeaponNode : Node
		{
			public TwinsComponent twins;
		}

		[OnEventComplete]
		public void Init(NodeAddedEvent e, TwinsWeaponNode weapon, [JoinByTank][Context] HUDNodes.SelfTankNode tank, SingleNode<MainHUDComponent> hud)
		{
			hud.component.EnergyBarEnabled = false;
		}
	}
}
