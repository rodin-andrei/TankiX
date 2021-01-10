using System;
using UnityEngine;
using System.Collections.Generic;

namespace Tanks.Lobby.ClientControls.API
{
	[Serializable]
	public class Palette : ScriptableObject
	{
		[Serializable]
		public class ColorNode
		{
			[SerializeField]
			public Color color;
			[SerializeField]
			public string name;
			[SerializeField]
			public int uid;
			[SerializeField]
			public bool useAlpha;
			[SerializeField]
			public bool useColor;
		}

		[SerializeField]
		private List<Palette.ColorNode> nodes;
	}
}
