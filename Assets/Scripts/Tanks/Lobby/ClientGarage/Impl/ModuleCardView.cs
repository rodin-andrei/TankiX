using System.Text;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientDataStructures.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.API;
using tanks.modules.lobby.ClientGarage.Scripts.API.UI.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModuleCardView : MonoBehaviour
	{
		[SerializeField]
		private Material[] cardMaterial;

		[SerializeField]
		private TextMeshProUGUI moduleLevel;

		[SerializeField]
		private TextMeshProUGUI moduleName;

		[SerializeField]
		private TextMeshProUGUI moduleCount;

		[SerializeField]
		private Color[] tierColor;

		[SerializeField]
		private Image background;

		public ImageSkin[] imageSkins;

		public Sprite[] tierBackgrounds;

		public MeshRenderer meshRenderer;

		private readonly StringBuilder stringBuilder = new StringBuilder(20);

		public int tierNumber;

		[Inject]
		public static GarageItemsRegistry GarageItemsRegistry
		{
			get;
			set;
		}

		public void UpdateView(long moduleMarketItemId, long upgradeLevel = -1L, bool showName = true, bool showCount = true)
		{
			base.gameObject.SetActive(true);
			ModuleItem moduleItem = GarageItemsRegistry.GetItem<ModuleItem>(moduleMarketItemId);
			imageSkins.ForEach(delegate(ImageSkin i)
			{
				i.SpriteUid = moduleItem.CardSpriteUid;
			});
			imageSkins.ForEach(delegate(ImageSkin i)
			{
				i.transform.gameObject.GetComponent<Image>().color = tierColor[moduleItem.TierNumber];
			});
			SetMaterial(moduleItem.TierNumber);
			tierNumber = moduleItem.TierNumber;
			if (showCount)
			{
				stringBuilder.Length = 0;
				if (moduleItem.UserItem != null)
				{
					stringBuilder.AppendFormat(" {0}/{1}", moduleItem.UserCardCount, moduleItem.UpgradePrice);
				}
				else
				{
					stringBuilder.AppendFormat(" {0}/{1}", moduleItem.UserCardCount, moduleItem.CraftPrice);
				}
				moduleCount.text = stringBuilder.ToString();
			}
			else
			{
				moduleCount.text = string.Empty;
			}
			if (upgradeLevel == -1)
			{
				upgradeLevel = moduleItem.Level;
			}
			if (moduleItem.UserItem != null)
			{
				moduleLevel.text = string.Format("{0}", upgradeLevel + 1);
			}
			else
			{
				moduleLevel.text = string.Format("{0}", upgradeLevel);
			}
			base.name = moduleItem.Name;
			if (showName)
			{
				moduleName.text = string.Format("{0}", base.name);
			}
			else
			{
				moduleName.text = string.Empty;
			}
		}

		private void SetMaterial(int tier)
		{
			meshRenderer.sharedMaterial = cardMaterial[tier];
			background.sprite = tierBackgrounds[tier];
		}

		public void UpdateViewForCrystal(string spriteUid, string name)
		{
			base.gameObject.SetActive(true);
			imageSkins.ForEach(delegate(ImageSkin i)
			{
				i.SpriteUid = spriteUid;
			});
			imageSkins.ForEach(delegate(ImageSkin i)
			{
				i.transform.gameObject.GetComponent<Image>().color = tierColor[0];
			});
			SetMaterial(0);
			stringBuilder.Length = 0;
			moduleName.text = string.Format("{0}", name);
		}
	}
}
