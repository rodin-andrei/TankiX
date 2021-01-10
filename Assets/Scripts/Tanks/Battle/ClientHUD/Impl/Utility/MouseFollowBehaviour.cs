using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl.Utility
{
	public class MouseFollowBehaviour : MonoBehaviour
	{
		public RectTransform followObject;
		public Vector3 offset;
		public Camera uiCamera;
		public float smoothTime;
	}
}
