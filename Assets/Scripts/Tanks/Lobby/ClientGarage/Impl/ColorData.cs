using System;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	[Serializable]
	public class ColorData
	{
		[SerializeField]
		public Color color;
		[SerializeField]
		public Color hardlightColor;
		[SerializeField]
		public Material material;
		[SerializeField]
		public bool defaultColor;
	}
}
