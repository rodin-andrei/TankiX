using Tanks.Lobby.ClientControls.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModalConfirmWindowComponent : LocalizedControl
	{
		[SerializeField]
		private string localizePath;
		[SerializeField]
		private Text confirmText;
		[SerializeField]
		private Text cancelText;
		[SerializeField]
		private Text headerText;
		[SerializeField]
		private Text mainText;
		[SerializeField]
		private Text additionalText;
		[SerializeField]
		private ImageSkin icon;
		[SerializeField]
		private Button confirmButton;
		[SerializeField]
		private Button cancelButton;
		[SerializeField]
		private RectTransform contentRoot;
	}
}
