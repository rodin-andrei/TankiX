using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class ExitBattleWindow : LocalizedControl
	{
		[SerializeField]
		private TextMeshProUGUI yesText;
		[SerializeField]
		private TextMeshProUGUI noText;
		[SerializeField]
		private TextMeshProUGUI headerText;
		[SerializeField]
		private TextMeshProUGUI firstLineText;
		[SerializeField]
		private TextMeshProUGUI secondLineText;
		[SerializeField]
		private TextMeshProUGUI thirdLineText;
		[SerializeField]
		private TextMeshProUGUI warningText;
		[SerializeField]
		private Button yes;
		[SerializeField]
		private Button no;
		[SerializeField]
		private Color newbieHeaderColor;
		[SerializeField]
		private Color regularHeaderColor;
		[SerializeField]
		private Image warningSign;
	}
}
