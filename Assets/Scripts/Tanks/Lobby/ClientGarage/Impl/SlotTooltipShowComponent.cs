using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class SlotTooltipShowComponent : TooltipShowBehaviour
	{
		[SerializeField]
		private GameObject slotLockedTooltip;

		[SerializeField]
		private GameObject moduleTooltip;

		[SerializeField]
		private LocalizedField slotLockedTitle;

		[SerializeField]
		private LocalizedField weaponSlotLocked;

		[SerializeField]
		private LocalizedField hullSlotLocked;

		[SerializeField]
		private LocalizedField emptySlot;

		[SerializeField]
		private PaletteColorField lockedHeaderColor;

		private SlotUIComponent slot
		{
			get
			{
				return GetComponent<SlotUIComponent>();
			}
		}

		public override void ShowTooltip(Vector3 mousePosition)
		{
			Engine engine = TooltipShowBehaviour.EngineService.Engine;
			CheckForTutorialEvent checkForTutorialEvent = new CheckForTutorialEvent();
			engine.ScheduleEvent(checkForTutorialEvent, TooltipShowBehaviour.EngineService.EntityStub);
			if (!checkForTutorialEvent.TutorialIsActive)
			{
				tooltipShowed = true;
				if (slot.Locked)
				{
					ShowLockedModuleTooltip();
				}
				else if (slot.SlotEntity != null)
				{
					engine.ScheduleEvent<ModuleTooltipShowEvent>(slot.SlotEntity);
				}
			}
		}

		private void ShowLockedModuleTooltip()
		{
			string text = "<color=#" + lockedHeaderColor.Color.ToHexString() + ">" + slotLockedTitle.Value + "</color>";
			string text2 = ((slot.TankPart != 0) ? weaponSlotLocked.Value : hullSlotLocked.Value);
			string text3 = text2.Replace("{0}", slot.Rank.ToString());
			string[] data = new string[2]
			{
				text,
				text3
			};
			TooltipController.Instance.ShowTooltip(Input.mousePosition, data, slotLockedTooltip);
		}

		public void ShowModuleTooltip(object data)
		{
			TooltipController.Instance.ShowTooltip(Input.mousePosition, data, moduleTooltip);
		}

		public void ShowEmptySlotTooltip()
		{
			TooltipController.Instance.ShowTooltip(Input.mousePosition, emptySlot.Value);
		}
	}
}
