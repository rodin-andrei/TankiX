using UnityEngine.EventSystems;
using UnityEngine;

namespace CurvedUI
{
	public class CurvedUIPointerEventData : PointerEventData
	{
		public CurvedUIPointerEventData(EventSystem eventSystem) : base(default(EventSystem))
		{
		}

		public GameObject Controller;
		public Vector2 TouchPadAxis;
	}
}
