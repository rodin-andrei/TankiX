using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Tanks.Battle.ClientGraphics.API
{
	public abstract class DynamicDecalManager
	{
		private const int DECAL_COUNT_LIMIT = 500;

		protected const float DECAL_FADE_TIME = 2f;

		private const float SHADER_TIME_DIMENSION = 0.0001f;

		protected LinkedList<DecalEntry> decalsQueue;

		private int maxDecalCount;

		protected int decalsCount;

		protected float decalLifeTimeKoeff;

		private GameObject root;

		protected abstract DecalEntryType DecalType
		{
			get;
		}

		protected abstract string DecalMeshObjectName
		{
			get;
		}

		public DynamicDecalManager(GameObject root, int maxDecalCount, float decalLifeTimeKoeff, LinkedList<DecalEntry> decalsQueue)
		{
			this.root = root;
			this.maxDecalCount = Math.Min(500, maxDecalCount);
			this.decalLifeTimeKoeff = decalLifeTimeKoeff;
			this.decalsQueue = decalsQueue;
		}

		protected void TrimQueue()
		{
			if (decalsCount <= maxDecalCount)
			{
				return;
			}
			DecalEntryType decalType = DecalType;
			LinkedListNode<DecalEntry> linkedListNode = decalsQueue.First;
			int num = 0;
			while (linkedListNode != null)
			{
				LinkedListNode<DecalEntry> next = linkedListNode.Next;
				if (linkedListNode.Value.type == decalType)
				{
					UnityEngine.Object.Destroy(linkedListNode.Value.gameObject);
					decalsQueue.Remove(linkedListNode);
					decalsCount--;
					break;
				}
				linkedListNode = next;
			}
		}

		protected DecalEntry CreateDecalEntry(Mesh decalMesh, Material material, float timeToDestroy)
		{
			GameObject gameObject = new GameObject(DecalMeshObjectName);
			MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
			meshFilter.mesh = decalMesh;
			MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
			meshRenderer.material = new Material(material);
			meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
			meshRenderer.receiveShadows = true;
			meshRenderer.useLightProbes = false;
			gameObject.transform.parent = root.transform;
			gameObject.transform.position = Vector3.zero;
			gameObject.transform.rotation = Quaternion.identity;
			DecalEntry result = default(DecalEntry);
			result.gameObject = gameObject;
			result.material = meshRenderer.material;
			result.timeToDestroy = timeToDestroy;
			return result;
		}

		protected void SetMeshColorAndLifeTime(Mesh mesh, Color color, float lifeTime)
		{
			color.a = (Time.timeSinceLevelLoad + lifeTime) * 0.0001f;
			int vertexCount = mesh.vertexCount;
			Color[] array = new Color[mesh.vertexCount];
			for (int i = 0; i < vertexCount; i++)
			{
				array[i] = color;
			}
			mesh.colors = array;
		}
	}
}
