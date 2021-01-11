using Tanks.Lobby.ClientSettings.API;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityStandardAssets.ImageEffects;

namespace Tanks.Battle.ClientGraphics.API
{
	public class SetPostProcessing : MonoBehaviour
	{
		private PostProcessingProfile profile;

		[SerializeField]
		private MonoBehaviour Bloom;

		[SerializeField]
		private MonoBehaviour Fog;

		[SerializeField]
		private MonoBehaviour TargetBloom;

		public bool forcedFog;

		public bool lowRenderResolution;

		private ColorCorrectionCurves colorCorrection;

		private RenderTexture texture;

		private float renderCoeff = 0.7f;

		private void OnEnable()
		{
			PostProcessingBehaviour component = GetComponent<PostProcessingBehaviour>();
			if (component.profile == null)
			{
				base.enabled = false;
				return;
			}
			profile = Object.Instantiate(component.profile);
			component.profile = profile;
			DisableAllEffects(profile);
			int qualityLevel = QualitySettings.GetQualityLevel();
			Fog.enabled = qualityLevel >= 2 && GraphicsSettings.INSTANCE != null && GraphicsSettings.INSTANCE.CurrentShadowQuality != 0;
			profile.userLut.enabled = qualityLevel >= 2;
			profile.colorGrading.enabled = qualityLevel >= 2;
			if (profile.colorGrading.enabled)
			{
				ColorGradingModel.Settings settings = profile.colorGrading.settings;
				settings.basic.saturation = ((GraphicsSettings.INSTANCE != null) ? GraphicsSettings.INSTANCE.CurrentSaturationLevel : 1f);
				profile.colorGrading.settings = settings;
			}
			if (GraphicsSettings.INSTANCE != null && GraphicsSettings.INSTANCE.customSettings)
			{
				SetCustomSettings();
			}
			else
			{
				SetDefaultSettings();
			}
		}

		private void DisableAllEffects(PostProcessingProfile postProcessingProfile)
		{
			Bloom.enabled = false;
			Fog.enabled = false;
			TargetBloom.enabled = false;
			postProcessingProfile.ambientOcclusion.enabled = false;
			postProcessingProfile.antialiasing.enabled = false;
			postProcessingProfile.bloom.enabled = false;
			postProcessingProfile.chromaticAberration.enabled = false;
			postProcessingProfile.colorGrading.enabled = false;
			postProcessingProfile.debugViews.enabled = false;
			postProcessingProfile.depthOfField.enabled = false;
			postProcessingProfile.dithering.enabled = false;
			postProcessingProfile.eyeAdaptation.enabled = false;
			postProcessingProfile.fog.enabled = false;
			postProcessingProfile.grain.enabled = false;
			postProcessingProfile.motionBlur.enabled = false;
			postProcessingProfile.screenSpaceReflection.enabled = false;
			postProcessingProfile.userLut.enabled = false;
			postProcessingProfile.vignette.enabled = false;
		}

		private void SetDefaultSettings()
		{
			int qualityLevel = QualitySettings.GetQualityLevel();
			if (qualityLevel == 0)
			{
				lowRenderResolution = true;
				texture = new RenderTexture((int)((float)Screen.width * renderCoeff), (int)((float)Screen.height * renderCoeff), 0);
				RenderTexture.active = texture;
				QualitySettings.pixelLightCount = 0;
				GetComponent<Camera>().hdr = false;
			}
			else
			{
				lowRenderResolution = false;
			}
			TargetBloom.enabled = qualityLevel >= 3;
			Bloom.enabled = qualityLevel >= 3;
			profile.chromaticAberration.enabled = qualityLevel >= 2;
			profile.antialiasing.enabled = qualityLevel >= 3;
			if (profile.antialiasing.enabled)
			{
				AntialiasingModel.Settings settings = profile.antialiasing.settings;
				settings.method = ((qualityLevel > 3) ? AntialiasingModel.Method.Taa : AntialiasingModel.Method.Fxaa);
				profile.antialiasing.settings = settings;
			}
			profile.vignette.enabled = qualityLevel >= 3;
			profile.ambientOcclusion.enabled = qualityLevel >= 5;
		}

		private void SetCustomSettings()
		{
			lowRenderResolution = GraphicsSettings.INSTANCE.CurrentRenderResolutionQuality == 1;
			if (lowRenderResolution)
			{
				texture = new RenderTexture((int)((float)Screen.width * renderCoeff), (int)((float)Screen.height * renderCoeff), 0);
				RenderTexture.active = texture;
			}
			Bloom.enabled = GraphicsSettings.INSTANCE.currentBloom;
			TargetBloom.enabled = GraphicsSettings.INSTANCE.currentBloom;
			if (GraphicsSettings.INSTANCE.currentBloom)
			{
				profile.colorGrading.enabled = true;
				profile.userLut.enabled = true;
			}
			profile.antialiasing.enabled = GraphicsSettings.INSTANCE.CurrentAntialiasingQuality == 1;
			if (profile.antialiasing.enabled)
			{
				AntialiasingModel.Settings settings = profile.antialiasing.settings;
				settings.method = ((QualitySettings.GetQualityLevel() > 3) ? AntialiasingModel.Method.Taa : AntialiasingModel.Method.Fxaa);
				profile.antialiasing.settings = settings;
			}
			profile.ambientOcclusion.enabled = GraphicsSettings.INSTANCE.currentAmbientOcclusion;
			profile.chromaticAberration.enabled = GraphicsSettings.INSTANCE.currentChromaticAberration;
			profile.grain.enabled = GraphicsSettings.INSTANCE.currentGrain;
			profile.vignette.enabled = GraphicsSettings.INSTANCE.currentVignette;
		}

		private void OnPreRender()
		{
			if (lowRenderResolution)
			{
				Camera.main.targetTexture = texture;
			}
		}

		private void OnPostRender()
		{
			if (lowRenderResolution)
			{
				Camera.main.targetTexture = null;
			}
		}
	}
}
