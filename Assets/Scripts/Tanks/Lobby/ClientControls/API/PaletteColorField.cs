using System;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	[Serializable]
	public class PaletteColorField
	{
		[SerializeField]
		private Palette palette;
		[SerializeField]
		private int uid;
	}
}
