using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[SerialVersionUID(635824352362785226L)]
	public class CharacterShadowComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public float offset;

		public float attenuation = 5f;

		public float backFadeRange = 1f;

		public Color color = new Color(0f, 0f, 0f, 0.5f);
	}
}
