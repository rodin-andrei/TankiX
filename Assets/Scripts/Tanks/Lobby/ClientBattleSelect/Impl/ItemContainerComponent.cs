using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class ItemContainerComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject itemContainer;
		[SerializeField]
		private GameObject itemPrefab;
	}
}
