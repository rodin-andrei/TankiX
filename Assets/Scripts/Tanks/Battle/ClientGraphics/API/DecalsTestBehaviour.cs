using UnityEngine;
using UnityEngine.Rendering;

namespace Tanks.Battle.ClientGraphics.API
{
	public class DecalsTestBehaviour : MonoBehaviour
	{
		[SerializeField]
		private Material decalMaterial;

		[SerializeField]
		private float projectDistantion = 100f;

		[SerializeField]
		private float projectSize = 1f;

		[SerializeField]
		private int hTilesCount = 1;

		[SerializeField]
		private int vTilesCount = 1;

		[SerializeField]
		private float mouseWheelSenetivity = 0.1f;

		[SerializeField]
		private int[] surfaceAtlasPositions = new int[5];

		[SerializeField]
		private bool updateEveryFrame = true;

		private Mesh decalMesh;

		private MeshFilter meshFilter;

		private Renderer renderer;

		private DecalMeshBuilder meshBuilder = new DecalMeshBuilder();

		private int counter;

		public void Start()
		{
			CreateMesh();
		}

		public void Update()
		{
			if (Input.GetMouseButtonUp(0))
			{
				CreateMesh();
				UpdateDecalMesh();
			}
			if (!updateEveryFrame)
			{
				UpdateDecalMesh();
			}
		}

		private void UpdateDecalMesh()
		{
			Camera main = Camera.main;
			DecalProjection decalProjection = new DecalProjection();
			decalProjection.Ray = main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
			decalProjection.Distantion = projectDistantion;
			decalProjection.HalfSize = projectSize;
			decalProjection.AtlasHTilesCount = hTilesCount;
			decalProjection.AtlasVTilesCount = vTilesCount;
			decalProjection.SurfaceAtlasPositions = surfaceAtlasPositions;
			DecalProjection decalProjection2 = decalProjection;
			meshBuilder.Build(decalProjection2, ref decalMesh);
		}

		private void CreateMesh()
		{
			GameObject gameObject = new GameObject("Decal Mesh");
			decalMesh = new Mesh();
			decalMesh.MarkDynamic();
			meshFilter = gameObject.AddComponent<MeshFilter>();
			meshFilter.mesh = decalMesh;
			renderer = gameObject.AddComponent<MeshRenderer>();
			renderer.material = new Material(decalMaterial);
			renderer.material.renderQueue = decalMaterial.renderQueue + ++counter;
			renderer.shadowCastingMode = ShadowCastingMode.Off;
			renderer.receiveShadows = true;
			renderer.useLightProbes = true;
			gameObject.transform.position = Vector3.zero;
			gameObject.transform.rotation = Quaternion.identity;
		}
	}
}
