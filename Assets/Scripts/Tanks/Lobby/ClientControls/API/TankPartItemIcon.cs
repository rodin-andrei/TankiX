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

		public void SetIconWithName(string name)
		{
			foreach (TMP_Sprite spriteInfo in icons.spriteInfoList)
			{
				if (spriteInfo.name.Equals(name))
				{
					image.sprite = spriteInfo.sprite;
				}
			}
		}
	}
}
