using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ItemAttributesComponent : BehaviourComponent
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
		[SerializeField]
		private bool showNextUpgradeValue;
		public Color nextValueOverUpgradeColor;
		public Color nextValueUpgradeColor;
	}
}
