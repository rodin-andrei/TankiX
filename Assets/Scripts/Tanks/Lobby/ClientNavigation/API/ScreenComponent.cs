using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientNavigation.API
{
	public class ScreenComponent : MonoBehaviour
	{
		[SerializeField]
		private bool logInHistory;
		[SerializeField]
		private bool showHangar;
		[SerializeField]
		private bool rotateHangarCamera;
		[SerializeField]
		private bool showItemNotifications;
		[SerializeField]
		private List<string> visibleCommonScreenElements;
		[SerializeField]
		private bool showNotifications;
		[SerializeField]
		private Selectable defaultControl;
	}
}
