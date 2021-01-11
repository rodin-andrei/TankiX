using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using Tanks.Battle.ClientCore.API;
using Tanks.Lobby.ClientControls.API;
using TMPro;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	[SerialVersionUID(1504088159533L)]
	public class DisbalanceInfoComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
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

		public Timer Timer
		{
			get
			{
				return timer;
			}
		}

		private void OnDisable()
		{
			animator.SetTrigger("Enable");
		}

		public void ShowDisbalanceInfo(bool winner, BattleMode battleMode)
		{
			string text = "www";
			switch (battleMode)
			{
			case BattleMode.CTF:
				text = ((!winner) ? looseCtfUid.Value : winCtfUid.Value);
				break;
			case BattleMode.TDM:
				text = ((!winner) ? looseTdmUid.Value : winTdmUid.Value);
				break;
			}
			tmp.text = text;
			animator.SetTrigger("Show");
			SendMessage("RefreshCurve");
		}

		public void HideDisbalanceInfo()
		{
			animator.SetTrigger("Hide");
		}
	}
}
