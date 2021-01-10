using System;
using UnityEngine;

namespace AmplifyBloom
{
	[Serializable]
	public class AmplifyBloomBase : MonoBehaviour
	{
		[SerializeField]
		private Texture m_maskTexture;
		[SerializeField]
		private RenderTexture m_targetTexture;
		[SerializeField]
		private bool m_showDebugMessages;
		[SerializeField]
		private int m_softMaxdownscales;
		[SerializeField]
		private DebugToScreenEnum m_debugToScreen;
		[SerializeField]
		private bool m_highPrecision;
		[SerializeField]
		private Vector4 m_bloomRange;
		[SerializeField]
		private float m_overallThreshold;
		[SerializeField]
		private Vector4 m_bloomParams;
		[SerializeField]
		private bool m_temporalFilteringActive;
		[SerializeField]
		private float m_temporalFilteringValue;
		[SerializeField]
		private int m_bloomDownsampleCount;
		[SerializeField]
		private AnimationCurve m_temporalFilteringCurve;
		[SerializeField]
		private bool m_separateFeaturesThreshold;
		[SerializeField]
		private float m_featuresThreshold;
		[SerializeField]
		private AmplifyLensFlare m_lensFlare;
		[SerializeField]
		private bool m_applyLensDirt;
		[SerializeField]
		private float m_lensDirtStrength;
		[SerializeField]
		private Texture m_lensDirtTexture;
		[SerializeField]
		private bool m_applyLensStardurst;
		[SerializeField]
		private Texture m_lensStardurstTex;
		[SerializeField]
		private float m_lensStarburstStrength;
		[SerializeField]
		private AmplifyGlare m_anamorphicGlare;
		[SerializeField]
		private AmplifyBokeh m_bokehFilter;
		[SerializeField]
		private float[] m_upscaleWeights;
		[SerializeField]
		private float[] m_gaussianRadius;
		[SerializeField]
		private int[] m_gaussianSteps;
		[SerializeField]
		private float[] m_lensDirtWeights;
		[SerializeField]
		private float[] m_lensStarburstWeights;
		[SerializeField]
		private bool[] m_downscaleSettingsFoldout;
		[SerializeField]
		private int m_featuresSourceId;
		[SerializeField]
		private UpscaleQualityEnum m_upscaleQuality;
		[SerializeField]
		private MainThresholdSizeEnum m_mainThresholdSize;
	}
}
