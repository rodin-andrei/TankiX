using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public class ParentRendererBehaviour : MonoBehaviour
	{
		[SerializeField]
		private Renderer parentRenderer;

		public Renderer ParentRenderer
		{
			get
			{
				return parentRenderer;
			}
			set
			{
				parentRenderer = value;
			}
		}
	}
}
