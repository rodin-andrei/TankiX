using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientNavigation.Impl
{
	public class TopPanelComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public GameObject backButton;

		public Image background;

		public Animator screenHeader;

		[SerializeField]
		private Text newHeaderText;

		[SerializeField]
		private Text currentHeaderText;

		private bool hasHeader;

		public string NewHeader
		{
			get
			{
				return newHeaderText.text;
			}
			set
			{
				newHeaderText.text = value.ToUpper();
			}
		}

		public string CurrentHeader
		{
			get
			{
				return currentHeaderText.text;
			}
			set
			{
				currentHeaderText.text = value.ToUpper();
			}
		}

		public bool HasHeader
		{
			get
			{
				return hasHeader && screenHeader.isInitialized;
			}
		}

		public void SetHeaderText(string headerText)
		{
			if (hasHeader)
			{
				NewHeader = headerText;
				if (!screenHeader.isInitialized || !screenHeader.GetCurrentAnimatorStateInfo(0).IsName("Default"))
				{
					CurrentHeader = headerText;
				}
			}
			else
			{
				SetHeaderTextImmediately(headerText);
				hasHeader = true;
			}
		}

		public void SetHeaderTextImmediately(string headerText)
		{
			NewHeader = headerText;
			CurrentHeader = headerText;
		}
	}
}
