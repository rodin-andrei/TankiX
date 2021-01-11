using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class Terrain
	{
		private readonly List<MeshCollider> meshColliders = new List<MeshCollider>();

		private readonly List<MeshRenderer> meshRenderers = new List<MeshRenderer>();

		private readonly Bounds bounds;

		public List<MeshCollider> MeshColliders
		{
			get
			{
				return meshColliders;
			}
		}

		public List<MeshRenderer> MeshRenderers
		{
			get
			{
				return meshRenderers;
			}
		}

		public Bounds Bounds
		{
			get
			{
				return bounds;
			}
		}

		public Terrain(List<GameObject> terrainObjects)
		{
			foreach (GameObject terrainObject in terrainObjects)
			{
				CollectMeshParts(terrainObject);
			}
			bounds = CalculateBounds(meshColliders);
		}

		private void CollectMeshParts(GameObject terrainObject)
		{
			MeshCollider[] componentsInChildren = terrainObject.GetComponentsInChildren<MeshCollider>();
			MeshCollider[] array = componentsInChildren;
			foreach (MeshCollider meshCollider in array)
			{
				if (meshCollider != null && meshCollider.enabled)
				{
					meshColliders.Add(meshCollider);
				}
			}
			MeshRenderer component = terrainObject.GetComponent<MeshRenderer>();
			if (component != null && component.enabled)
			{
				meshRenderers.Add(component);
			}
			Transform transform = terrainObject.transform;
			for (int j = 0; j < transform.childCount; j++)
			{
				CollectMeshParts(transform.GetChild(j).gameObject);
			}
		}

		public static Bounds CalculateBounds(List<MeshCollider> meshColliders)
		{
			if (meshColliders.Count == 0)
			{
				return default(Bounds);
			}
			Bounds result = meshColliders[0].bounds;
			for (int i = 1; i < meshColliders.Count; i++)
			{
				result.Encapsulate(meshColliders[i].bounds);
			}
			return result;
		}
	}
}
