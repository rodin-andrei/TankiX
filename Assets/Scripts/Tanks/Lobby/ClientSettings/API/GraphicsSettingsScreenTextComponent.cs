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

		public string ReloadText
		{
			set
			{
				reloadText.text = value;
			}
		}

		public string PerfomanceChangeText
		{
			set
			{
				perfomanceChangeText.text = value;
			}
		}

		public string CurrentPerfomanceText
		{
			set
			{
				currentPerfomanceText.text = value;
			}
		}

		public string WindowModeText
		{
			set
			{
				windowModeText.text = value;
			}
		}

		public string ScreenResolutionText
		{
			set
			{
				resolutionText.text = value;
			}
		}

		public string QualityLevelText
		{
			set
			{
				qualityText.text = value;
			}
		}

		public string SaturationLevelText
		{
			set
			{
				saturationLevelText.text = value;
			}
		}

		public string RenderResolutionQualityText
		{
			set
			{
				renderResolutionQualityText.text = value;
			}
		}

		public string AntialiasingQualityText
		{
			set
			{
				antialiasingQualityText.text = value;
			}
		}

		public string TextureQualityText
		{
			set
			{
				textureQualityText.text = value;
			}
		}

		public string ShadowQualityText
		{
			set
			{
				shadowQualityText.text = value;
			}
		}

		public string ParticleQualityText
		{
			set
			{
				particleQualityText.text = value;
			}
		}

		public string AnisotropicQualityText
		{
			set
			{
				anisotropicQualityText.text = value;
			}
		}

		public string CustomSettingsModeText
		{
			set
			{
				customSettingsModeText.text = value;
			}
		}

		public string AmbientOccluisonModeText
		{
			set
			{
				ambientOccluisonModeText.text = value;
			}
		}

		public string BloomModeText
		{
			set
			{
				bloomModeText.text = value;
			}
		}

		public string ChromaticAberrationModeText
		{
			set
			{
				chromaticAberrationModeText.text = value;
			}
		}

		public string GrainModeText
		{
			set
			{
				grainModeText.text = value;
			}
		}

		public string VignetteModeText
		{
			set
			{
				vignetteModeText.text = value;
			}
		}

		public string VegetationQualityText
		{
			set
			{
				vegetationQualityText.text = value;
			}
		}

		public string GrassQualityText
		{
			set
			{
				grassQualityText.text = value;
			}
		}

		public string CartridgeCaseAmountText
		{
			set
			{
				cartridgeCaseAmountText.text = value;
			}
		}

		public string VSyncQualityText
		{
			set
			{
				vSyncQualityText.text = value;
			}
		}
	}
}
