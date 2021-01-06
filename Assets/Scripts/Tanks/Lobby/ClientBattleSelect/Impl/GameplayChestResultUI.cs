using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class GameplayChestResultUI : MonoBehaviour
	{
		[SerializeField]
		private AnimatedDiffRadialProgress progress;
		[SerializeField]
		protected TextMeshProUGUI progressValue;
		[SerializeField]
		private ImageSkin chestIcon;
		[SerializeField]
		private Button openChestButton;
		[SerializeField]
		private Animator animator;
		[SerializeField]
		private TooltipShowBehaviour progressTooltip;
		[SerializeField]
		private LocalizedField progressValueFormat;
		public long chestCount;
		[SerializeField]
		private long previousScores;
		[SerializeField]
		private long earnedScores;
		[SerializeField]
		private long limitScores;
	}
}
