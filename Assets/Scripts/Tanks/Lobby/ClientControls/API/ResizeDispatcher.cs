using UnityEngine;
using System.Collections.Generic;

namespace Tanks.Lobby.ClientControls.API
{
	public class ResizeDispatcher : MonoBehaviour
	{
		[SerializeField]
		private List<ResizeListener> listeners;
	}
}
