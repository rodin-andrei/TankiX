using Tanks.Lobby.ClientNavigation.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientSettings.API
{
	public class GraphicsSettingsScreenTextComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private TextMeshProUGUI reloadText;
		[SerializeField]
		private TextMeshProUGUI perfomanceChangeText;
		[SerializeField]
		private TextMeshProUGUI currentPerfomanceText;
		[SerializeField]
		private TextMeshProUGUI windowModeText;
		[SerializeField]
		private TextMeshProUGUI resolutionText;
		[SerializeField]
		private TextMeshProUGUI qualityText;
		[SerializeField]
		private TextMeshProUGUI saturationLevelText;
		[SerializeField]
		private TextMeshProUGUI renderResolutionQualityText;
		[SerializeField]
		private TextMeshProUGUI antialiasingQualityText;
		[SerializeField]
		private TextMeshProUGUI textureQualityText;
		[SerializeField]
		private TextMeshProUGUI shadowQualityText;
		[SerializeField]
		private TextMeshProUGUI particleQualityText;
		[SerializeField]
		private TextMeshProUGUI anisotropicQualityText;
		[SerializeField]
		private TextMeshProUGUI customSettingsModeText;
		[SerializeField]
		private TextMeshProUGUI ambientOccluisonModeText;
		[SerializeField]
		private TextMeshProUGUI bloomModeText;
		[SerializeField]
		private TextMeshProUGUI chromaticAberrationModeText;
		[SerializeField]
		private TextMeshProUGUI grainModeText;
		[SerializeField]
		private TextMeshProUGUI vignetteModeText;
		[SerializeField]
		private TextMeshProUGUI vegetationQualityText;
		[SerializeField]
		private TextMeshProUGUI grassQualityText;
		[SerializeField]
		private TextMeshProUGUI cartridgeCaseAmountText;
		[SerializeField]
		private TextMeshProUGUI vSyncQualityText;
	}
}
