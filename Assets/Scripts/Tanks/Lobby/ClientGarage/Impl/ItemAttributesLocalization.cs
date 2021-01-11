using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ItemAttributesLocalization : LocalizedControl
	{
		[SerializeField]
		private Text upgradeLevelText;

		[SerializeField]
		private Text experienceToLevelUpText;

		public override string YamlKey
		{
			get
			{
				return "upgradeInfoText";
			}
		}

		public override string ConfigPath
		{
			get
			{
				return "ui/screen/garageitempropertyscreen";
			}
		}

		public virtual string UpgradeLevelText
		{
			get
			{
				return upgradeLevelText.text;
			}
			set
			{
				upgradeLevelText.text = value;
			}
		}

		public virtual string ExperienceToLevelUpText
		{
			get
			{
				return experienceToLevelUpText.text;
			}
			set
			{
				experienceToLevelUpText.text = value;
			}
		}
	}
}
