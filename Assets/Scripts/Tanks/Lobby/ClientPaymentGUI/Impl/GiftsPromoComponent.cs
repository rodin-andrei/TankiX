using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientPayment.API;
using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class GiftsPromoComponent : BehaviourComponent, ContentWithOrder
	{
		public int order = 100;

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
				return true;
			}
		}

		public bool CanFillSmallRow
		{
			get
			{
				return false;
			}
		}

		public void SetParent(Transform parent)
		{
			base.transform.SetParent(parent, false);
		}

		public void Show()
		{
			ECSBehaviour.EngineService.Engine.ScheduleEvent(new GoToXCryShopScreen(), new EntityStub());
		}
	}
}
