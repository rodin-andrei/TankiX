using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class ImageListSkin : ImageSkin
	{
		[SerializeField]
		private List<string> uids;
		[SerializeField]
		private List<string> names;
		[SerializeField]
		private int selectedSpriteIndex;
	}
}
