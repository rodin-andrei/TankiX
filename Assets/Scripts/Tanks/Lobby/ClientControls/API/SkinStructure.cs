using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class SkinStructure : ScriptableObject
	{
		[SerializeField]
		private List<SkinStructureEntry> categories = new List<SkinStructureEntry>();

		[SerializeField]
		private List<SkinStructureEntry> sprites = new List<SkinStructureEntry>();

		public List<SkinStructureEntry> Categories
		{
			get
			{
				return categories;
			}
		}

		public List<SkinStructureEntry> Sprites
		{
			get
			{
				return sprites;
			}
		}
	}
}
