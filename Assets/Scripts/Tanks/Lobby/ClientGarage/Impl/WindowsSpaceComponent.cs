using Platform.Library.ClientUnityIntegration.API;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class WindowsSpaceComponent : BehaviourComponent
	{
		[SerializeField]
		private List<Animator> animators;
	}
}
