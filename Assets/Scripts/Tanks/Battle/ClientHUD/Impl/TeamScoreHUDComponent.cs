using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class TeamScoreHUDComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI redScore;
		[SerializeField]
		private LayoutElement space;
		[SerializeField]
		private RectTransform leftScoreBack;
		[SerializeField]
		private RectTransform rightScoreBack;
		[SerializeField]
		private TextMeshProUGUI blueScore;
	}
}
