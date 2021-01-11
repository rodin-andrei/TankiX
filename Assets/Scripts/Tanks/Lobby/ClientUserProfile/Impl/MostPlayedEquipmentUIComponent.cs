using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientUserProfile.Impl
{
	public class MostPlayedEquipmentUIComponent : BehaviourComponent
	{
		[SerializeField]
		private TextMeshProUGUI turretIcon;

		[SerializeField]
		private TextMeshProUGUI turretLabel;

		[SerializeField]
		private TextMeshProUGUI hullIcon;

		[SerializeField]
		private TextMeshProUGUI hullLabel;

		[SerializeField]
		private GameObject content;

		public void SwitchState(bool enabled)
		{
			content.SetActive(enabled);
			GetComponent<LayoutElement>().preferredWidth = (enabled ? 310 : 0);
		}

		public void SetMostPlayed(string turretUID, string turretName, string hullUID, string hullName)
		{
			SetIcon(turretIcon, turretUID);
			SetIcon(hullIcon, hullUID);
			turretLabel.text = turretName;
			hullLabel.text = hullName;
		}

		private void SetIcon(TextMeshProUGUI t, string s)
		{
			t.text = "<sprite name=\"" + s + "\">";
		}
	}
}
