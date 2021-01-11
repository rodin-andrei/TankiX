using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class SpectatorCameraComponent : Component
	{
		public Dictionary<int, CameraSaveData> savedCameras = new Dictionary<int, CameraSaveData>();

		private bool cursorVisible = true;

		public bool SaveCameraModificatorKeyHasBeenPressed
		{
			get;
			set;
		}

		public int SequenceScreenshot
		{
			get;
			set;
		}

		public bool СursorVisible
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
