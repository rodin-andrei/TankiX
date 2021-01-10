using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientNavigation.Impl
{
	public class TopPanelComponent : MonoBehaviour
	{
		public GameObject backButton;
		public Image background;
		public Animator screenHeader;
		[SerializeField]
		private Text newHeaderText;
		[SerializeField]
		private Text currentHeaderText;
	}
}
