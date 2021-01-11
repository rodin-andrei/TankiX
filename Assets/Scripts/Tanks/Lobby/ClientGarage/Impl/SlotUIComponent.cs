using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.API;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class SlotUIComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component, AttachToEntityListener, IPointerClickHandler, IEventSystemHandler
	{
		[SerializeField]
		private ImageSkin moduleIconImageSkin;

		[SerializeField]
		private PaletteColorField exceptionalColor;

		[SerializeField]
		private PaletteColorField epicColor;

		[SerializeField]
		private Image moduleIcon;

		[SerializeField]
		private Image selectionImage;

		[SerializeField]
		private Image lockIcon;

		[SerializeField]
		private Image upgradeIcon;

		[SerializeField]
		private TextMeshProUGUI slotName;

		[SerializeField]
		private LocalizedField slotNameLocalization;

		private TankPartModuleType tankPart;

		private bool locked;

		private int rank;

		private Entity slotEntity;

		public Slot Slot
		{
			set
			{
				slotName.text = slotNameLocalization.Value + " " + (int)(value + 1);
			}
		}

		public TankPartModuleType TankPart
		{
			get
			{
				return tankPart;
			}
			set
			{
				tankPart = value;
			}
		}

		public ImageSkin ModuleIconImageSkin
		{
			get
			{
				return moduleIconImageSkin;
			}
		}

		public Image ModuleIcon
		{
			get
			{
				return moduleIcon;
			}
			set
			{
				moduleIcon = value;
			}
		}

		public Image SelectionImage
		{
			get
			{
				return selectionImage;
			}
			set
			{
				selectionImage = value;
			}
		}

		public Image UpgradeIcon
		{
			get
			{
				return upgradeIcon;
			}
			set
			{
				upgradeIcon = value;
			}
		}

		public Color ExceptionalColor
		{
			get
			{
				return exceptionalColor;
			}
		}

		public Color EpicColor
		{
			get
			{
				return epicColor;
			}
		}

		public bool Locked
		{
			get
			{
				return locked;
			}
			set
			{
				lockIcon.gameObject.SetActive(value);
				locked = value;
				GetComponent<CanvasGroup>().alpha = ((!locked) ? 1f : 0.6f);
				Toggle component = GetComponent<Toggle>();
				if (component != null)
				{
					component.interactable = !locked;
				}
			}
		}

		public int Rank
		{
			get
			{
				return rank;
			}
			set
			{
				rank = value;
			}
		}

		public Entity SlotEntity
		{
			get
			{
				return slotEntity;
			}
		}

		public void AttachedToEntity(Entity entity)
		{
			slotEntity = entity;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (slotEntity != null && ClientUnityIntegrationUtils.HasEngine() && slotEntity.HasComponent<ModuleCardItemUIComponent>())
			{
				slotEntity.RemoveComponent<ModuleCardItemUIComponent>();
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (locked)
			{
				GetComponent<SlotTooltipShowComponent>().ShowTooltip(Input.mousePosition);
			}
		}
	}
}
