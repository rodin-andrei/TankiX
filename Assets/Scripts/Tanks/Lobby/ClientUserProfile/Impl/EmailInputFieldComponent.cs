using Tanks.Lobby.ClientControls.API;
using UnityEngine;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class EmailInputFieldComponent : LocalizedControl
	{
		[SerializeField]
		private bool existsIsValid;
		[SerializeField]
		private bool includeUnconfirmed;
	}
}
