using UnityEngine;
using UnityEngine.Events;

namespace tanks.modules.lobby.ClientControls.API
{
	public class OnClickOutside : MonoBehaviour
	{
		[SerializeField]
		private UnityEvent onClick;
	}
}
