using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class StarterPackElementComponent : MonoBehaviour
	{
		public TextMeshProUGUI title;
		public TextMeshProUGUI count;
		public ImageSkin previewSkin;
		public ImageListSkin RarityFrame;
		public Image RarityMask;
	}
}
