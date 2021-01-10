using UnityEngine;

public class PostEffectsSet : MonoBehaviour
{
	public string qualityName;
	public DepthTextureMode depthTextureMode;
	[SerializeField]
	private MonoBehaviour[] effects;
}
