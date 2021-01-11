using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class WorldSpaceScaleControllerProvider : MonoBehaviour, BaseElementScaleControllerProvider
	{
		[SerializeField]
		private BaseElementScaleController baseElementScaleController;

		public BaseElementScaleController BaseElementScaleController
		{
			get
			{
				return baseElementScaleController;
			}
		}
	}
}
