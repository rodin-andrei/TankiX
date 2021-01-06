using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class OutlineRender : MonoBehaviour
	{
		[SerializeField]
		private Shader outlineFinal;
		public float Intensity;
		[SerializeField]
		private Camera helperCamera;
	}
}
