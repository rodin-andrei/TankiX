using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModuleInfoPanelComponent : LocalizedControl, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Text slotText;

		[SerializeField]
		private Text moduleNameText;

		[SerializeField]
		private Text mountLabelText;

		[SerializeField]
		private RectTransform slotInfoPanel;

		[SerializeField]
		private ImageSkin slotInfoSlotIcon;

		[SerializeField]
		private ImageSkin slotInfoModuleIcon;

		[SerializeField]
		private ImageSkin slotInfoLockIcon;

		[SerializeField]
		private Text moduleDescriptionText;

		[SerializeField]
		private CardPriceLabelComponent priceLabel;

		[SerializeField]
		private Text moduleExceptionalText;

		[SerializeField]
		private Text moduleEpicText;

		[SerializeField]
		private GameObject defenceIcon;

		[SerializeField]
		private GameObject scoutingIcon;

		[SerializeField]
		private GameObject specialIcon;

		[SerializeField]
		private GameObject supportIcon;

		[Header("Localization")]
		[SerializeField]
		private Text specialText;

		[SerializeField]
		private Text scoutingText;

		[SerializeField]
		private Text defenceText;

		[SerializeField]
		private Text supportText;

		public string SlotText
		{
			set
			{
				slotText.text = value;
			}
		}

		public string ModuleNameText
		{
			set
			{
				moduleNameText.text = value;
			}
		}

		public string MountLabelText
		{
			set
			{
				mountLabelText.text = value;
			}
		}

		public RectTransform SlotInfoPanel
		{
			get
			{
				return slotInfoPanel;
			}
		}

		public ImageSkin SlotInfoSlotIcon
		{
			get
			{
				return slotInfoSlotIcon;
			}
		}

		public ImageSkin SlotInfoModuleIcon
		{
			get
			{
				return slotInfoModuleIcon;
			}
		}

		public ImageSkin SlotInfoLockIcon
		{
			get
			{
				return slotInfoLockIcon;
			}
		}

		public string ModuleDescriptionText
		{
			set
			{
				moduleDescriptionText.text = value;
			}
		}

		public CardPriceLabelComponent PriceLabel
		{
			get
			{
				return priceLabel;
			}
		}

		public Text ModuleExceptionalText
		{
			get
			{
				return moduleExceptionalText;
			}
		}

		public Text ModuleEpicText
		{
			get
			{
				return moduleEpicText;
			}
		}

		public GameObject DefenceIcon
		{
			get
			{
				return defenceIcon;
			}
		}

		public GameObject ScoutingIcon
		{
			get
			{
				return scoutingIcon;
			}
		}

		public GameObject SpecialIcon
		{
			get
			{
				return specialIcon;
			}
		}

		public GameObject SupportIcon
		{
			get
			{
				return supportIcon;
			}
		}

		public string SpecialText
		{
			get
			{
				return specialText.text;
			}
			set
			{
				specialText.text = value;
			}
		}

		public string ScoutingText
		{
			get
			{
				return scoutingText.text;
			}
			set
			{
				scoutingText.text = value;
			}
		}

		public string DefenceText
		{
			get
			{
				return defenceText.text;
			}
			set
			{
				defenceText.text = value;
			}
		}

		public string SupportText
		{
			get
			{
				return supportText.text;
			}
			set
			{
				supportText.text = value;
			}
		}

		public void ScrollUpDescription()
		{
			((RectTransform)moduleDescriptionText.transform).anchoredPosition = default(Vector2);
		}
	}
}
