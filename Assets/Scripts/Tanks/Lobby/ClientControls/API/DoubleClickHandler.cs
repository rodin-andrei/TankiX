using Platform.Library.ClientUnityIntegration.API;
using System;
using UnityEngine.Events;

namespace Tanks.Lobby.ClientControls.API
{
	public class DoubleClickHandler : ECSBehaviour
	{
		[Serializable]
		public class FirstClickEvent : UnityEvent
		{
		}

		public FirstClickEvent FirstClick;
	}
}
