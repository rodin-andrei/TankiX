using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientCore.API;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class UITeamComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private TeamColor teamColor;

		public TeamColor TeamColor
		{
			get
			{
				return teamColor;
			}
			set
			{
				teamColor = value;
			}
		}
	}
}
