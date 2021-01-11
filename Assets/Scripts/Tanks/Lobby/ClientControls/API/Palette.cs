using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	[Serializable]
	public class Palette : ScriptableObject, ISerializationCallbackReceiver
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

			public override string ToString()
			{
				return string.Format("Color: {0}, Name: {1}, Uid: {2}, UseAlpha: {3}, UseColor: {4}", color, name, uid, useAlpha, useColor);
			}
		}

		[SerializeField]
		private List<ColorNode> nodes = new List<ColorNode>();

		private Dictionary<int, ColorNode> colorsMap = new Dictionary<int, ColorNode>();

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
			colorsMap.Clear();
			for (int i = 0; i < nodes.Count; i++)
			{
				colorsMap.Add(nodes[i].uid, nodes[i]);
			}
		}

		public Color Get(int uid)
		{
			Color color = new Color(float.NaN, float.NaN, float.NaN, float.NaN);
			return Apply(uid, color);
		}

		public Color Apply(int uid, Color color)
		{
			if (colorsMap.ContainsKey(uid))
			{
				ColorNode colorNode = colorsMap[uid];
				if (colorNode.useColor)
				{
					color.r = colorNode.color.r;
					color.g = colorNode.color.g;
					color.b = colorNode.color.b;
				}
				if (colorNode.useAlpha)
				{
					color.a = colorNode.color.a;
				}
			}
			return color;
		}
	}
}
