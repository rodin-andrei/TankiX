using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class FullRegistrationDependenciesComponents : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private List<GameObject> dependecies;

		public List<GameObject> Dependecies
		{
			get
			{
				return dependecies;
			}
		}
	}
}
