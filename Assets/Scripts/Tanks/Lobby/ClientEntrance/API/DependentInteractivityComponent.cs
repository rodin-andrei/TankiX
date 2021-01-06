using UnityEngine;
using System.Collections.Generic;

namespace Tanks.Lobby.ClientEntrance.API
{
	public class DependentInteractivityComponent : MonoBehaviour
	{
		public List<InteractivityPrerequisiteComponent> prerequisitesObjects;
	}
}
