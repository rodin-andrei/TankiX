using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class Sprite3D : MonoBehaviour
	{
		public Material material;
		public float width;
		public float height;
		public float scale;
		public float originX;
		public float originY;
		public bool receiveShadows;
		public bool castShadows;
		public bool useOwnRotation;
		public bool useInstanceMaterial;
		public float offsetToCamera;
		public float minDistanceToCamera;
	}
}
