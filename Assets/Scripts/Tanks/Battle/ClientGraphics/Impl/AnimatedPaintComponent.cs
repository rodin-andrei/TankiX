using System.Collections.Generic;
using Tanks.Battle.ClientGraphics.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class AnimatedPaintComponent : MonoBehaviour
	{
		[SerializeField]
		private float saturtion = 1f;

		[SerializeField]
		private float value = 1f;

		[SerializeField]
		private float speed = 1f;

		private float hue = 1f;

		private List<Material> materials = new List<Material>();

		private void Start()
		{
			hue = Random.Range(0f, 1f);
		}

		public void AddMaterial(Material material)
		{
			materials.Add(material);
		}

		private void Update()
		{
			Color color = Color.HSVToRGB(hue, saturtion, value);
			hue += Time.deltaTime * speed;
			if (hue > 1f)
			{
				hue = 0f;
			}
			foreach (Material material in materials)
			{
				material.SetColor(TankMaterialPropertyNames.COLORING_ID, color);
			}
		}
	}
}
