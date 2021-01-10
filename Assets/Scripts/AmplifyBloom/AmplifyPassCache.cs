using System;
using UnityEngine;

namespace AmplifyBloom
{
	[Serializable]
	public class AmplifyPassCache
	{
		[SerializeField]
		internal Vector4[] Offsets;
		[SerializeField]
		internal Vector4[] Weights;
	}
}
