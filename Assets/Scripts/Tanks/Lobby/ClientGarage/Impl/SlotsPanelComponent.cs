using UnityEngine.EventSystems;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class SlotsPanelComponent : UIBehaviour
	{
		[SerializeField]
		private GameObject slotPrefab;
		[SerializeField]
		private string[] slotSpriteUids;
		[SerializeField]
		private GameObject[] slots;
	}
}
