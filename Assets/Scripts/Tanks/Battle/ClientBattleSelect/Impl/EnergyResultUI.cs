using UnityEngine;
using System.Collections.Generic;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Battle.ClientBattleSelect.Impl
{
	public class EnergyResultUI : MonoBehaviour
	{
		[SerializeField]
		private List<AnimatedDiffProgress> charges;
		[SerializeField]
		protected TextMeshProUGUI earnedEnergyText;
		[SerializeField]
		protected TextMeshProUGUI compensationCrystalsText;
		[SerializeField]
		protected GameObject compensationCrystalsObject;
		[SerializeField]
		protected TextMeshProUGUI mvpCashbackTextObject;
		[SerializeField]
		protected TextMeshProUGUI chargesFullText;
		[SerializeField]
		private TooltipShowBehaviour energyBarTooltip;
		[SerializeField]
		private TooltipShowBehaviour mvpBonusTooltip;
		[SerializeField]
		private TooltipShowBehaviour unfairBonusTooltip;
		[SerializeField]
		private LocalizedField cashbackText;
		[SerializeField]
		private LocalizedField mvpCashbackText;
		[SerializeField]
		private LocalizedField unfairMatchText;
		[SerializeField]
		private float duration;
		[SerializeField]
		private Color fullColor;
		[SerializeField]
		private Color partColor;
	}
}
