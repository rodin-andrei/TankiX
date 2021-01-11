using UnityEngine.EventSystems;

namespace CurvedUI
{
	public class CurvedUIEventSystem : EventSystem
	{
		public static CurvedUIEventSystem instance;

		protected override void Awake()
		{
			base.Awake();
			instance = this;
		}

		protected override void OnApplicationFocus(bool hasFocus)
		{
			base.OnApplicationFocus(true);
		}
	}
}
