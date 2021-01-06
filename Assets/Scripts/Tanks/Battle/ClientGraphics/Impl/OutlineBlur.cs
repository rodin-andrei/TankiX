using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class OutlineBlur : MonoBehaviour
	{
		[SerializeField]
		private float texelSizeCoeff;
		[SerializeField]
		private Shader tmpOutline;
		[SerializeField]
		private Shader outlineBlur;
	}
}
