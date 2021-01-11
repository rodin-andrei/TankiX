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

		public Color Color
		{
			get
			{
				return Apply(Color.white);
			}
		}

		public Color Apply(Color color)
		{
			return palette.Apply(uid, color);
		}

		public static implicit operator Color(PaletteColorField field)
		{
			return field.Apply(Color.white);
		}
	}
}
