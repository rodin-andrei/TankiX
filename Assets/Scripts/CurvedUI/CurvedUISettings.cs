using UnityEngine;

namespace CurvedUI
{
	public class CurvedUISettings : MonoBehaviour
	{
		public enum CurvedUIShape
		{
			CYLINDER = 0,
			RING = 1,
			SPHERE = 2,
			CYLINDER_VERTICAL = 3,
		}

		[SerializeField]
		private CurvedUIShape shape;
		[SerializeField]
		private float quality;
		[SerializeField]
		private bool interactable;
		[SerializeField]
		private bool blocksRaycasts;
		[SerializeField]
		private bool raycastMyLayerOnly;
		[SerializeField]
		private bool forceUseBoxCollider;
		[SerializeField]
		private int angle;
		[SerializeField]
		private bool preserveAspect;
		[SerializeField]
		private int vertAngle;
		[SerializeField]
		private float ringFill;
		[SerializeField]
		private int ringExternalDiamater;
		[SerializeField]
		private bool ringFlipVertical;
	}
}
