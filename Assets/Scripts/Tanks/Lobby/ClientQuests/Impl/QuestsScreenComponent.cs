using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientQuests.Impl
{
	public class QuestsScreenComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject questPrefab;
		[SerializeField]
		private GameObject questCellPrefab;
		[SerializeField]
		private GameObject questsContainer;
	}
}
