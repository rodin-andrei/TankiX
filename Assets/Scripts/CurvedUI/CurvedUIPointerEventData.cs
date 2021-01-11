using UnityEngine;
using UnityEngine.EventSystems;

namespace CurvedUI
{
	public class CurvedUIPointerEventData : PointerEventData
	{
		public enum ControllerType
		{
			NONE = -1,
			VIVE
		}

		public GameObject Controller;

		public Vector2 TouchPadAxis = Vector2.zero;

		public CurvedUIPointerEventData(EventSystem eventSystem)
			: base(eventSystem)
		{
		}
	}
}
