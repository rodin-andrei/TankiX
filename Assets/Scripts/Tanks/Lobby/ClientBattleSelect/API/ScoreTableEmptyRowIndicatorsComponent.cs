using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class ScoreTableEmptyRowIndicatorsComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public List<ScoreTableRowIndicator> indicators = new List<ScoreTableRowIndicator>();

		public Color emptyRowColor;

		public Stack<ScoreTableRowComponent> emptyRows = new Stack<ScoreTableRowComponent>();
	}
}
