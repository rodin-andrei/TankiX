using Platform.Library.ClientUnityIntegration.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class EffectHUDComponent : BehaviourComponent
	{
		[SerializeField]
		private ImageSkin icon;
		[SerializeField]
		private Image indicator;
		[SerializeField]
		private Image indicatorLighting;
		[SerializeField]
		private Image durationProgress;
		[SerializeField]
		private PaletteColorField buffColor;
		[SerializeField]
		private PaletteColorField debuffColor;
		[SerializeField]
		private TextMeshProUGUI timerText;
	}
}
