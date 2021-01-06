using UnityEngine;
using TMPro;

namespace Tanks.Lobby.ClientControls.API
{
	public class DropDownListComponent : MonoBehaviour
	{
		[SerializeField]
		protected TextMeshProUGUI listTitle;
		[SerializeField]
		protected DefaultListDataProvider dataProvider;
		[SerializeField]
		private float maxHeight;
	}
}
