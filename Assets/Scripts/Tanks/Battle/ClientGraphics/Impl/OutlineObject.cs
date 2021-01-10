using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class OutlineObject : MonoBehaviour
	{
		[SerializeField]
		private Color glowColor;
		public float saturation;
		public float LerpFactor;
		public bool Enable;
	}
}
