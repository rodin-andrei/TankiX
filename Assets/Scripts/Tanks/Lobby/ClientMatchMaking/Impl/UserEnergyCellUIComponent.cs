using System;
using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientMatchMaking.Impl
{
	public class UserEnergyCellUIComponent : BehaviourComponent, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
	{
		[SerializeField]
		private TextMeshProUGUI nickname;

		[SerializeField]
		private TextMeshProUGUI energyValue;

		[SerializeField]
		private TextMeshProUGUI energyGiftText;

		[SerializeField]
		private Color notEnoughColor;

		[SerializeField]
		private Image borederImage;

		[SerializeField]
		private GameObject enoughView;

		[SerializeField]
		private GameObject notEnoughView;

		[SerializeField]
		private TextMeshProUGUI text;

		[SerializeField]
		private LocalizedField shareEnergyText;

		[SerializeField]
		private LocalizedField buyEnergyText;

		[SerializeField]
		private GameObject shareButton;

		[SerializeField]
		private GameObject line;

		[SerializeField]
		private LocalizedField chargesAmountSingularText;

		[SerializeField]
		private LocalizedField chargesAmountPlural1Text;

		[SerializeField]
		private LocalizedField chargesAmountPlural2Text;

		[SerializeField]
		private LocalizedField fromText;

		private bool enoughEnergyForEnterToBattle;

		private long shareEnergyValue;

		private bool buy;

		[Inject]
		public new static EngineServiceInternal EngineService
		{
			get;
			set;
		}

		private bool shareButtonIsOpen
		{
			get
			{
				return GetComponent<Animator>().GetBool("showShareButton");
			}
		}

		public bool CellIsFirst
		{
			set
			{
				line.SetActive(!value);
				GetComponent<LayoutElement>().preferredWidth = ((!value) ? 150 : 70);
			}
		}

		public bool Ready
		{
			get
			{
				return enoughEnergyForEnterToBattle;
			}
		}

		public long ShareEnergyValue
		{
			get
			{
				return shareEnergyValue;
			}
		}

		public bool Buy
		{
			get
			{
				return buy;
			}
		}

		public void SetShareEnergyText(long value, bool buy)
		{
			shareEnergyValue = value;
			this.buy = buy;
			string arg = Pluralize((int)value);
			text.text = string.Format((!buy) ? shareEnergyText : buyEnergyText, arg);
		}

		public void Setup(string nickname, long energyValue, long energyCost)
		{
			this.nickname.text = nickname;
			string text = string.Format("{0}/{1}", Mathf.Min(energyCost, energyValue), energyCost);
			if (this.energyValue.text != text)
			{
				this.energyValue.text = text;
				HideShareButton();
			}
			enoughEnergyForEnterToBattle = energyValue >= energyCost;
			this.energyValue.color = ((!enoughEnergyForEnterToBattle) ? notEnoughColor : Color.white);
			borederImage.color = this.energyValue.color;
			enoughView.SetActive(enoughEnergyForEnterToBattle);
			notEnoughView.SetActive(!enoughEnergyForEnterToBattle);
		}

		public void SetGiftValue(long value, List<string> uids = null)
		{
			if (value == 0)
			{
				energyGiftText.text = string.Empty;
				return;
			}
			energyGiftText.text = string.Format("{0} {1}\n", Pluralize((int)value), fromText.Value);
			if (uids == null)
			{
				return;
			}
			for (int i = 0; i < uids.Count; i++)
			{
				string text = uids[i];
				energyGiftText.text += text;
				if (i != uids.Count - 1)
				{
					energyGiftText.text += ", ";
				}
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			Entity entity = GetComponent<EntityBehaviour>().Entity;
			entity.RemoveComponentIfPresent<AdditionalTeleportEnergyPreviewComponent>();
			entity.AddComponent<AdditionalTeleportEnergyPreviewComponent>();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			Entity entity = GetComponent<EntityBehaviour>().Entity;
			entity.RemoveComponentIfPresent<AdditionalTeleportEnergyPreviewComponent>();
		}

		public void ShowShareButton()
		{
			if (shareButtonIsOpen)
			{
				HideShareButton();
				return;
			}
			EngineService.Engine.ScheduleEvent<HideAllShareButtonsEvent>(new EntityStub());
			GetComponent<Animator>().SetBool("showShareButton", true);
		}

		public void HideShareButton()
		{
			GetComponent<Animator>().SetBool("showShareButton", false);
		}

		private string Pluralize(int amount)
		{
			CaseType @case = CasesUtil.GetCase(amount);
			string arg = "<color=#84F6F6FF>" + amount + "</color>";
			switch (@case)
			{
			case CaseType.DEFAULT:
				return string.Format(chargesAmountPlural1Text.Value, arg);
			case CaseType.ONE:
				return string.Format(chargesAmountSingularText.Value, arg);
			case CaseType.TWO:
				return string.Format(chargesAmountPlural2Text.Value, arg);
			default:
				throw new Exception("ivnalid case");
			}
		}
	}
}
