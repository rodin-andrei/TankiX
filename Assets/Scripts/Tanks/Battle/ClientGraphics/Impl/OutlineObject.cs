using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class OutlineObject : MonoBehaviour
	{
		[SerializeField]
		private Color glowColor;

		[Range(0f, 1f)]
		public float saturation;

		public float LerpFactor = 10f;

		public bool Enable;

		private List<Material> _materials = new List<Material>();

		private Color _currentColor;

		private Color _targetColor;

		public Color GlowColor
		{
			get
			{
				return glowColor;
			}
			set
			{
				glowColor = value;
			}
		}

		public Renderer[] Renderers
		{
			get;
			private set;
		}

		private void Start()
		{
			Renderers = GetComponentsInChildren<Renderer>();
			Renderer[] renderers = Renderers;
			foreach (Renderer renderer in renderers)
			{
				_materials.AddRange(renderer.materials);
			}
		}

		private void Update()
		{
			if (Enable)
			{
				_targetColor = glowColor * saturation;
			}
			else
			{
				_targetColor = Color.black;
			}
			_currentColor = Color.Lerp(_currentColor, _targetColor, Time.deltaTime * LerpFactor);
			for (int i = 0; i < _materials.Count; i++)
			{
				_materials[i].SetColor("_outlineColor", _currentColor);
			}
		}
	}
}
