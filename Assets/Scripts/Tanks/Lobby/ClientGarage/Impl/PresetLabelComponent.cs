using Platform.Library.ClientUnityIntegration.API;
using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class PresetLabelComponent : BehaviourComponent
	{
		private TextMeshProUGUI text
		{
			get
			{
				return GetComponent<TextMeshProUGUI>();
			}
		}

		public string PresetName
		{
			get
			{
				return text.text;
			}
			set
			{
				text.text = value;
			}
		}
	}
}
