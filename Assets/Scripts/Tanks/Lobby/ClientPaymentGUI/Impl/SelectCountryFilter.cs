using UnityEngine;
using Tanks.Lobby.ClientControls.API;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientPaymentGUI.Impl
{
	public class SelectCountryFilter : MonoBehaviour
	{
		[SerializeField]
		private FilteredListDataProvider list;
		[SerializeField]
		private InputField inputField;
	}
}
