using Platform.Library.ClientUnityIntegration.API;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class NotificationsContainerComponent : BehaviourComponent
	{
		[SerializeField]
		private List<GameObject> rows;
		[SerializeField]
		private GameObject fullSceenNotificationContainer;
		[SerializeField]
		private int columnsCount;
		public int openedCards;
		public int hidenCards;
		[SerializeField]
		private GameObject OpenAllCardsButton;
		[SerializeField]
		private GameObject CloseAllCardsButton;
		[SerializeField]
		private GameObject cardsCamera;
		[SerializeField]
		private GameObject outlineBlurCamera;
	}
}
