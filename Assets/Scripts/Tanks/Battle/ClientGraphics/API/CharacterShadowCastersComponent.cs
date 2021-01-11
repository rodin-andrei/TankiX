using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class CharacterShadowCastersComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		private Transform[] casters;

		private List<Renderer> renderers;

		private bool hasBounds;

		public Transform[] Casters
		{
			get
			{
				return casters;
			}
			set
			{
				casters = value;
				renderers = new List<Renderer>();
				Transform[] array = casters;
				foreach (Transform element in array)
				{
					CollectRendereres(element, renderers);
				}
				hasBounds = renderers.Count > 0;
			}
		}

		public List<Renderer> Renderers
		{
			get
			{
				return renderers;
			}
		}

		public bool HasBounds
		{
			get
			{
				return hasBounds;
			}
		}

		public Bounds BoundsInWorldSpace
		{
			get
			{
				Bounds bounds = renderers[0].bounds;
				for (int i = 1; i < renderers.Count; i++)
				{
					bounds.Encapsulate(renderers[i].bounds);
				}
				return bounds;
			}
		}

		private void CollectRendereres(Transform element, List<Renderer> renderers)
		{
			bool includeInactive = true;
			Renderer[] componentsInChildren = element.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive);
			Renderer[] componentsInChildren2 = element.GetComponentsInChildren<MeshRenderer>(includeInactive);
			renderers.AddRange(componentsInChildren);
			renderers.AddRange(componentsInChildren2);
		}
	}
}
