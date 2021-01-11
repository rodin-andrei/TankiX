using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class QuestsResultUI : MonoBehaviour
	{
		[SerializeField]
		private GameObject resultsContainer;

		[SerializeField]
		private GameObject questResultPrefab;

		public void AddQuest(Entity quest)
		{
			GameObject gameObject = Object.Instantiate(questResultPrefab);
			gameObject.transform.SetParent(resultsContainer.transform, false);
		}
	}
}
