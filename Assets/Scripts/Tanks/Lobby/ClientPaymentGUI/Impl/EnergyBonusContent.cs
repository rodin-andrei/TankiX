using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientGarage.Impl;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class EnergyBonusContent : DealItemContent
	{
		[SerializeField]
		private Button button;

		[SerializeField]
		private GameObject goBackText;

		[SerializeField]
		private CanvasGroup bottom;

		[SerializeField]
		private Sprite activeBonusSprite;

		[SerializeField]
		private Sprite inactiveBonusSprite;

		[SerializeField]
		private Image bannerImage;

		public virtual string Price
		{
			get;
			set;
		}

		public virtual string Title
		{
			get;
			set;
		}

		public bool Premium
		{
			get;
			set;
		}

		protected override void FillFromEntity(Entity entity)
		{
			if (entity.HasComponent<ImageItemComponent>())
			{
				string spriteUid = entity.GetComponent<ImageItemComponent>().SpriteUid;
				bannerImage.sprite = activeBonusSprite;
			}
			EnergyBonusComponent component = entity.GetComponent<EnergyBonusComponent>();
			int num = component.Bonus;
			if (Premium)
			{
				num = component.PremiumBonus;
			}
			title.text = string.Format(Title, num);
			price.text = Price;
			if (entity.HasComponent<TakenBonusComponent>())
			{
				SetBonusInactive();
			}
			base.FillFromEntity(entity);
		}

		public void SetBonusInactive()
		{
			button.interactable = false;
			goBackText.SetActive(true);
			EndDate = base.Entity.GetComponent<ExpireDateComponent>().Date;
			TextTimerComponent component = GetComponent<TextTimerComponent>();
			component.EndDate = EndDate;
			component.ActiveWhenTimeIsUp = true;
			component.enabled = true;
			bottom.alpha = 0.2f;
			bannerImage.sprite = inactiveBonusSprite;
		}

		public void SetBonusActive()
		{
			button.interactable = true;
			goBackText.SetActive(false);
			TextTimerComponent component = GetComponent<TextTimerComponent>();
			component.enabled = false;
			bottom.alpha = 1f;
			bannerImage.sprite = activeBonusSprite;
		}
	}
}
