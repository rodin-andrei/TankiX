using UnityEngine;
using System.Collections.Generic;

public class BurningTargetBloom : MonoBehaviour
{
	public Shader bloomMaskShader;
	public Shader brightPassFilterShader;
	public List<Renderer> targets;
}
