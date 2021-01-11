using System;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	[Serializable]
	public class SkinSprite
	{
		[SerializeField]
		private string uid;

		[SerializeField]
		private Sprite sprite;

		public string Uid
		{
			get
			{
				return uid;
			}
		}

		public Sprite Sprite
		{
			get
			{
				return sprite;
			}
			set
			{
				sprite = value;
			}
		}
	}
}
