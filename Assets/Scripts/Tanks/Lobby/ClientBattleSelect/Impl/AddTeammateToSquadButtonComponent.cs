using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class AddTeammateToSquadButtonComponent : BehaviourComponent
	{
		[SerializeField]
		private RectTransform popupPosition;

		public Vector3 PopupPosition
		{
			get
			{
				return popupPosition.position;
			}
		}
	}
}
