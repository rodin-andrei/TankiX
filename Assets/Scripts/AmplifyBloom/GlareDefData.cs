using System;
using UnityEngine;

namespace AmplifyBloom
{
	[Serializable]
	public class GlareDefData
	{
		public bool FoldoutValue;
		[SerializeField]
		private StarLibType m_starType;
		[SerializeField]
		private float m_starInclination;
		[SerializeField]
		private float m_chromaticAberration;
		[SerializeField]
		private StarDefData m_customStarData;
	}
}
