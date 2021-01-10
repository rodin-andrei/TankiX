using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientCommunicator.Impl
{
	public class ChatChannelUIComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject tab;
		[SerializeField]
		private Color selectedColor;
		[SerializeField]
		private Color unselectedColor;
		[SerializeField]
		private Image back;
		[SerializeField]
		private ImageSkin icon;
		[SerializeField]
		private new TMP_Text name;
		[SerializeField]
		private GameObject badge;
		[SerializeField]
		private TMP_Text counterText;
	}
}
