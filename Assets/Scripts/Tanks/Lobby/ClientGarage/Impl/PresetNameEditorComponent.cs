using System.Collections;
using System.Linq;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class PresetNameEditorComponent : UIBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component, IPointerClickHandler, IEventSystemHandler
	{
		[SerializeField]
		private MainScreenComponent mainScreen;

		[SerializeField]
		private EntityBehaviour entityBehaviour;

		[SerializeField]
		private TMP_InputField inputField;

		[SerializeField]
		private Button editButton;

		private string nameBeforeEdit;

		[Inject]
		public static EngineService EngineService
		{
			get;
			set;
		}

		public string PresetName
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

		protected override void Awake()
		{
			editButton.onClick.AddListener(OnBeginEdit);
			inputField.onEndEdit.AddListener(OnEndEdit);
		}

		private void OnBeginEdit()
		{
			nameBeforeEdit = inputField.text;
			editButton.gameObject.SetActive(false);
			inputField.enabled = true;
			inputField.ActivateInputField();
		}

		public void DisableInput()
		{
			inputField.interactable = false;
		}

		public void EnableInput()
		{
			inputField.interactable = true;
		}

		private void OnEndEdit(string value)
		{
			editButton.gameObject.SetActive(true);
			StartCoroutine(LateEndEdit());
			if (string.IsNullOrEmpty(value) || value.Contains('\n') || value.All(char.IsWhiteSpace))
			{
				inputField.text = nameBeforeEdit;
			}
			else if (!nameBeforeEdit.Equals(value))
			{
				EngineService.Engine.ScheduleEvent<PresetNameChangedEvent>(entityBehaviour.Entity);
			}
		}

		private IEnumerator LateEndEdit()
		{
			yield return new WaitForEndOfFrame();
			inputField.enabled = false;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (eventData.clickCount > 1)
			{
				OnBeginEdit();
			}
		}
	}
}
