using System;
using UnityEngine;

namespace AmplifyBloom
{
	[Serializable]
	public class AmplifyGlareCache
	{
		[SerializeField]
		internal AmplifyStarlineCache[] Starlines;
		[SerializeField]
		internal Vector4 AverageWeight;
		[SerializeField]
		internal int TotalRT;
		[SerializeField]
		internal GlareDefData GlareDef;
		[SerializeField]
		internal StarDefData StarDef;
		[SerializeField]
		internal int CurrentPassCount;
	}
}
