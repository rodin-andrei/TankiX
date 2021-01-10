using UnityEngine;
using UnityEngine.UI;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class AvatarButton : MonoBehaviour
	{
		[SerializeField]
		private Button button;
		[SerializeField]
		private ImageSkin icon;
		[SerializeField]
		private ImageListSkin frame;
		[SerializeField]
		private GameObject selectedFrame;
		[SerializeField]
		private GameObject equipedFrame;
		[SerializeField]
		private GameObject lockImage;
	}
}
