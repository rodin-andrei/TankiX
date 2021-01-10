using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class SquadInfoUIComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject addButton;
		[SerializeField]
		private GameObject teammate;
		[SerializeField]
		private RectTransform teammatesList;
	}
}
