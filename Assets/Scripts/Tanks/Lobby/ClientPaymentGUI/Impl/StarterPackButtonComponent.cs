using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientPayment.Impl;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	[RequireComponent(typeof(StarterPackTimerComponent))]
	public class StarterPackButtonComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI text;

		[SerializeField]
		private ImageSkin buttonBG;

		private Entity packEntity;

		public Entity PackEntity
		{
			get
			{
				return packEntity;
			}
			set
			{
				packEntity = value;
				ClearAll();
				if (packEntity != null)
				{
					text.text = packEntity.GetComponent<SpecialOfferContentLocalizationComponent>().Title;
					long num = (long)(packEntity.GetComponent<SpecialOfferEndTimeComponent>().EndDate - Date.Now);
					StarterPackTimerComponent component = GetComponent<StarterPackTimerComponent>();
					component.RunTimer(num);
					component.onTimerExpired = onTimerExpired;
				}
			}
		}

		private void ClearAll()
		{
			text.text = string.Empty;
			StarterPackTimerComponent component = GetComponent<StarterPackTimerComponent>();
			component.StopTimer();
		}

		public void SetImage(string uid)
		{
			buttonBG.SpriteUid = uid;
		}

		public void OnClick()
		{
			ECSBehaviour.EngineService.Engine.ScheduleEvent<StarterPackSystem.ShowStarterPackScreen>(packEntity);
		}

		private void OnDisable()
		{
			PackEntity = null;
		}

		private void onTimerExpired()
		{
			base.gameObject.SetActive(false);
		}
	}
}
