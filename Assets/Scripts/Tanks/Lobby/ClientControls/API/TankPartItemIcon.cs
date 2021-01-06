using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	public class TankPartItemIcon : BaseCombatLogMessageElement
	{
		[SerializeField]
		private TMP_SpriteAsset icons;
		[SerializeField]
		private Image image;
	}
}
