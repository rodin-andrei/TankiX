using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class KeyboardSettingsInputComponent : MonoBehaviour
	{
		[SerializeField]
		public InputActionContainer[] inputActions;
		[SerializeField]
		private GameObject selectionBorder;
		public int id;
	}
}
