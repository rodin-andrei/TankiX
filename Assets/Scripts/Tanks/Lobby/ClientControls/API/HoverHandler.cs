using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class HoverHandler : MonoBehaviour
	{
		private Camera camera;

		private bool _pointerIn;

		protected virtual bool pointerIn
		{
			get
			{
				return _pointerIn;
			}
			set
			{
				_pointerIn = value;
			}
		}

		private void OnEnable()
		{
			camera = GetComponentInParent<Canvas>().worldCamera;
		}

		private void Update()
		{
			bool flag = false;
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit[] array = Physics.RaycastAll(ray, 100f);
			RaycastHit[] array2 = array;
			foreach (RaycastHit raycastHit in array2)
			{
				if (raycastHit.collider.gameObject == base.gameObject)
				{
					flag = true;
					break;
				}
			}
			if (flag && !pointerIn)
			{
				pointerIn = true;
			}
			else if (!flag && pointerIn)
			{
				pointerIn = false;
			}
		}
	}
}
