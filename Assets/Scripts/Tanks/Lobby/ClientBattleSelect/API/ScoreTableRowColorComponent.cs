using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class ScoreTableRowColorComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Color rowColor;

		public Color selfRowColor;

		public Color friendRowColor;
	}
}
