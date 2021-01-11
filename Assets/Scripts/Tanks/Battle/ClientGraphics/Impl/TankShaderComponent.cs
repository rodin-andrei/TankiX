using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class TankShaderComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private Shader opaqueShader;

		[SerializeField]
		private Shader transparentShader;

		public Shader OpaqueShader
		{
			get
			{
				return opaqueShader;
			}
		}

		public Shader TransparentShader
		{
			get
			{
				return transparentShader;
			}
		}
	}
}
