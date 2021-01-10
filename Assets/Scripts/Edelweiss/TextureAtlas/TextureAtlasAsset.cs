using UnityEngine;
using Edelweiss.DecalSystem;

namespace Edelweiss.TextureAtlas
{
	public class TextureAtlasAsset : ScriptableObject
	{
		public Material material;
		public UVChannelModificationEnum uvChannelModification;
		public UVRectangle[] uvRectangles;
		public UVRectangle[] uv2Rectangles;
	}
}
