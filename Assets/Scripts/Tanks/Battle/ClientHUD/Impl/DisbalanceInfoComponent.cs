using UnityEngine;
using TMPro;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class DisbalanceInfoComponent : MonoBehaviour
	{
		[SerializeField]
		private Timer timer;
		[SerializeField]
		private Animator animator;
		[SerializeField]
		private TextMeshProUGUI tmp;
		[SerializeField]
		private LocalizedField winCtfUid;
		[SerializeField]
		private LocalizedField looseCtfUid;
		[SerializeField]
		private LocalizedField winTdmUid;
		[SerializeField]
		private LocalizedField looseTdmUid;
	}
}
