using System;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	[Serializable]
	public class SkinStructureEntry
	{
		[SerializeField]
		private string name;
		[SerializeField]
		private string uid;
		[SerializeField]
		private string parentUid;
	}
}
