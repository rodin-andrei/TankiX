using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class EffectRendererGraphicsComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Renderer Renderer
		{
			get;
			set;
		}

		public EffectRendererGraphicsComponent()
		{
		}

		public EffectRendererGraphicsComponent(Renderer renderer)
		{
			Renderer = renderer;
		}
	}
}
