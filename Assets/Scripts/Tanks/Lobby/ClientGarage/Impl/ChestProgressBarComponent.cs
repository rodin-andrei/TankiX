using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ChestProgressBarComponent : BehaviourComponent
	{
		[SerializeField]
		private TooltipShowBehaviour tooltip;

		[SerializeField]
		private TooltipShowBehaviour chestTooltip;

		[SerializeField]
		private LocalizedField chestTooltipLocalization;

		[SerializeField]
		private LocalizedField chestTooltipLowLeagueLocalization;

		[SerializeField]
		private UIRectClipper bar;

		[SerializeField]
		private TextMeshProUGUI chestName;

		[SerializeField]
		private ImageSkin chestIcon;

		public void SetProgress(long current, long full)
		{
			bar.ToX = Mathf.Clamp01((float)current / (float)full);
			tooltip.TipText = string.Format("{0} / {1}", current, full);
		}

		public void SetChestTooltip(long score, bool highLeague)
		{
			string text = string.Format(chestTooltipLocalization.Value, score);
			if (!highLeague)
			{
				text += chestTooltipLowLeagueLocalization.Value;
			}
			chestTooltip.TipText = text;
		}

		public void SetChest(string name, string imageUid)
		{
			chestName.text = name;
			chestIcon.SpriteUid = imageUid;
		}
	}
}
