using UnityEngine;
using Tanks.Lobby.ClientControls.API;

namespace Tanks.Battle.ClientGraphics.API
{
	public class GraffitiVisualEffect : MonoBehaviour
	{
		public ImageSkin Image;
		[SerializeField]
		private GameObject _rareEffect;
		[SerializeField]
		private GameObject _epicEffect;
		[SerializeField]
		private GameObject _legendaryEffect;
	}
}
