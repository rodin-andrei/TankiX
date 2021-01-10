using System;
using UnityEngine;

namespace AmplifyBloom
{
	[Serializable]
	public class AmplifyLensFlare
	{
		[SerializeField]
		private float m_overallIntensity;
		[SerializeField]
		private float m_normalizedGhostIntensity;
		[SerializeField]
		private float m_normalizedHaloIntensity;
		[SerializeField]
		private bool m_applyLensFlare;
		[SerializeField]
		private int m_lensFlareGhostAmount;
		[SerializeField]
		private Vector4 m_lensFlareGhostsParams;
		[SerializeField]
		private float m_lensFlareGhostChrDistortion;
		[SerializeField]
		private Gradient m_lensGradient;
		[SerializeField]
		private Texture2D m_lensFlareGradTexture;
		[SerializeField]
		private Vector4 m_lensFlareHaloParams;
		[SerializeField]
		private float m_lensFlareHaloChrDistortion;
		[SerializeField]
		private int m_lensFlareGaussianBlurAmount;
	}
}
