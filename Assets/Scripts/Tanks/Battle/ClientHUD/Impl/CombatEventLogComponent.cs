using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class CombatEventLogComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Color NeutralColor;

		public Color AllyColor;

		public Color EnemyColor;

		public Color RedTeamColor;

		public Color BlueTeamColor;
	}
}
