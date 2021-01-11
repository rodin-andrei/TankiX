using System.Collections.Generic;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class WindowsSpaceComponent : BehaviourComponent
	{
		[SerializeField]
		private List<Animator> animators;

		public List<Animator> Animators
		{
			get
			{
				return animators;
			}
		}
	}
}
