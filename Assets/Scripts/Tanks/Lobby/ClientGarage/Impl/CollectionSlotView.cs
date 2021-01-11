using System;
using Tanks.Lobby.ClientControls.API;
using tanks.modules.lobby.ClientGarage.Scripts.API.UI.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class CollectionSlotView : SlotView
	{
		public ImageSkin moduleIcon;

		public TextMeshProUGUI improveAvailableText;

		public TextMeshProUGUI researchAvailableText;

		public TextMeshProUGUI cardCountText;

		public Color yelloColor;

		public SlotInteractive interactive;

		public Action<CollectionSlotView> onClick;

		public Action<CollectionSlotView> onDoubleClick;

		private ModuleItem moduleItem;

		public ModuleItem ModuleItem
		{
			get
			{
				return moduleItem;
			}
		}

		public void Init(ModuleItem moduleItem)
		{
			this.moduleItem = moduleItem;
			moduleIcon.SpriteUid = moduleItem.CardSpriteUid;
			interactive.moduleItem = moduleItem;
			interactive.onClick = delegate
			{
				onClick(this);
			};
			interactive.onDoubleClick = delegate
			{
				onDoubleClick(this);
			};
			tooltip.SetCustomContentData(moduleItem);
			UpdateView();
		}

		public void UpdateView()
		{
			cardCountText.gameObject.SetActive(false);
			researchAvailableText.gameObject.SetActive(false);
			improveAvailableText.gameObject.SetActive(false);
			moduleIcon.GetComponent<Image>().color = Color.white;
			Color white = Color.white;
			if (moduleItem.UserItem == null)
			{
				cardCountText.gameObject.SetActive(true);
				cardCountText.text = moduleItem.UserCardCount + "/" + moduleItem.CraftPrice.Cards;
				if (moduleItem.ResearchAvailable())
				{
					researchAvailableText.gameObject.SetActive(true);
					moduleIcon.GetComponent<Image>().color = yelloColor;
					white = yelloColor;
				}
			}
			else if (moduleItem.ImproveAvailable())
			{
				improveAvailableText.gameObject.SetActive(true);
				moduleIcon.GetComponent<Image>().color = yelloColor;
				white = yelloColor;
			}
			interactive.UpdateView(white);
		}

		public void Select()
		{
			interactive.Select();
		}

		public void Deselect()
		{
			interactive.Deselect();
		}
	}
}
