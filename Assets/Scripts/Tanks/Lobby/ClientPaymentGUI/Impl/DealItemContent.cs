using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.Impl;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class DealItemContent : LocalizedControl, Platform.Kernel.ECS.ClientEntitySystem.API.Component, ListItemContent, ContentWithOrder
	{
		private Entity entity;

		protected Date EndDate = new Date(float.PositiveInfinity);

		public TextMeshProUGUI title;

		public TextMeshProUGUI description;

		public ImageSkin banner;

		public TextMeshProUGUI price;

		public int order = 100;

		public bool canFillBigRow;

		public bool canFillSmallRow = true;

		[Inject]
		public new static EngineServiceInternal EngineService
		{
			get;
			set;
		}

		public Entity Entity
		{
			get
			{
				return entity;
			}
		}

		public int Order
		{
			get
			{
				return order;
			}
		}

		public bool CanFillBigRow
		{
			get
			{
				return canFillBigRow;
			}
		}

		public bool CanFillSmallRow
		{
			get
			{
				return canFillSmallRow;
			}
		}

		public void SetDataProvider(object dataProvider)
		{
			if (entity != dataProvider)
			{
				entity = (Entity)dataProvider;
				FillFromEntity(entity);
			}
		}

		protected virtual void FillFromEntity(Entity entity)
		{
		}

		private void OnEnable()
		{
			GetComponent<TextTimerComponent>().EndDate = EndDate;
		}

		public void Select()
		{
			if (!entity.HasComponent<SelectedListItemComponent>())
			{
				entity.AddComponent<SelectedListItemComponent>();
			}
			EngineService.Engine.ScheduleEvent<ListItemSelectedEvent>(entity);
		}

		public virtual void SetParent(Transform parent)
		{
			base.transform.SetParent(parent, false);
		}
	}
}
