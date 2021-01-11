using Tanks.Lobby.ClientSettings.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class DistortionEffectBehaviour : MonoBehaviour
	{
		private const int DISTORTION_QUALITY_LEVEL = 2;

		[SerializeField]
		private GameObject[] distortionGameObjects;

		private void Awake()
		{
			bool active = GraphicsSettings.INSTANCE.CurrentQualityLevel >= 2;
			int num = distortionGameObjects.Length;
			for (int i = 0; i < num; i++)
			{
				distortionGameObjects[i].SetActive(active);
			}
		}
	}
}
