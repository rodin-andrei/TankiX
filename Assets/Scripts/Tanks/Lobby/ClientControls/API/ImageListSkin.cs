using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Image))]
	public class ImageListSkin : ImageSkin
	{
		public class SpriteNotFoundException : ArgumentException
		{
			public SpriteNotFoundException(string name)
				: base("Sprite with name " + name + " not found")
			{
			}
		}

		[SerializeField]
		private List<string> uids = new List<string>();

		[SerializeField]
		private List<string> names = new List<string>();

		[SerializeField]
		private int selectedSpriteIndex;

		public int SelectedSpriteIndex
		{
			get
			{
				return selectedSpriteIndex;
			}
			set
			{
				selectedSpriteIndex = value;
				SelectSprite(names[selectedSpriteIndex]);
			}
		}

		public int Count
		{
			get
			{
				return uids.Count;
			}
		}

		protected override void OnEnable()
		{
			if (selectedSpriteIndex >= 0 && selectedSpriteIndex < uids.Count)
			{
				base.SpriteUid = uids[selectedSpriteIndex];
			}
			base.OnEnable();
		}

		public void SelectSprite(string name)
		{
			int num = names.IndexOf(name);
			if (num < 0)
			{
				throw new SpriteNotFoundException(name);
			}
			base.SpriteUid = uids[num];
			selectedSpriteIndex = num;
		}
	}
}
