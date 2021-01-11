using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientEntrance.API
{
	[RequireComponent(typeof(Selectable))]
	public class DependentInteractivityComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public List<InteractivityPrerequisiteComponent> prerequisitesObjects;

		public virtual void SetInteractable(bool value)
		{
			GetComponent<Selectable>().interactable = value;
		}

		public virtual void SetCarouselInteractable(bool value)
		{
			GetComponent<CarouselComponent>().BackButton.GetComponent<Button>().interactable = value;
			GetComponent<CarouselComponent>().FrontButton.GetComponent<Button>().interactable = value;
		}

		public virtual void HideCarouselInteractable(bool value)
		{
			if (!value)
			{
				base.transform.parent.localScale = new Vector3(0f, 0f, 0f);
			}
			else
			{
				base.transform.parent.localScale = new Vector3(1f, 1f, 1f);
			}
		}

		public virtual void HideCheckbox(bool value)
		{
			if (!value)
			{
				base.transform.localScale = new Vector3(0f, 0f, 0f);
			}
			else
			{
				base.transform.localScale = new Vector3(1f, 1f, 1f);
			}
		}
	}
}
