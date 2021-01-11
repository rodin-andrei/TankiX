using System;
using System.Collections.Generic;
using Lobby.ClientPayment.Impl;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Kernel.OSGi.ClientCore.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientPayment.Impl;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class XCrystalPackage : MonoBehaviour
	{
		[SerializeField]
		private ImageSkin[] preview;

		[SerializeField]
		private TextMeshProUGUI amount;

		[SerializeField]
		private TextMeshProUGUI price;

		[SerializeField]
		private TextMeshProUGUI totalAmount;

		[SerializeField]
		private LocalizedField forFree;

		[SerializeField]
		private PaletteColorField greyColor;

		[SerializeField]
		private GameObject giftLabel;

		[SerializeField]
		private ImageSkin giftPreview;

		[SerializeField]
		private int xCrySpriteIndex = 9;

		[SerializeField]
		private LocalizedField _commonString;

		[SerializeField]
		private LocalizedField _rareString;

		[SerializeField]
		private LocalizedField _epicString;

		[SerializeField]
		private LocalizedField _legendaryString;

		[Inject]
		public static EngineServiceInternal EngineService
		{
			get;
			set;
		}

		public Entity Entity
		{
			get;
			private set;
		}

		public void Init(Entity entity, List<string> images = null)
		{
			Entity = entity;
			if (images != null)
			{
				for (int i = 0; i < preview.Length; i++)
				{
					preview[i].SpriteUid = images[i];
				}
			}
		}

		public void UpdateData()
		{
			if (Entity.HasComponent<PaymentGiftComponent>())
			{
				PaymentGiftComponent component = Entity.GetComponent<PaymentGiftComponent>();
				Entity entity = Flow.Current.EntityRegistry.GetEntity(component.Gift);
				giftPreview.SpriteUid = entity.GetComponent<ImageItemComponent>().SpriteUid;
				giftLabel.SetActive(true);
				giftPreview.GetComponent<TooltipShowBehaviour>().TipText = MarketItemNameLocalization.GetFullItemDescription(entity, _commonString, _rareString, _epicString, _legendaryString);
			}
			else
			{
				giftLabel.SetActive(false);
			}
			XCrystalsPackComponent component2 = Entity.GetComponent<XCrystalsPackComponent>();
			SaleState saleState = Entity.GetComponent<GoodsComponent>().SaleState;
			bool flag = saleState.AmountMultiplier > 1.0;
			string text = "<b>  ";
			long num = component2.Amount;
			long num2 = (long)Math.Round((double)component2.Amount * saleState.AmountMultiplier);
			long bonus = component2.Bonus;
			string text2;
			if (flag)
			{
				text += num2.ToStringSeparatedByThousands();
				text += string.Format(" <s><#{0}>{1}</color></s>", greyColor.Color.ToHexString(), num.ToStringSeparatedByThousands());
				totalAmount.text = (num2 + bonus).ToStringSeparatedByThousands();
				totalAmount.text += string.Format(" <s><#{0}>{1}</color></s>", greyColor.Color.ToHexString(), (num + bonus).ToStringSeparatedByThousands());
				TextMeshProUGUI textMeshProUGUI = totalAmount;
				text2 = textMeshProUGUI.text;
				textMeshProUGUI.text = text2 + "<sprite=" + xCrySpriteIndex + ">";
			}
			else
			{
				text += num.ToStringSeparatedByThousands();
				totalAmount.text = (num + bonus).ToStringSeparatedByThousands() + "<sprite=" + xCrySpriteIndex + ">";
			}
			text2 = text;
			text = text2 + "</b><sprite=" + xCrySpriteIndex + ">\n";
			text = ((bonus <= 0) ? (text + "\n") : (text + string.Format("<size=17><#{2}>+{0} {1}<sprite=" + xCrySpriteIndex + "></color>", bonus.ToStringSeparatedByThousands(), forFree.Value, greyColor.Color.ToHexString())));
			amount.text = text;
			GoodsComponent component3 = Entity.GetComponent<GoodsComponent>();
			GoodsPriceComponent component4 = Entity.GetComponent<GoodsPriceComponent>();
			bool flag2 = saleState.PriceMultiplier < 1.0;
			text = component4.Round(component3.SaleState.PriceMultiplier * component4.Price).ToStringSeparatedByThousands();
			if (flag2)
			{
				text += string.Format(" <s><#{0}>{1}</color></s>", greyColor.Color.ToHexString(), component4.Price.ToStringSeparatedByThousands());
			}
			text = text + " " + component4.Currency;
			price.text = text;
		}
	}
}
