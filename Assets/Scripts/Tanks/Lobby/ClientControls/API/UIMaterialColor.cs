using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	public class UIMaterialColor : MonoBehaviour
	{
		private Graphic graphic;

		private Material material;

		private void Awake()
		{
			graphic = GetComponent<Graphic>();
			material = new Material(graphic.material);
			graphic.material = material;
		}

		private void Update()
		{
			if (material.color != graphic.color)
			{
				material.SetColor("_Color", graphic.color);
			}
		}
	}
}
