using UnityEngine;

namespace UnityEngine.UI
{
	public class Gradient : BaseMeshEffect
	{
		public enum Type
		{
			Horizontal = 0,
			Vertical = 1,
		}

		public enum Blend
		{
			Override = 0,
			Add = 1,
			Multiply = 2,
		}

		public override void ModifyMesh(VertexHelper helper)
		{
		}

		[SerializeField]
		private Type _gradientType;
		[SerializeField]
		private Blend _blendMode;
		[SerializeField]
		private float _offset;
		[SerializeField]
		private Gradient _effectGradient;
	}
}
