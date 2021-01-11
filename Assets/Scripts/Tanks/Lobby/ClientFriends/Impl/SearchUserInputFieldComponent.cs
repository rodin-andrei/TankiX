using Platform.Library.ClientUnityIntegration.API;
using TMPro;

namespace Tanks.Lobby.ClientFriends.Impl
{
	public class SearchUserInputFieldComponent : BehaviourComponent
	{
		private TMP_InputField inputField;

		public string SearchString
		{
			get
			{
				return inputField.text;
			}
			set
			{
				inputField.text = value;
			}
		}

		public void Start()
		{
			inputField = GetComponent<TMP_InputField>();
		}
	}
}
