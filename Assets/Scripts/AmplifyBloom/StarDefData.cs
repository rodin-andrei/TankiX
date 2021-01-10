using System;
using UnityEngine;

namespace AmplifyBloom
{
	[Serializable]
	public class StarDefData
	{
		[SerializeField]
		private StarLibType m_starType;
		[SerializeField]
		private string m_starName;
		[SerializeField]
		private int m_starlinesCount;
		[SerializeField]
		private int m_passCount;
		[SerializeField]
		private float m_sampleLength;
		[SerializeField]
		private float m_attenuation;
		[SerializeField]
		private float m_inclination;
		[SerializeField]
		private float m_rotation;
		[SerializeField]
		private StarLineData[] m_starLinesArr;
		[SerializeField]
		private float m_customIncrement;
		[SerializeField]
		private float m_longAttenuation;
	}
}
