using UnityEngine;
using System.Collections.Generic;

namespace Tanks.Lobby.ClientNavigation.API
{
	public class CommonScreenElementsComponent : MonoBehaviour
	{
		[SerializeField]
		private List<string> names;
		[SerializeField]
		private List<Animator> items;
	}
}
