using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class UpgradeBarPropertyUI : UpgradePropertyUI
	{
		[SerializeField]
		protected GameObject barContent;
		[SerializeField]
		protected Slider currentValueSlider;
		[SerializeField]
		protected Slider nextValueSlider;
		[SerializeField]
		protected RectTransform currentValueFill;
		[SerializeField]
		protected RectTransform nextValueFill;
	}
}
