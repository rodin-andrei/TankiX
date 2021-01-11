using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class WithHeaderTooltipContent : MonoBehaviour, ITooltipContent
	{
		[SerializeField]
		private TextMeshProUGUI header;

		[SerializeField]
		private TextMeshProUGUI text;

		public void Init(object data)
		{
			string[] array = data as string[];
			header.text = array[0].Replace("\\n", "\n");
			text.text = array[1].Replace("\\n", "\n");
		}
	}
}
