using UnityEngine.UI;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class HPBar : HUDBar
	{
		[SerializeField]
		private Image fill;
		[SerializeField]
		private Image fillUnderDiff;
		[SerializeField]
		private Image diff;
		[SerializeField]
		private TankPartItemIcon hullIcon;
		[SerializeField]
		private TextMeshProUGUI hpValues;
	}
}
