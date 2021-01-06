using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class CraftedModuleWindow : UIBehaviour
	{
		[SerializeField]
		private Text okText;
		[SerializeField]
		private Text moduleNameText;
		[SerializeField]
		private Text moduleDescriptionText;
		[SerializeField]
		private Text additionalText;
		[SerializeField]
		private Button okButton;
		[SerializeField]
		private ImageSkin icon;
	}
}
