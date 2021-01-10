using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class SquadColorsComponent : BehaviourComponent
	{
		[SerializeField]
		private Color selfSquadColor;
		[SerializeField]
		private Color[] friendlyColor;
		[SerializeField]
		private Color[] enemyColor;
	}
}
