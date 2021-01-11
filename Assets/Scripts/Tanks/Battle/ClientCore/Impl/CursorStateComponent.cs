using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class CursorStateComponent : Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		private bool cursorVisible = true;

		private CursorLockMode cursorLockState;

		public CursorLockMode CursorLockState
		{
			get
			{
				return cursorLockState;
			}
			set
			{
				cursorLockState = value;
			}
		}

		public bool CursorVisible
		{
			get
			{
				return cursorVisible;
			}
			set
			{
				cursorVisible = value;
			}
		}
	}
}
