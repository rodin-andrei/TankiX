using Platform.Kernel.OSGi.ClientCore.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class InputBehaviour : MonoBehaviour
	{
		[Inject]
		public static InputManager InputManager
		{
			get;
			set;
		}

		private void Update()
		{
			if (InputManager != null)
			{
				InputManager.Update();
			}
		}
	}
}
