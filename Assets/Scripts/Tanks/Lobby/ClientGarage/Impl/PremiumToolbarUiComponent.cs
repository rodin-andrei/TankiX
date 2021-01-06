using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class PremiumToolbarUiComponent : BaseDialogComponent
	{
		public LocalizedField daysTextLocalizedField;
		public LocalizedField hoursTextLocalizedField;
		public TextMeshProUGUI activeText;
		public TextMeshProUGUI questText;
		public Animator animator;
		public bool visible;
	}
}
