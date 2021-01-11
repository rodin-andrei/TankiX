using UnityEngine;

namespace Tanks.Lobby.ClientEntrance.Impl
{
	public class AnimatedLogo : MonoBehaviour
	{
		public Material videoTextureMaterial;

		private void Start()
		{
			MovieTexture movieTexture = (MovieTexture)videoTextureMaterial.mainTexture;
			movieTexture.loop = true;
			movieTexture.Play();
		}
	}
}
