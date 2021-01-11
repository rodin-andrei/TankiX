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

		private int value;

		public string Icon
		{
			get
			{
				return image.SpriteUid;
			}
			set
			{
				image.SpriteUid = value;
			}
		}

		public int Value
		{
			get
			{
				return value;
			}
			set
			{
				this.value = value;
				valueText.text = string.Format(BonusText, value);
			}
		}

		public string BonusText
		{
			get;
			set;
		}

		public string DamageText
		{
			get;
			set;
		}

		public string ArmorText
		{
			get;
			set;
		}
	}
}
