using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class ShaftAimingColorEffectSystem : ECSSystem
	{
		public class ShaftAimingColorEffectNode : Node
		{
			public ShaftAimingColorEffectComponent shaftAimingColorEffect;

			public BattleGroupComponent battleGroup;
		}

		public class ShaftAimingTeamColorEffectNode : Node
		{
			public ShaftAimingColorEffectComponent shaftAimingColorEffect;

			public BattleGroupComponent battleGroup;

			public TeamGroupComponent teamGroup;
		}

		public class DMBattleNode : Node
		{
			public BattleGroupComponent battleGroup;

			public DMComponent dm;
		}

		public class TeamNode : Node
		{
			public ColorInBattleComponent colorInBattle;

			public TeamGroupComponent teamGroup;
		}

		[OnEventFire]
		public void DefineColorForDM(NodeAddedEvent evt, ShaftAimingColorEffectNode weaponNode, [Context][JoinByBattle] DMBattleNode dm)
		{
			weaponNode.shaftAimingColorEffect.ChoosenColor = weaponNode.shaftAimingColorEffect.RedColor;
			weaponNode.Entity.AddComponent<ShaftAimingColorEffectPreparedComponent>();
		}

		[OnEventFire]
		public void DefineColorForTeamMode(NodeAddedEvent evt, [Combine] ShaftAimingTeamColorEffectNode weaponNode, [Context][JoinByTeam] TeamNode team)
		{
			TeamColor teamColor = team.colorInBattle.TeamColor;
			ShaftAimingColorEffectComponent shaftAimingColorEffect = weaponNode.shaftAimingColorEffect;
			Color color2 = (shaftAimingColorEffect.ChoosenColor = ((teamColor != TeamColor.BLUE) ? shaftAimingColorEffect.RedColor : shaftAimingColorEffect.BlueColor));
			weaponNode.Entity.AddComponent<ShaftAimingColorEffectPreparedComponent>();
		}
	}
}
