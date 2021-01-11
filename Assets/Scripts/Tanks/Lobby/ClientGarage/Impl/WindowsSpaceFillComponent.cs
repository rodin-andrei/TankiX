using System.Collections.Generic;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class WindowsSpaceFillComponent : BehaviourComponent
	{
		[SerializeField]
		private List<Animator> animators = new List<Animator>();

		public List<Animator> Animators
		{
			get
			{
				return animators;
			}
		}
	}
}
