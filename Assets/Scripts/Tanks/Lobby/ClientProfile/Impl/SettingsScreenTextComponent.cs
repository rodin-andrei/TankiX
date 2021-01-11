using Tanks.Lobby.ClientNavigation.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientProfile.Impl
{
	public class SettingsScreenTextComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private TextMeshProUGUI header;

		[SerializeField]
		private TextMeshProUGUI gameSettings;

		[SerializeField]
		private TextMeshProUGUI soundSettings;

		[SerializeField]
		private TextMeshProUGUI languageSettings;

		[SerializeField]
		private TextMeshProUGUI graphicsSettings;

		[SerializeField]
		private TextMeshProUGUI keyboardSettings;

		public new virtual string Header
		{
			set
			{
				header.text = value;
			}
		}

		public virtual string GameSettings
		{
			set
			{
				gameSettings.text = value;
			}
		}

		public virtual string SoundSettings
		{
			set
			{
				soundSettings.text = value;
			}
		}

		public virtual string LanguageSettings
		{
			set
			{
				languageSettings.text = value;
			}
		}

		public virtual string GraphicsSettings
		{
			set
			{
				graphicsSettings.text = value;
			}
		}

		public virtual string KeyboardSettings
		{
			set
			{
				keyboardSettings.text = value;
			}
		}
	}
}
