using UnityEngine.EventSystems;
using UnityEngine;
using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class PresetNameEditorComponent : UIBehaviour
	{
		[SerializeField]
		private MainScreenComponent mainScreen;
		[SerializeField]
		private EntityBehaviour entityBehaviour;
		[SerializeField]
		private TMP_InputField inputField;
		[SerializeField]
		private Button editButton;
	}
}
