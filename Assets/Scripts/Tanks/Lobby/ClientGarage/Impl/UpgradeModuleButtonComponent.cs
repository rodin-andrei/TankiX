using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class UpgradeModuleButtonComponent : UpgradeModuleBaseButtonComponent, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
	{
		[SerializeField]
		private LocalizedField notEnoughBlueprints;

		[SerializeField]
		private GameObject content;

		public override void Setup(int moduleLevel, int cardsCount, int maxCardCount, int price, int priceXCry, int userCryCount, int userXCryCount)
		{
			if (moduleLevel >= 0)
			{
				base.gameObject.SetActive(true);
				if (maxCardCount == 0)
				{
					FullUpgraded();
					return;
				}
				Activate();
				Color notEnoughColor;
				if (cardsCount < maxCardCount)
				{
					GetComponent<Button>().interactable = false;
					titleText.text = notEnoughBlueprints.Value;
					fill.color = notEnoughFillColor;
					Image border = base.border;
					notEnoughColor = base.notEnoughColor;
					titleText.color = notEnoughColor;
					border.color = notEnoughColor;
					return;
				}
				GetComponent<Button>().interactable = true;
				bool flag = userCryCount >= price;
				titleText.text = ((moduleLevel <= -1) ? ((string)activate) : (upgrade.Value + "  " + (flag ? price.ToString() : ("<color=#" + notEnoughTextColor.ToHexString() + ">" + price + "</color>")) + "<sprite=8>"));
				Image border2 = base.border;
				notEnoughColor = ((!flag) ? base.notEnoughColor : enoughColor);
				titleText.color = notEnoughColor;
				notEnoughColor = notEnoughColor;
				fill.color = notEnoughColor;
				border2.color = notEnoughColor;
			}
			else
			{
				base.gameObject.SetActive(false);
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (content != null)
			{
				ModulePropertyView[] componentsInChildren = content.GetComponentsInChildren<ModulePropertyView>();
				foreach (ModulePropertyView modulePropertyView in componentsInChildren)
				{
					modulePropertyView.FillNext.SetActive(true);
					modulePropertyView.NextString.SetActive(true);
				}
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (content != null)
			{
				ModulePropertyView[] componentsInChildren = content.GetComponentsInChildren<ModulePropertyView>();
				foreach (ModulePropertyView modulePropertyView in componentsInChildren)
				{
					modulePropertyView.FillNext.SetActive(false);
					modulePropertyView.NextString.SetActive(false);
				}
			}
		}
	}
}
