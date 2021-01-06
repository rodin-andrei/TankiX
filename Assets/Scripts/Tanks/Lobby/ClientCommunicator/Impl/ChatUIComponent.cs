using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Lobby.ClientCommunicator.Impl
{
	public class ChatUIComponent : MonoBehaviour
	{
		[SerializeField]
		private GameObject inputPanel;
		[SerializeField]
		private Image bottomLineImage;
		[SerializeField]
		private TextMeshProUGUI inputHintText;
		[SerializeField]
		private Color commonNicknameColor;
		[SerializeField]
		private Color commonTextColor;
		[SerializeField]
		private Color redTeamNicknameColor;
		[SerializeField]
		private Color redTeamTextColor;
		[SerializeField]
		private Color blueTeamNicknameColor;
		[SerializeField]
		private Color blueTeamTextColor;
		[SerializeField]
		private PaletteColorField systemMessageColor;
		[SerializeField]
		private GameObject messagesContainer;
		[SerializeField]
		private LayoutElement scrollViewLayoutElement;
		[SerializeField]
		private RectTransform scrollViewRectTransform;
		[SerializeField]
		private RectTransform inputFieldRectTransform;
		[SerializeField]
		private GameObject scrollBarHandle;
		[SerializeField]
		private int maxVisibleMessagesInActiveState;
		[SerializeField]
		private int maxVisibleMessagesInPassiveState;
	}
}
