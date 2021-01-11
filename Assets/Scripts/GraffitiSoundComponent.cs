using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

public class GraffitiSoundComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
{
	[SerializeField]
	private AudioSource sound;

	public AudioSource Sound
	{
		get
		{
			return sound;
		}
	}
}
