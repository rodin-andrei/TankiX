using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class UpgradeXCryModuleButtonComponent : UpgradeModuleBaseButtonComponent, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
	{
		[SerializeField]
		private LocalizedField buyBlueprints;

		[SerializeField]
		private GameObject content;

		public override void Setup(int moduleLevel, int cardsCount, int maxCardCount, int price, int priceXCry, int userCryCount, int userXCryCount)
		{
			if (moduleLevel >= 0 && maxCardCount != 0)
			{
				base.gameObject.SetActive(true);
				Activate();
				if (cardsCount < maxCardCount)
				{
					titleText.text = buyBlueprints.Value;
					Color white = Color.white;
					white.a = 0f;
					fill.color = white;
					Image border = base.border;
					Color notEnoughColor = base.notEnoughColor;
					titleText.color = notEnoughColor;
					border.color = notEnoughColor;
				}
				else
				{
					bool flag = userXCryCount >= priceXCry;
					titleText.text = ((moduleLevel <= -1) ? ((string)activate) : (upgrade.Value + "  " + (flag ? priceXCry.ToString() : ("<color=#" + notEnoughTextColor.ToHexString() + ">" + priceXCry + "</color>")) + "<sprite=9>"));
					Image border2 = base.border;
					Color notEnoughColor = ((!flag) ? base.notEnoughColor : enoughColor);
					titleText.color = notEnoughColor;
					notEnoughColor = notEnoughColor;
					fill.color = notEnoughColor;
					border2.color = notEnoughColor;
				}
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
