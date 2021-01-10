using UnityEngine;
using System.Collections.Generic;

namespace Tanks.Lobby.ClientControls.API
{
	public class SkinStructure : ScriptableObject
	{
		[SerializeField]
		private List<SkinStructureEntry> categories;
		[SerializeField]
		private List<SkinStructureEntry> sprites;
	}
}
