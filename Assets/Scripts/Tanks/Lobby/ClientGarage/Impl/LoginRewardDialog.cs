using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class LoginRewardDialog : ConfirmDialogComponent
	{
		public RectTransform itemsContainer;

		public ReleaseGiftItemComponent itemPrefab;

		public float itemsShowDelay = 0.6f;

		public ImageSkin leagueIcon;

		public TextMeshProUGUI headerText;

		public TextMeshProUGUI text;

		public LoginRewardAllItemsContainer allItems;

		public List<Entity> marketItems = new List<Entity>();

		[SerializeField]
		private LocalizedField paint;

		[SerializeField]
		private LocalizedField coating;

		[SerializeField]
		private LocalizedField dayShort;

		[SerializeField]
		private LocalizedField container;

		[SerializeField]
		private LocalizedField premium;

		public void ScrollToCurrentDay()
		{
			allItems.ScrollToCurrentDay();
		}

		public string GetRewardItemName(Entity marketItemEntity)
		{
			string text = marketItemEntity.GetComponent<DescriptionItemComponent>().Name;
			if (marketItemEntity.HasComponent<WeaponPaintItemComponent>())
			{
				text = coating.Value + "\n" + text;
			}
			else if (marketItemEntity.HasComponent<PaintItemComponent>())
			{
				text = paint.Value + "\n" + text;
			}
			else if (marketItemEntity.HasComponent<ContainerMarkerComponent>())
			{
				text = container.Value + "\n" + text;
			}
			else if (marketItemEntity.HasComponent<PremiumBoostItemComponent>())
			{
				text = premium.Value + " {0} " + dayShort.Value;
			}
			return text;
		}

		public string GetRewardItemNameWithAmount(Entity marketItemEntity, int amount)
		{
			string name = marketItemEntity.GetComponent<DescriptionItemComponent>().Name;
			if (marketItemEntity.HasComponent<WeaponPaintItemComponent>())
			{
				return coating.Value + " " + name;
			}
			if (marketItemEntity.HasComponent<PaintItemComponent>())
			{
				return paint.Value + " " + name;
			}
			if (marketItemEntity.HasComponent<PremiumBoostItemComponent>())
			{
				return premium.Value + " " + amount + " " + dayShort.Value;
			}
			if (marketItemEntity.HasComponent<ContainerMarkerComponent>())
			{
				return container.Value + "\n" + name + " x" + amount;
			}
			return name + " x" + amount;
		}
	}
}
