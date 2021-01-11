using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientFriends.Impl;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tanks.Lobby.ClientFriends.API
{
	public class InviteFriendsPopupComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
	{
		[SerializeField]
		private UITableViewCell inviteToLobbyCell;

		[SerializeField]
		private UITableViewCell inviteToSquadCell;

		[SerializeField]
		private InviteMode currentInviteMode;

		[SerializeField]
		private InviteFriendsUIComponent inviteFriends;

		private bool pointerIn;

		[SerializeField]
		private TextMeshProUGUI inviteHeader;

		[SerializeField]
		private LocalizedField inviteToLobbyLocalizationFiled;

		[SerializeField]
		private LocalizedField inviteToSquadLocalizationFiled;

		public InviteMode InviteMode
		{
			set
			{
				switch (value)
				{
				case InviteMode.Lobby:
					inviteFriends.tableView.CellPrefab = inviteToLobbyCell;
					break;
				case InviteMode.Squad:
					inviteFriends.tableView.CellPrefab = inviteToSquadCell;
					break;
				}
			}
		}

		public void ShowInvite(Vector3 popupPosition, Vector2 pivot, InviteMode inviteMode)
		{
			InviteMode = inviteMode;
			inviteHeader.text = ((inviteMode != 0) ? inviteToSquadLocalizationFiled.Value : inviteToLobbyLocalizationFiled.Value);
			GetComponent<RectTransform>().pivot = pivot;
			GetComponent<RectTransform>().position = popupPosition;
			inviteFriends.GetComponent<RectTransform>().pivot = pivot;
			inviteFriends.GetComponent<RectTransform>().position = popupPosition;
			inviteFriends.Show();
		}

		private void Update()
		{
			if (!pointerIn && (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
			{
				Close();
			}
		}

		public void Close()
		{
			inviteFriends.Hide();
		}

		private new void OnDisable()
		{
			pointerIn = false;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			pointerIn = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			pointerIn = false;
		}
	}
}
