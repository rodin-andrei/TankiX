using System;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	[Serializable]
	public class ColorData
	{
		[SerializeField]
		public Color color = Color.white;

		[SerializeField]
		public Color hardlightColor = Color.green;

		[SerializeField]
		public Material material;

		[SerializeField]
		public bool defaultColor;

		public Color Color
		{
			get
			{
				return color;
			}
			set
			{
				color = value;
			}
		}

		public Color HardlightColor
		{
			get
			{
				return hardlightColor;
			}
			set
			{
				hardlightColor = value;
			}
		}

		public Material Material
		{
			get
			{
				return material;
			}
			set
			{
				material = value;
			}
		}

		public bool DefaultColor
		{
			get
			{
				return defaultColor;
			}
			set
			{
				defaultColor = value;
			}
		}
	}
}
