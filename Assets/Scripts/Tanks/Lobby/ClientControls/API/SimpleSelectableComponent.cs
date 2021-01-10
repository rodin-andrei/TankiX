using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class SimpleSelectableComponent : ECSBehaviour
	{
		[SerializeField]
		private GameObject selection;
	}
}
