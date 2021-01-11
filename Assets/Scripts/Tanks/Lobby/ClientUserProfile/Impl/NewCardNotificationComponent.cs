using System.Collections;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientUserProfile.API;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class NewCardNotificationComponent : BehaviourComponent, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, AttachToEntityListener, DetachFromEntityListener, IEventSystemHandler
	{
		[SerializeField]
		private bool clickAnywhere;

		private bool isClicked;

		private bool isHiden;

		private Entity entity;

		[SerializeField]
		private Transform container;

		void AttachToEntityListener.AttachedToEntity(Entity entity)
		{
			this.entity = entity;
		}

		private void Awake()
		{
			GetComponent<Animator>().SetFloat("multiple", Random.Range(0.9f, 1.1f));
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			GetComponent<Animator>().SetBool("selected", true);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			GetComponent<Animator>().SetBool("selected", false);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (isClicked && !isHiden)
			{
				GetComponent<Animator>().SetTrigger("end");
				base.transform.GetComponentInParent<NotificationsContainerComponent>().hidenCards++;
				isHiden = true;
			}
			else
			{
				MouseClicked();
				isClicked = true;
			}
		}

		public void OpenCardsButtonClicked()
		{
			GetComponent<Animator>().SetTrigger("Button");
			MouseClicked();
			isClicked = true;
		}

		public void CloseCardsButtonClicked()
		{
			GetComponent<Animator>().SetTrigger("end");
			StartCoroutine(NotificationClickEvent());
		}

		private void MouseClicked()
		{
			if (!isClicked)
			{
				GetComponent<Animator>().SetTrigger("click");
				base.transform.GetComponentInParent<NotificationsContainerComponent>().openedCards++;
			}
		}

		private IEnumerator NotificationClickEvent()
		{
			yield return new WaitForSeconds(0.5f);
			ECSBehaviour.EngineService.Engine.ScheduleEvent<NotificationClickEvent>(entity);
			base.enabled = false;
		}

		void DetachFromEntityListener.DetachedFromEntity(Entity entity)
		{
			this.entity = null;
		}

		private void DestroyHidenCards()
		{
			StartCoroutine(NotificationClickEvent());
		}

		private void OnDestroy()
		{
			if (base.transform.GetComponentInParent<NotificationsContainerComponent>() != null && isClicked)
			{
				base.transform.GetComponentInParent<NotificationsContainerComponent>().openedCards--;
				if (isHiden)
				{
					base.transform.GetComponentInParent<NotificationsContainerComponent>().hidenCards--;
				}
			}
		}
	}
}
