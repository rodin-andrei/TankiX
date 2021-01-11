using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ItemAttributesComponent : BehaviourComponent, AttachToEntityListener
	{
		[SerializeField]
		private GameObject proficiency;

		[SerializeField]
		private GameObject experience;

		[SerializeField]
		private GameObject upgrade;

		[SerializeField]
		private Text upgradeLevelValue;

		[SerializeField]
		private Text nextUpgradeLevelValue;

		[SerializeField]
		private ProgressBar upgradeLevelProgress;

		[SerializeField]
		private Text proficiencyLevelValue;

		[SerializeField]
		private ProgressBar proficiencyLevelProgress;

		[SerializeField]
		private Text experienceValue;

		[SerializeField]
		private Text maxExperienceValue;

		[SerializeField]
		private ProgressBar remainingExperienceProgress;

		[SerializeField]
		private GameObject nextUpgrade;

		[SerializeField]
		private Image upgradeGlow;

		[SerializeField]
		private Image colorIcon;

		private Color upgradeColor;

		[SerializeField]
		private bool showNextUpgradeValue;

		private bool runtimeShowNextUpgradeValue;

		private long upgradeLevel;

		public Color nextValueOverUpgradeColor;

		public Color nextValueUpgradeColor;

		public bool ShowNextUpgradeValue
		{
			get
			{
				return showNextUpgradeValue && runtimeShowNextUpgradeValue;
			}
			set
			{
				runtimeShowNextUpgradeValue = value;
				nextUpgrade.SetActive(showNextUpgradeValue && runtimeShowNextUpgradeValue);
			}
		}

		private void Awake()
		{
			nextUpgrade.SetActive(showNextUpgradeValue);
			RectTransform component = upgradeGlow.GetComponent<RectTransform>();
			Vector2 sizeDelta = component.sizeDelta;
			sizeDelta.x *= 100f / (float)UpgradablePropertiesUtils.MAX_LEVEL;
			component.sizeDelta = sizeDelta;
		}

		public void AnimateUpgrade(long level)
		{
			GetComponent<Animator>().SetTrigger("Upgrade");
			upgradeLevel = level;
			UpdateUpgradeColor();
			RectTransform component = upgradeGlow.GetComponent<RectTransform>();
			component.anchorMax = new Vector2(upgradeLevelProgress.ProgressValue, component.anchorMax.y);
			component.anchorMin = new Vector2(upgradeLevelProgress.ProgressValue, component.anchorMin.y);
		}

		public void SetUpgradeLevel(long level)
		{
			upgradeLevel = level;
			UpdateUpgradeColor();
			ApplyValues();
			ApplyUpdateColor();
		}

		private void ApplyValues()
		{
			upgradeLevelValue.text = upgradeLevel.ToString();
			ShowNextUpgradeValue = ShowNextUpgradeValue && upgradeLevel < UpgradablePropertiesUtils.MAX_LEVEL;
			nextUpgradeLevelValue.text = (upgradeLevel + 1).ToString();
			upgradeLevelProgress.ProgressValue = (float)upgradeLevel / (float)UpgradablePropertiesUtils.MAX_LEVEL;
			nextUpgradeLevelValue.color = upgradeColor;
		}

		private void OnFinishAnimation()
		{
			ApplyUpdateColor();
		}

		public void SetProficiencyLevel(int level)
		{
			proficiencyLevelValue.text = level.ToString();
			proficiencyLevelProgress.ProgressValue = (float)level / (float)UpgradablePropertiesUtils.MAX_LEVEL;
			UpdateUpgradeColor();
			ApplyUpdateColor();
		}

		public void SetExperience(int exp, int initLevelExp, int finalLevelExp)
		{
			experienceValue.text = (finalLevelExp - exp - initLevelExp).ToString();
			maxExperienceValue.text = (finalLevelExp - initLevelExp).ToString();
			remainingExperienceProgress.ProgressValue = (float)(finalLevelExp - exp - initLevelExp) / (float)(finalLevelExp - initLevelExp);
		}

		public void Hide()
		{
			ChangeChildrenVisibility(false);
		}

		public void HideExperience()
		{
			experience.SetActive(false);
		}

		public void Show()
		{
			ChangeChildrenVisibility(true);
		}

		private void ChangeChildrenVisibility(bool visible)
		{
			proficiency.SetActive(visible);
			experience.SetActive(visible && remainingExperienceProgress.ProgressValue < 1f && proficiencyLevelProgress.ProgressValue < 1f);
			upgrade.SetActive(visible);
		}

		private void UpdateUpgradeColor()
		{
			if (showNextUpgradeValue && upgradeLevel >= 0 && !string.IsNullOrEmpty(proficiencyLevelValue.text))
			{
				upgradeColor = nextValueUpgradeColor;
			}
		}

		private void ApplyUpdateColor()
		{
			nextUpgradeLevelValue.color = upgradeColor;
			upgradeGlow.color = upgradeColor;
			colorIcon.color = upgradeColor;
		}

		public void AttachedToEntity(Entity entity)
		{
			runtimeShowNextUpgradeValue = true;
			upgradeLevelValue.text = string.Empty;
			proficiencyLevelValue.text = string.Empty;
			upgradeLevel = 0L;
			remainingExperienceProgress.ProgressValue = 1f;
		}
	}
}
