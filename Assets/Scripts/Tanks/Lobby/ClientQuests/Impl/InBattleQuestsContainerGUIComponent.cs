using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientQuests.Impl
{
	public class InBattleQuestsContainerGUIComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject questPrefab;
		[SerializeField]
		private GameObject questsContainer;
	}
}
