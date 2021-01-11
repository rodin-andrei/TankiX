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

		public string SFXVolume
		{
			set
			{
				sFXVolume.text = value;
			}
		}

		public string MusicVolume
		{
			set
			{
				musicVolume.text = value;
			}
		}

		public string UIVolume
		{
			set
			{
				uIVolume.text = value;
			}
		}
	}
}
