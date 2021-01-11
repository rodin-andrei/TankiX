using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class HealingGraphicEffectInputs
	{
		private Entity entity;

		private SkinnedMeshRenderer renderer;

		public SkinnedMeshRenderer Renderer
		{
			get
			{
				return renderer;
			}
		}

		public virtual float TilingX
		{
			get
			{
				return 4f;
			}
		}

		public Entity Entity
		{
			get
			{
				return entity;
			}
		}

		public HealingGraphicEffectInputs(Entity entity, SkinnedMeshRenderer renderer)
		{
			this.entity = entity;
			this.renderer = renderer;
		}
	}
}
