using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class PaletteColor : MonoBehaviour
	{
		[SerializeField]
		private Palette palette;
		[SerializeField]
		private int uid;
		[SerializeField]
		private bool applyToChildren;
	}
}
