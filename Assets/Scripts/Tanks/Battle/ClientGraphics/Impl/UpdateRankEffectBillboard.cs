using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateRankEffectBillboard : MonoBehaviour
	{
		[SerializeField]
		private Camera camera;

		[SerializeField]
		private bool active;

		[SerializeField]
		private bool autoInitCamera = true;

		private GameObject myContainer;

		private Transform cameraTransform;

		private Transform containerTransform;

		private void Awake()
		{
			if (autoInitCamera)
			{
				camera = Camera.main;
				active = true;
			}
			Transform parent = base.transform.parent;
			cameraTransform = camera.transform;
			myContainer = new GameObject
			{
				name = "Billboard_" + base.gameObject.name
			};
			containerTransform = myContainer.transform;
			containerTransform.position = base.transform.position;
			base.transform.parent = myContainer.transform;
			containerTransform.parent = parent;
		}

		private void Update()
		{
			if (!(containerTransform == null) && !(cameraTransform == null) && active)
			{
				containerTransform.LookAt(containerTransform.position + cameraTransform.rotation * Vector3.back, cameraTransform.rotation * Vector3.up);
			}
		}
	}
}
