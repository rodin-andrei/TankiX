using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	[RequireComponent(typeof(LineRenderer))]
	public class WeaponStreamTracerBehaviour : MonoBehaviour
	{
		[SerializeField]
		private float speed = 10f;

		[SerializeField]
		private float fragmentLength = 30f;

		private float textureOffset;

		private LineRenderer lineRenderer;

		public Vector3 TargetPosition
		{
			get;
			set;
		}

		public float Speed
		{
			get
			{
				return speed;
			}
			set
			{
				speed = value;
			}
		}

		public float FragmentLength
		{
			get
			{
				return fragmentLength;
			}
			set
			{
				fragmentLength = value;
			}
		}

		private void Awake()
		{
			lineRenderer = GetComponent<LineRenderer>();
			lineRenderer.sharedMaterial = Object.Instantiate(lineRenderer.material);
		}

		private void Update()
		{
			lineRenderer.SetPosition(1, TargetPosition);
			float magnitude = TargetPosition.magnitude;
			Vector2 mainTextureScale = lineRenderer.sharedMaterial.mainTextureScale;
			mainTextureScale.x = magnitude / fragmentLength;
			lineRenderer.sharedMaterial.mainTextureScale = mainTextureScale;
			Vector2 mainTextureOffset = lineRenderer.sharedMaterial.mainTextureOffset;
			mainTextureOffset.x = (mainTextureOffset.x + speed * Time.deltaTime) % 1f;
			lineRenderer.sharedMaterial.mainTextureOffset = mainTextureOffset;
		}
	}
}
