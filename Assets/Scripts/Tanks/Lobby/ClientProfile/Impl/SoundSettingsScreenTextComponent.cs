using Tanks.Lobby.ClientNavigation.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientProfile.Impl
{
	public class SoundSettingsScreenTextComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private TextMeshProUGUI sFXVolume;
		[SerializeField]
		private TextMeshProUGUI musicVolume;
		[SerializeField]
		private TextMeshProUGUI uIVolume;
	}
}
