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

		public string MouseSensivity
		{
			set
			{
				mouseSensivity.text = value;
			}
		}

		public string InvertBackwardMovingControl
		{
			set
			{
				invertBackwardMovingControl.text = value;
			}
		}

		public string MouseControlAllowed
		{
			set
			{
				mouseControlAllowed.text = value;
			}
		}

		public string MouseVerticalInverted
		{
			set
			{
				mouseVerticalInverted.text = value;
			}
		}

		public string Keyboard
		{
			set
			{
				keyboardHeader.text = value;
			}
		}

		public string Tip
		{
			set
			{
				tip.text = value;
			}
		}

		public string FewActionsError
		{
			set
			{
				fewActionsError.text = value;
			}
		}

		public string Modules
		{
			set
			{
				modules.text = value;
			}
		}

		public virtual string TurretLeft
		{
			set
			{
				turretLeft.text = value;
			}
		}

		public virtual string TurretRight
		{
			set
			{
				turretRight.text = value;
			}
		}

		public virtual string CenterTurret
		{
			set
			{
				centerTurret.text = value;
			}
		}

		public virtual string Graffiti
		{
			set
			{
				graffiti.text = value;
			}
		}

		public virtual string Help
		{
			set
			{
				help.text = value;
			}
		}

		public virtual string ChangeHud
		{
			set
			{
				changeHud.text = value;
			}
		}

		public virtual string DropFlag
		{
			set
			{
				dropFlag.text = value;
			}
		}

		public virtual string CameraUp
		{
			set
			{
				cameraUp.text = value;
			}
		}

		public virtual string CameraDown
		{
			set
			{
				cameraDown.text = value;
			}
		}

		public virtual string ScoreBoard
		{
			set
			{
				scoreBoard.text = value;
			}
		}

		public virtual string SelfDestruction
		{
			set
			{
				selfDestruction.text = value;
			}
		}

		public virtual string Pause
		{
			set
			{
				pause.text = value;
			}
		}
	}
}
