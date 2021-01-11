using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModuleCardItemUIComponent : BehaviourComponent, AttachToEntityListener
	{
		public ModuleBehaviourType Type;

		public TankPartModuleType TankPart;

		[SerializeField]
		private ImageSkin icon;

		[SerializeField]
		private TextMeshProUGUI levelLabel;

		[SerializeField]
		private TextMeshProUGUI moduleName;

		[SerializeField]
		private GameObject selectBorder;

		[SerializeField]
		private Slider upgradeSlider;

		[SerializeField]
		private TextMeshProUGUI upgradeLabel;

		[SerializeField]
		private GameObject activeBorder;

		[SerializeField]
		private GameObject passiveBorder;

		[SerializeField]
		private LocalizedField activateAvailableLocalizedField;

		[SerializeField]
		private LocalizedField upgradeAvailableLocalizedField;

		[SerializeField]
		private TextMeshProUGUI upgradeAvailableText;

		[SerializeField]
		private float notMountableAlpha = 0.3f;

		private Entity moduleEntity;

		private bool upgradeAvailable;

		private int level = -1;

		private int maxCardsCount;

		private int cardsCount;

		public bool mountable;

		public Entity ModuleEntity
		{
			get
			{
				return moduleEntity;
			}
		}

		public long MarketGroupId
		{
			get
			{
				if (moduleEntity != null && moduleEntity.HasComponent<MarketItemGroupComponent>())
				{
					return moduleEntity.GetComponent<MarketItemGroupComponent>().Key;
				}
				return 0L;
			}
		}

		public string ModuleName
		{
			set
			{
				moduleName.text = value;
			}
		}

		public bool Active
		{
			set
			{
				activeBorder.SetActive(value);
				passiveBorder.SetActive(!value);
			}
		}

		public bool UpgradeAvailable
		{
			get
			{
				return upgradeAvailable;
			}
			set
			{
				upgradeAvailable = value;
				SetUpgradeAvailableText(value, upgradeAvailableLocalizedField.Value);
			}
		}

		public bool ActivateAvailable
		{
			get
			{
				return upgradeAvailable;
			}
			set
			{
				upgradeAvailable = value;
				SetUpgradeAvailableText(value, activateAvailableLocalizedField.Value);
			}
		}

		public int Level
		{
			get
			{
				return level;
			}
			set
			{
				level = value;
				if (level == -1)
				{
					levelLabel.text = "0";
				}
				else
				{
					levelLabel.text = level.ToString();
				}
				Mountable = level > 0 || UpgradeAvailable;
			}
		}

		public string Icon
		{
			set
			{
				icon.SpriteUid = value;
			}
		}

		public bool Selected
		{
			set
			{
				selectBorder.SetActive(value);
			}
		}

		public int MaxCardsCount
		{
			get
			{
				return maxCardsCount;
			}
			set
			{
				maxCardsCount = value;
				upgradeSlider.maxValue = maxCardsCount;
				CardsCount = cardsCount;
				upgradeSlider.transform.parent.gameObject.SetActive(maxCardsCount > 0);
			}
		}

		public int CardsCount
		{
			get
			{
				return cardsCount;
			}
			set
			{
				cardsCount = value;
				upgradeLabel.text = ((MaxCardsCount <= 0) ? "MAX" : (cardsCount + "/" + MaxCardsCount));
				upgradeSlider.value = cardsCount;
				if (level > 0)
				{
					UpgradeAvailable = cardsCount >= maxCardsCount && maxCardsCount > 0;
				}
				else
				{
					ActivateAvailable = cardsCount >= maxCardsCount && maxCardsCount > 0;
				}
			}
		}

		public bool Mountable
		{
			get
			{
				return mountable;
			}
			set
			{
				mountable = value;
				GetComponent<CanvasGroup>().alpha = ((!value) ? notMountableAlpha : 1f);
				CanvasGroup component = selectBorder.GetComponent<CanvasGroup>();
				bool ignoreParentGroups = !value;
				upgradeAvailableText.GetComponent<CanvasGroup>().ignoreParentGroups = ignoreParentGroups;
				component.ignoreParentGroups = ignoreParentGroups;
			}
		}

		public void SetCardsCount(int value, bool activate)
		{
		}

		private void SetUpgradeAvailableText(bool available, string text)
		{
			upgradeAvailableText.gameObject.SetActive(available);
			upgradeAvailableText.text = text;
			if (available && !Mountable)
			{
				Mountable = true;
			}
		}

		public void Select()
		{
			Selected = true;
		}

		public void AttachedToEntity(Entity entity)
		{
			moduleEntity = entity;
		}

		private void OnDestroy()
		{
			if (moduleEntity != null && ClientUnityIntegrationUtils.HasEngine())
			{
				moduleEntity.RemoveComponent<ModuleCardItemUIComponent>();
			}
		}
	}
}
