using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class Sprite3D : MonoBehaviour
	{
		private bool currentMaterialInstance;

		private static Mesh _planeMesh;

		protected Material assetMaterial;

		private Material instanceMaterial;

		public Material material;

		public float width = 100f;

		public float height = 100f;

		public float scale = 1f;

		public float originX = 0.5f;

		public float originY = 0.5f;

		public bool receiveShadows = true;

		public bool castShadows = true;

		public bool useOwnRotation;

		public bool useInstanceMaterial;

		public float offsetToCamera;

		public float minDistanceToCamera;

		private Camera _cachedCamera;

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

		protected void Awake()
		{
			assetMaterial = material;
			UpdateMaterial();
		}

		protected void Start()
		{
			_planeMesh = CreatePlane();
		}

		private void LateUpdate()
		{
			Draw();
		}

		public virtual void Draw()
		{
			if ((bool)CachedCamera)
			{
				Matrix4x4 matrix4x = default(Matrix4x4);
				matrix4x.m00 = 1f;
				matrix4x.m11 = 1f;
				matrix4x.m22 = 1f;
				matrix4x.m33 = 1f;
				matrix4x.m03 = 100f * (originX - 0.5f);
				matrix4x.m13 = 100f * (originY - 0.5f);
				Matrix4x4 matrix4x2 = matrix4x;
				Quaternion q = ((!useOwnRotation) ? Quaternion.LookRotation(-_cachedCamera.transform.forward) : base.gameObject.transform.rotation);
				Vector3 s = new Vector3(scale * width / 100f, scale * height / 100f, 1f);
				Matrix4x4 matrix4x3 = default(Matrix4x4);
				Vector3 vector = _cachedCamera.transform.position - base.transform.position;
				float b = Mathf.Max(0f, vector.magnitude - minDistanceToCamera);
				b = Mathf.Min(offsetToCamera, b);
				Vector3 pos = base.transform.position + vector.normalized * b;
				matrix4x3.SetTRS(pos, q, s);
				UpdateMaterialIfNeeded();
				Graphics.DrawMesh(_planeMesh, matrix4x3 * matrix4x2, material, base.gameObject.layer, null, 0, null, castShadows, receiveShadows);
			}
		}

		protected void OnDestroy()
		{
			if (useInstanceMaterial)
			{
				Object.Destroy(instanceMaterial);
			}
		}

		protected void UpdateMaterialIfNeeded()
		{
			if (currentMaterialInstance != useInstanceMaterial)
			{
				UpdateMaterial();
			}
		}

		protected void UpdateMaterial()
		{
			currentMaterialInstance = useInstanceMaterial;
			if (useInstanceMaterial)
			{
				instanceMaterial = Object.Instantiate(assetMaterial);
				material = instanceMaterial;
				return;
			}
			material = assetMaterial;
			if (instanceMaterial != null)
			{
				Object.Destroy(instanceMaterial);
			}
		}

		private static Mesh CreatePlane()
		{
			Mesh mesh = new Mesh();
			mesh.vertices = new Vector3[4]
			{
				new Vector3(50f, -50f, 0f),
				new Vector3(-50f, -50f, 0f),
				new Vector3(-50f, 50f, 0f),
				new Vector3(50f, 50f, 0f)
			};
			mesh.triangles = new int[6]
			{
				0,
				3,
				2,
				1,
				0,
				2
			};
			mesh.uv = new Vector2[4]
			{
				new Vector2(0f, 0f),
				new Vector2(1f, 0f),
				new Vector2(1f, 1f),
				new Vector2(0f, 1f)
			};
			Mesh mesh2 = mesh;
			mesh2.RecalculateNormals();
			mesh2.RecalculateBounds();
			return mesh2;
		}
	}
}
