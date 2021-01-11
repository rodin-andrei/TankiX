using Lobby.ClientPayment.Impl;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class PaymentMethodContent : MonoBehaviour, ListItemContent
	{
		private Entity entity;

		[SerializeField]
		private ImageListSkin skin;

		[SerializeField]
		private TextMeshProUGUI text;

		[SerializeField]
		private GameObject saleItem;

		[SerializeField]
		private GameObject saleItemLabelEmpty;

		[SerializeField]
		private GameObject saleItemXtraLabelEmpty;

		[SerializeField]
		private TextMeshProUGUI saleItemLabelText;

		[Inject]
		public static EngineServiceInternal EngineService
		{
			get;
			set;
		}

		private void SetMethodName(string name)
		{
			skin.SelectSprite(name);
		}

		public void Select()
		{
			if (!entity.HasComponent<SelectedListItemComponent>())
			{
				entity.AddComponent<SelectedListItemComponent>();
			}
			EngineService.Engine.ScheduleEvent<ListItemSelectedEvent>(entity);
		}

		public void SetDataProvider(object dataProvider)
		{
			entity = (Entity)dataProvider;
			FillFromEntity(entity);
		}

		private void FillFromEntity(Entity entity)
		{
			if (entity.HasComponent<PaymentMethodComponent>())
			{
				PaymentMethodComponent component = entity.GetComponent<PaymentMethodComponent>();
				SetMethodName(component.MethodName);
				text.text = component.ShownName;
				saleItem.SetActive(false);
				saleItemLabelEmpty.SetActive(false);
				saleItemXtraLabelEmpty.SetActive(false);
				saleItemLabelText.text = string.Empty;
			}
		}
	}
}
