using UnityEngine.EventSystems;
using UnityEngine;

namespace Tanks.Lobby.ClientQuests.Impl
{
	public class QuestWindowComponent : UIBehaviour
	{
		[SerializeField]
		private GameObject questPrefab;
		[SerializeField]
		private GameObject questCellPrefab;
		[SerializeField]
		private GameObject questsContainer;
		[SerializeField]
		private GameObject background;
	}
}
