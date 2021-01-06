using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class InputAction : MonoBehaviour
	{
		[SerializeField]
		public InputActionContextId contextId;
		[SerializeField]
		public InputActionId actionId;
		public KeyCode[] keys;
		public MultiKeys[] multiKeys;
		public UnityInputAxes[] axes;
		public bool onlyPositiveAxes;
		public bool onlyNegativeAxes;
		public bool invertAxes;
	}
}
