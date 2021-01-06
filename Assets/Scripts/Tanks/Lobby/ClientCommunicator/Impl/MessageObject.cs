using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using TMPro;

namespace Tanks.Lobby.ClientCommunicator.Impl
{
	public class MessageObject : ECSBehaviour
	{
		[SerializeField]
		private bool first;
		[SerializeField]
		private RectTransform back;
		[SerializeField]
		private ImageSkin userAvatarImageSkin;
		[SerializeField]
		private GameObject userAvatar;
		[SerializeField]
		private GameObject systemAvatar;
		[SerializeField]
		private bool self;
		[SerializeField]
		private TMP_Text nick;
		[SerializeField]
		private TMP_Text text;
		[SerializeField]
		private TMP_Text time;
		[SerializeField]
		private GameObject _tooltipPrefab;
	}
}
