using System;
using UnityEngine;

namespace AmplifyBloom
{
	[Serializable]
	public class AmplifyBokeh
	{
		[SerializeField]
		private bool m_isActive;
		[SerializeField]
		private bool m_applyOnBloomSource;
		[SerializeField]
		private float m_bokehSampleRadius;
		[SerializeField]
		private Vector4 m_bokehCameraProperties;
		[SerializeField]
		private float m_offsetRotation;
		[SerializeField]
		private ApertureShape m_apertureShape;
	}
}
