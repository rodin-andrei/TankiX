using System.Collections.Generic;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class PlayScreenEnergyComponent : BehaviourComponent
	{
		[SerializeField]
		private Color fullColor;

		[SerializeField]
		private Color partColor;

		private long maxEnergy;

		private long quantumCost;

		[SerializeField]
		private List<UIRectClipperY> energyBar;

		[SerializeField]
		private TextMeshProUGUI quantumCountText;

		[SerializeField]
		private TooltipShowBehaviour tooltip;

		public void Init(long maxEnergy, long cost)
		{
			this.maxEnergy = maxEnergy;
			quantumCost = cost;
		}

		public void SetEnergy(long currentEnergy)
		{
			long num = currentEnergy / quantumCost;
			for (int i = 0; i < energyBar.Count; i++)
			{
				if (i < num)
				{
					energyBar[i].ToY = 1f;
					energyBar[i].gameObject.GetComponent<Image>().color = fullColor;
				}
				else if (i == num)
				{
					energyBar[i].ToY = (float)(currentEnergy - num * quantumCost) / (float)quantumCost;
					energyBar[i].gameObject.GetComponent<Image>().color = partColor;
				}
				else
				{
					energyBar[i].ToY = 0f;
				}
			}
			quantumCountText.text = "<size=25><sprite=0></size> " + num + " / 3";
			tooltip.TipText = string.Format("{0} / {1}", currentEnergy, maxEnergy);
		}
	}
}
