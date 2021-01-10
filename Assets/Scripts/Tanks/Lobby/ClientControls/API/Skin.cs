using UnityEngine;
using System.Collections.Generic;

namespace Tanks.Lobby.ClientControls.API
{
	public class Skin : ScriptableObject
	{
		[SerializeField]
		private string structureGuid;
		[SerializeField]
		private List<SkinSprite> sprites;
	}
}
