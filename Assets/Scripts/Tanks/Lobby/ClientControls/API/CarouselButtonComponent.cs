using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public abstract class CarouselButtonComponent : BehaviourComponent
	{
		[SerializeField]
		private EntityBehaviour entityBehaviour;

		private long carouselEntity;

		public long CarouselEntity
		{
			get
			{
				return carouselEntity;
			}
		}

		public void Build(Entity btnEntity, long carouselEntity)
		{
			this.carouselEntity = carouselEntity;
			entityBehaviour.BuildEntity(btnEntity);
		}

		public void DestroyButton()
		{
			entityBehaviour.DestroyEntity();
		}
	}
}
