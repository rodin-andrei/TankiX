using System;
using UnityEngine;

namespace AmplifyBloom
{
	[Serializable]
	public class AmplifyGlare
	{
		[SerializeField]
		private GlareDefData[] m_customGlareDef;
		[SerializeField]
		private int m_customGlareDefIdx;
		[SerializeField]
		private int m_customGlareDefAmount;
		[SerializeField]
		private bool m_applyGlare;
		[SerializeField]
		private Color _overallTint;
		[SerializeField]
		private Gradient m_cromaticAberrationGrad;
		[SerializeField]
		private int m_glareMaxPassCount;
		[SerializeField]
		private int m_currentWidth;
		[SerializeField]
		private int m_currentHeight;
		[SerializeField]
		private GlareLibType m_currentGlareType;
		[SerializeField]
		private int m_currentGlareIdx;
		[SerializeField]
		private float m_perPassDisplacement;
		[SerializeField]
		private float m_intensity;
		[SerializeField]
		private float m_overallStreakScale;
	}
}
