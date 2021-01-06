using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	public class ImageSkin : MonoBehaviour
	{
		[SerializeField]
		private string structureUid;
		[SerializeField]
		private string spriteUid;
		public Image.Type type;
	}
}
