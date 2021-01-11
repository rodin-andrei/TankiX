using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class Skin : ScriptableObject, ISerializationCallbackReceiver
	{
		[SerializeField]
		private string structureGuid;

		[SerializeField]
		private List<SkinSprite> sprites = new List<SkinSprite>();

		private Dictionary<string, SkinSprite> spritesMap = new Dictionary<string, SkinSprite>();

		public Sprite GetSprite(string uid)
		{
			if (!spritesMap.ContainsKey(uid))
			{
				return null;
			}
			return spritesMap[uid].Sprite;
		}

		public void OnBeforeSerialize()
		{
			sprites = new List<SkinSprite>();
			foreach (SkinSprite value in spritesMap.Values)
			{
				if (value.Sprite != null)
				{
					sprites.Add(value);
				}
			}
		}

		public void OnAfterDeserialize()
		{
			spritesMap = new Dictionary<string, SkinSprite>();
			foreach (SkinSprite sprite in sprites)
			{
				if (!string.IsNullOrEmpty(sprite.Uid))
				{
					spritesMap.Add(sprite.Uid, sprite);
				}
			}
		}
	}
}
