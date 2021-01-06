using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class HPBarGlow : HUDBar
	{
		[SerializeField]
		private Image fill;
		[SerializeField]
		private Image diff;
		[SerializeField]
		private TextMeshProUGUI hpValues;
		[SerializeField]
		private HPBarFillEnd hpBarFillEnd;
	}
}
