using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class CustomizationUIComponent : BehaviourComponent
	{
		[SerializeField]
		private VisualUI visualUI;
		[SerializeField]
		private ModulesScreenUIComponent modulesScreenUI;
		[SerializeField]
		private GarageSelectorUI garageSelectorUI;
	}
}
