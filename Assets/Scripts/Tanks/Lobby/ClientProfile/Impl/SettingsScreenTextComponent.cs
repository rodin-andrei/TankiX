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
	}
}
