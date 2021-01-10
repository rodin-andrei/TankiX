using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class StaticBonusUI : LocalizedControl
	{
		[SerializeField]
		private ImageSkin image;
		[SerializeField]
		private Text valueText;
		[SerializeField]
		private Text sufixText;
	}
}
