using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientGarage.API;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class SlotsPanelComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject slotPrefab;

		[SerializeField]
		private string[] slotSpriteUids;

		[SerializeField]
		private GameObject[] slots;

		public string GetIconByType(ModuleBehaviourType moduleBehaviourType)
		{
			return slotSpriteUids[(uint)moduleBehaviourType];
		}

		public GameObject SetSlot(Slot slot)
		{
			return slots[(uint)slot];
		}
	}
}
