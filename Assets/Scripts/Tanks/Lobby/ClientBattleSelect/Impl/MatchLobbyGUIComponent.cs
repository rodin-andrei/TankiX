using System;
using System.Collections.Generic;
using System.Linq;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Lobby.ClientBattleSelect.API;
using Tanks.Lobby.ClientControls.API;
using Tanks.Lobby.ClientGarage.API;
using Tanks.Lobby.ClientGarage.Impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class MatchLobbyGUIComponent : EventMappingComponent
	{
		private bool teamBattleMode;

		[SerializeField]
		private GameObject teamList1Title;

		[SerializeField]
		private TextMeshProUGUI gameModeTitle;

		[SerializeField]
		private Image mapIcon;

		[SerializeField]
		private TextMeshProUGUI mapTitle;

		[SerializeField]
		private PresetsDropDownList presetsDropDownList;

		[SerializeField]
		private VisualItemsDropDownList hullSkinsDropDownList;

		[SerializeField]
		private VisualItemsDropDownList hullPaintDropDownList;

		[SerializeField]
		private VisualItemsDropDownList turretSkinsDropDownList;

		[SerializeField]
		private VisualItemsDropDownList turretPaintDropDownList;

		[SerializeField]
		private RectTransform blueTeamListWithHeader;

		[SerializeField]
		private RectTransform redTeamListWithHeader;

		[SerializeField]
		private TeamListGUIComponent blueTeamList;

		[SerializeField]
		private TeamListGUIComponent redTeamList;

		[SerializeField]
		private TextMeshProUGUI hullName;

		[SerializeField]
		private TextMeshProUGUI turretName;

		[SerializeField]
		private TextMeshProUGUI hullFeature;

		[SerializeField]
		private TextMeshProUGUI turretFeature;

		[SerializeField]
		private GameObject customGameElements;

		[SerializeField]
		private GameObject openBattleButton;

		[SerializeField]
		private GameObject inviteFriendsButton;

		[SerializeField]
		private GameObject editParamsButton;

		public TextMeshProUGUI paramTimeLimit;

		public TextMeshProUGUI paramFriendlyFire;

		public TextMeshProUGUI paramGravity;

		public TextMeshProUGUI enabledModules;

		public CreateBattleScreenComponent createBattleScreen;

		public GameObject chat;

		[Inject]
		public static GarageItemsRegistry GarageItemsRegistry
		{
			get;
			set;
		}

		public TankPartItem Hull
		{
			get;
			set;
		}

		public TankPartItem Turret
		{
			get;
			set;
		}

		public bool ShowSearchingText
		{
			set
			{
				blueTeamList.ShowSearchingText = value;
				redTeamList.ShowSearchingText = value;
			}
		}

		public string MapName
		{
			set
			{
				mapTitle.text = value;
			}
		}

		public string ModeName
		{
			set
			{
				gameModeTitle.text = value;
			}
		}

		public TeamColor UserTeamColor
		{
			set
			{
				blueTeamList.ShowJoinButton = value == TeamColor.RED;
				redTeamList.ShowJoinButton = value == TeamColor.BLUE;
			}
		}

		public void SetTeamBattleMode(bool teamBattleMode, int teamLimit, int userLimit)
		{
			this.teamBattleMode = teamBattleMode;
			redTeamListWithHeader.gameObject.SetActive(teamBattleMode);
			teamList1Title.SetActive(teamBattleMode);
			if (teamBattleMode)
			{
				blueTeamList.MaxCount = teamLimit;
				redTeamList.MaxCount = teamLimit;
			}
			else
			{
				blueTeamList.MaxCount = userLimit;
			}
		}

		public void SetMapPreview(Texture2D image)
		{
			mapIcon.color = Color.white;
			mapIcon.sprite = Sprite.Create(image, new Rect(Vector2.zero, new Vector2(image.width, image.height)), Vector2.one * 0.5f);
		}

		public void ShowCustomLobbyElements(bool show)
		{
			customGameElements.SetActive(show);
		}

		public void ShowEditParamsButton(bool show, bool interactable)
		{
			editParamsButton.SetActive(show);
			editParamsButton.GetComponent<Button>().interactable = interactable;
			openBattleButton.SetActive(show);
			inviteFriendsButton.SetActive(show);
		}

		public void ShowChat(bool show)
		{
			chat.SetActive(show);
		}

		private void OnEnable()
		{
			PresetsDropDownList obj = presetsDropDownList;
			obj.onDropDownListItemSelected = (OnDropDownListItemSelected)Delegate.Combine(obj.onDropDownListItemSelected, new OnDropDownListItemSelected(OnPresetSelected));
			SendEvent<MatchLobbyShowEvent>();
		}

		private void OnDisable()
		{
			PresetsDropDownList obj = presetsDropDownList;
			obj.onDropDownListItemSelected = (OnDropDownListItemSelected)Delegate.Remove(obj.onDropDownListItemSelected, new OnDropDownListItemSelected(OnPresetSelected));
		}

		public void InitPresetsDropDown(List<PresetItem> items)
		{
			presetsDropDownList.UpdateList(items);
		}

		public void InitHullDropDowns()
		{
			List<VisualItem> items = FilterItemsList(Hull.Skins.ToList());
			List<VisualItem> items2 = FilterItemsList(GarageItemsRegistry.Paints.ToList());
			hullSkinsDropDownList.UpdateList(items);
			hullPaintDropDownList.UpdateList(items2);
		}

		public void InitTurretDropDowns()
		{
			List<VisualItem> items = FilterItemsList(Turret.Skins.ToList());
			List<VisualItem> items2 = FilterItemsList(GarageItemsRegistry.Coatings.ToList());
			turretSkinsDropDownList.UpdateList(items);
			turretPaintDropDownList.UpdateList(items2);
		}

		private List<VisualItem> FilterItemsList(List<VisualItem> items)
		{
			List<VisualItem> list = new List<VisualItem>();
			foreach (VisualItem item in items)
			{
				if (item.UserItem != null && !item.WaitForBuy)
				{
					list.Add(item);
				}
			}
			return list;
		}

		public void AddUser(Entity userEntity, bool selfUser, bool customLobby)
		{
			TeamColor teamColor = userEntity.GetComponent<TeamColorComponent>().TeamColor;
			if (teamBattleMode)
			{
				if (teamColor == TeamColor.RED)
				{
					AddUserToSecondList(userEntity, selfUser, customLobby);
				}
				else
				{
					AddUserToFirstList(userEntity, selfUser, customLobby);
				}
			}
			else
			{
				AddUserToFirstList(userEntity, selfUser, customLobby);
			}
			UpdateInviteFriendsButton();
		}

		private void AddUserToFirstList(Entity userEntity, bool selfUser, bool customLobby)
		{
			redTeamList.RemoveUser(userEntity);
			blueTeamList.AddUser(userEntity, selfUser, customLobby);
		}

		private void AddUserToSecondList(Entity userEntity, bool selfUser, bool customLobby)
		{
			blueTeamList.RemoveUser(userEntity);
			redTeamList.AddUser(userEntity, selfUser, customLobby);
		}

		public void RemoveUser(Entity userEntity)
		{
			blueTeamList.RemoveUser(userEntity);
			redTeamList.RemoveUser(userEntity);
			UpdateInviteFriendsButton();
		}

		public void CleanUsersList()
		{
			blueTeamList.Clean();
			redTeamList.Clean();
			UpdateInviteFriendsButton();
		}

		private void UpdateInviteFriendsButton()
		{
			bool interactable = ((!teamBattleMode) ? blueTeamList.HasEmptyCells() : (blueTeamList.HasEmptyCells() || redTeamList.HasEmptyCells()));
			inviteFriendsButton.GetComponent<Button>().interactable = interactable;
		}

		protected override void Subscribe()
		{
		}

		public void OnPresetSelected(ListItem item)
		{
			PresetItem presetItem = (PresetItem)item.Data;
			Mount(presetItem.presetEntity);
		}

		public void OnVisualItemSelected(ListItem item)
		{
			VisualItem visualItem = (VisualItem)item.Data;
			Mount(visualItem.UserItem);
		}

		private void Mount(Entity target)
		{
			ECSBehaviour.EngineService.Engine.ScheduleEvent<MountPresetEvent>(target);
		}

		public void SetHullLabels()
		{
			hullName.text = Hull.Name;
			hullFeature.text = Hull.Feature;
		}

		public void SetTurretLabels()
		{
			turretName.text = Turret.Name;
			turretFeature.text = Turret.Feature;
		}
	}
}
