using Tanks.Lobby.ClientNavigation.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientProfile.Impl
{
	public class KeyboardSettingsScreenTextComponent : LocalizedScreenComponent
	{
		[SerializeField]
		private TextMeshProUGUI mouseSensivity;
		[SerializeField]
		private TextMeshProUGUI invertBackwardMovingControl;
		[SerializeField]
		private TextMeshProUGUI mouseControlAllowed;
		[SerializeField]
		private TextMeshProUGUI mouseVerticalInverted;
		[SerializeField]
		private TextMeshProUGUI keyboardHeader;
		[SerializeField]
		private TextMeshProUGUI tip;
		[SerializeField]
		private TextMeshProUGUI fewActionsError;
		[SerializeField]
		private TextMeshProUGUI modules;
		[SerializeField]
		private Text turretLeft;
		[SerializeField]
		private Text turretRight;
		[SerializeField]
		private Text centerTurret;
		[SerializeField]
		private Text graffiti;
		[SerializeField]
		private Text help;
		[SerializeField]
		private Text changeHud;
		[SerializeField]
		private Text dropFlag;
		[SerializeField]
		private Text cameraUp;
		[SerializeField]
		private Text cameraDown;
		[SerializeField]
		private Text scoreBoard;
		[SerializeField]
		private Text selfDestruction;
		[SerializeField]
		private Text pause;
	}
}
