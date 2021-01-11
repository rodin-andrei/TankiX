using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModuleListItemComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject moduleEffectsInfoPrefab;

		[SerializeField]
		private RectTransform moduleIconRoot;

		[SerializeField]
		private RectTransform moduleNameRoot;

		[SerializeField]
		private TextMeshProUGUI craftableLabelText;

		[SerializeField]
		private RectTransform moduleEffectsInfoRoot;

		[SerializeField]
		private TextMeshProUGUI moduleNameText;

		[SerializeField]
		private PaletteColorField exceptionalColor;

		[SerializeField]
		private PaletteColorField epicColor;

		[SerializeField]
		private Image moduleIcon;

		[SerializeField]
		private TextMeshProUGUI moduleText;

		[SerializeField]
		private Color craftableTextColor;

		[SerializeField]
		private Color notCraftableTextColor;

		[SerializeField]
		private GameObject mountedSelection;

		public GameObject ModuleEffectsInfoPrefab
		{
			get
			{
				return moduleEffectsInfoPrefab;
			}
		}

		public RectTransform ModuleEffectsInfoRoot
		{
			get
			{
				return moduleEffectsInfoRoot;
			}
		}

		public string IconUid
		{
			set
			{
				moduleIconRoot.gameObject.SetActive(true);
				moduleIconRoot.GetComponent<ImageSkin>().SpriteUid = value;
			}
		}

		public string Name
		{
			set
			{
				moduleNameRoot.gameObject.SetActive(true);
				moduleNameText.text = value;
			}
		}

		public string CraftableText
		{
			set
			{
				craftableLabelText.gameObject.SetActive(true);
				craftableLabelText.text = value;
			}
		}

		public Color TextColor
		{
			set
			{
				craftableLabelText.color = value;
			}
		}

		public Color CraftableTextColor
		{
			get
			{
				return craftableTextColor;
			}
		}

		public Color NotCraftableTextColor
		{
			get
			{
				return notCraftableTextColor;
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

		public Image ModuleIcon
		{
			get
			{
				return moduleIcon;
			}
		}

		public Graphic ModuleText
		{
			get
			{
				return moduleText;
			}
		}

		public bool MountedSelectionActivity
		{
			get
			{
				return mountedSelection.activeSelf;
			}
			set
			{
				mountedSelection.SetActive(value);
			}
		}
	}
}
