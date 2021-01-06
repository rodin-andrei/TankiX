using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class Ruler : MonoBehaviour
	{
		[SerializeField]
		private Image segment;
		[SerializeField]
		private float spacing;
		public int segmentsCount;
		public List<Image> segments;
		public Color Color;
	}
}
