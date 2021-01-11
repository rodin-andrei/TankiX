using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class CraftModuleConfirmWindowComponent : ConfirmWindowComponent
	{
		[SerializeField]
		protected TextMeshProUGUI additionalText;

		[SerializeField]
		private LocalizedField module;

		[SerializeField]
		private LocalizedField craftFor;

		[SerializeField]
		private LocalizedField decline;

		[SerializeField]
		private LocalizedField upgradeFor;

		[SerializeField]
		private LocalizedField buyBlueprints;

		[SerializeField]
		private Color greenColor;

		[SerializeField]
		private Color whiteColor;

		[SerializeField]
		private Image highlight;

		[SerializeField]
		private Image fill;

		[SerializeField]
		protected ImageSkin icon;

		public string SpriteUid
		{
			set
			{
				icon.SpriteUid = value;
			}
		}

		public GameObject CardPriceLabel
		{
			get;
			set;
		}

		public void Setup(string moduleName, string desc, string spriteUid, double price, bool craft, string currencySpriteId = "8", bool dontenoughtcard = false)
		{
			base.HeaderText = module.Value + " " + moduleName;
			additionalText.gameObject.SetActive(craft && dontenoughtcard);
			if (craft)
			{
				if (dontenoughtcard)
				{
					base.ConfirmText = buyBlueprints.Value;
				}
				else
				{
					base.ConfirmText = craftFor.Value;
				}
			}
			else
			{
				base.ConfirmText = price + "<sprite=" + currencySpriteId + ">";
			}
			base.DeclineText = decline.Value;
			base.MainText = desc;
			SpriteUid = spriteUid;
		}
	}
}
