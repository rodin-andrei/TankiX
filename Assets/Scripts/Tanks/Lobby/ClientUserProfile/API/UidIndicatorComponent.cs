using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientUserProfile.API
{
	public class UidIndicatorComponent : UIBehaviour
	{
		[Serializable]
		public class UserUidInited : UnityEvent
		{
		}

		[SerializeField]
		private Text uidText;
		[SerializeField]
		private TextMeshProUGUI uidTMPText;
		public UserUidInited OnUserUidInited;
	}
}
