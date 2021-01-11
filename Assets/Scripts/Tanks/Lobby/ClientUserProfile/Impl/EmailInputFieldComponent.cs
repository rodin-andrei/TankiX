using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	[RequireComponent(typeof(InputFieldComponent))]
	public class EmailInputFieldComponent : LocalizedControl, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		[Tooltip("Если true - переводит инпут в валидное состояние если email существует, не валидное - если не существует")]
		private bool existsIsValid;

		[SerializeField]
		[Tooltip("Если true - дополнительно проверяет в неподтверждённых")]
		private bool includeUnconfirmed;

		public bool ExistsIsValid
		{
			get
			{
				return existsIsValid;
			}
		}

		public bool IncludeUnconfirmed
		{
			get
			{
				return includeUnconfirmed;
			}
		}

		public string Hint
		{
			set
			{
				GetComponent<InputFieldComponent>().Hint = value;
			}
		}

		public string EmailIsInvalid
		{
			get;
			set;
		}

		public string EmailIsOccupied
		{
			get;
			set;
		}

		public string EmailIsNotConfirmed
		{
			get;
			set;
		}
	}
}
