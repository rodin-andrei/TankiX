using UnityEngine;
using System;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class LineRendererEffectBehaviour : MonoBehaviour
	{
		[Serializable]
		private class LineRendererEffect
		{
			public LineRenderer lineRenderer;
			public AnimationCurve width;
			public AnimationCurve widthEnd;
			public Gradient color;
			public Gradient colorEnd;
			public float fragmentLength;
			public AnimationCurve textureOffset;
			public bool adjustTextureScale;
		}

		[SerializeField]
		private LineRendererEffect[] effects;
		public float duration;
		public bool invertAlpha;
	}
}
