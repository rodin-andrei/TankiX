using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.Impl
{
	[RequireComponent(typeof(CanvasGroup))]
	public class NameplateComponent : BehaviourComponent
	{
		private const float TEAM_NAMEPLATE_Y_OFFSET = 1.2f;

		public float yOffset = 2f;

		public float appearanceSpeed = 0.2f;

		public float disappearanceSpeed = 0.2f;

		public bool alwaysVisible;

		[SerializeField]
		private EntityBehaviour redHealthBarPrefab;

		[SerializeField]
		private EntityBehaviour blueHealthBarPrefab;

		[SerializeField]
		private Graphic colorProvider;

		private CanvasGroup canvasGroup;

		private Camera _cachedCamera;

		public Color Color
		{
			get
			{
				return colorProvider.color;
			}
			set
			{
				colorProvider.color = value;
			}
		}

		private CanvasGroup CanvasGroup
		{
			get
			{
				if (canvasGroup == null)
				{
					canvasGroup = GetComponent<CanvasGroup>();
				}
				return canvasGroup;
			}
		}

		public float Alpha
		{
			get
			{
				return CanvasGroup.alpha;
			}
			set
			{
				CanvasGroup.alpha = value;
			}
		}

		public Camera CachedCamera
		{
			get
			{
				if (!_cachedCamera)
				{
					_cachedCamera = Camera.main;
				}
				return _cachedCamera;
			}
		}

		public void AddRedHealthBar(Entity entity)
		{
			AddHealthBar(redHealthBarPrefab).BuildEntity(entity);
		}

		public void AddBlueHealthBar(Entity entity)
		{
			AddHealthBar(blueHealthBarPrefab).BuildEntity(entity);
		}

		private EntityBehaviour AddHealthBar(EntityBehaviour prefab)
		{
			EntityBehaviour entityBehaviour = Object.Instantiate(prefab);
			entityBehaviour.transform.SetParent(base.transform, false);
			yOffset = 1.2f;
			return entityBehaviour;
		}
	}
}
