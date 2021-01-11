using Platform.Kernel.ECS.ClientEntitySystem.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientCommunicator.Impl
{
	public class ChatMessageUIComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private TextMeshProUGUI firstPartText;

		[SerializeField]
		private TextMeshProUGUI secondPartText;

		public bool showed;

		public string FirstPartText
		{
			get
			{
				return firstPartText.text;
			}
			set
			{
				firstPartText.text = value;
				Canvas.ForceUpdateCanvases();
				firstPartText.GetComponent<LayoutElement>().minWidth = firstPartText.rectTransform.rect.width;
			}
		}

		public Color FirstPartTextColor
		{
			set
			{
				firstPartText.color = value;
			}
		}

		public string SecondPartText
		{
			get
			{
				return secondPartText.text;
			}
			set
			{
				secondPartText.text = value;
			}
		}

		public Color SecondPartTextColor
		{
			set
			{
				secondPartText.color = value;
			}
		}
	}
}
