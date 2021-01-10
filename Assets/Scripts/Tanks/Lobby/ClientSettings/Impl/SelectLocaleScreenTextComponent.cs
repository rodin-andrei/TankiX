using Tanks.Lobby.ClientNavigation.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientSettings.Impl
{
	public class SelectLocaleScreenTextComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private TextMeshProUGUI hint;
		[SerializeField]
		private Text currentLanguage;
	}
}
