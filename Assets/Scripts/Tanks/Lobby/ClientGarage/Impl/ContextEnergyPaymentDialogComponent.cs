using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ContextEnergyPaymentDialogComponent : BehaviourComponent
	{
		public class HighlightQuickData : TutorialData
		{
			public HighlightQuickData(Entity entity, RectTransform popupPositionRect, string message)
			{
				base.Type = TutorialType.Default;
				base.Message = message;
				base.TutorialStep = base.TutorialStep;
				base.PopupPositionRect = popupPositionRect;
				base.ShowDelay = 0f;
				base.ImageUid = string.Empty;
			}
		}

		private long price;

		private long energy;

		[SerializeField]
		private LocalizedField highlightmMessageLocalization;

		[SerializeField]
		private LocalizedField messageLocalization;

		[SerializeField]
		private LocalizedField priceLocalization;

		[SerializeField]
		private TextMeshProUGUI messageText;

		[SerializeField]
		private TextMeshProUGUI priceText;

		private List<Animator> animators;

		private bool _show;

		public GameObject highlightedObject
		{
			get;
			set;
		}

		public RectTransform tipPositionRect
		{
			get;
			set;
		}

		public bool show
		{
			get
			{
				return _show;
			}
			set
			{
				_show = value;
			}
		}

		protected virtual void OnEnable()
		{
			GetComponentInChildren<CanvasGroup>().alpha = 0f;
			GetComponent<Animator>().SetBool("show", true);
			if (animators == null)
			{
				return;
			}
			foreach (Animator animator in animators)
			{
				animator.SetBool("Visible", false);
			}
		}

		public void Show(long energy, long price)
		{
			this.energy = energy;
			this.price = price;
			messageText.text = string.Format(messageLocalization.Value, energy);
			priceText.text = string.Format(priceLocalization.Value, price);
			Show(null);
		}

		public void Show(List<Animator> animators)
		{
			MainScreenComponent.Instance.OverrideOnBack(Hide);
			this.animators = animators;
			show = true;
			if (base.gameObject.activeInHierarchy)
			{
				OnEnable();
			}
			else
			{
				base.gameObject.SetActive(true);
			}
		}

		public void Hide()
		{
			MainScreenComponent.Instance.ClearOnBackOverride();
			show = false;
			GetComponent<Animator>().SetBool("show", false);
			if (animators == null)
			{
				return;
			}
			foreach (Animator animator in animators)
			{
				animator.SetBool("Visible", true);
			}
		}

		public void OnHide()
		{
			if (show)
			{
				OnEnable();
			}
			else
			{
				base.gameObject.SetActive(false);
			}
		}

		public void BuyEnergy()
		{
			Hide();
			if (GetComponent<EntityBehaviour>() != null)
			{
				Entity entity = GetComponent<EntityBehaviour>().Entity;
				NewEvent(new PressEnergyContextBuyButtonEvent(energy, price)).Attach(entity).Schedule();
			}
		}

		public void HighlightQuickBattles()
		{
			Hide();
			EntityBehaviour component = GetComponent<EntityBehaviour>();
			if (component != null)
			{
				Entity entity = component.Entity;
				string value = highlightmMessageLocalization.Value;
				HighlightQuickData highlightQuickData = new HighlightQuickData(entity, tipPositionRect, value);
				highlightQuickData.ContinueOnClick = true;
				TutorialCanvas.Instance.AddAllowSelectable(highlightedObject.GetComponentInChildren<Button>());
				TutorialCanvas.Instance.Show(highlightQuickData, true, new GameObject[1]
				{
					highlightedObject
				});
			}
		}
	}
}
