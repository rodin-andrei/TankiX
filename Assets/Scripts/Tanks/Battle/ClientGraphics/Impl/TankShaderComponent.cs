using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TankShaderComponent : MonoBehaviour
	{
		[SerializeField]
		private Shader opaqueShader;
		[SerializeField]
		private Shader transparentShader;
	}
}
