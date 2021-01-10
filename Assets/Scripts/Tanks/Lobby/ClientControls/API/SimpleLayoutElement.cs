using UnityEngine.EventSystems;
using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	public class SimpleLayoutElement : UIBehaviour
	{
		[SerializeField]
		private bool m_IgnoreLayout;
		[SerializeField]
		private float m_FlexibleWidth;
		[SerializeField]
		private float m_FlexibleHeight;
		[SerializeField]
		private float m_MinWidth;
		[SerializeField]
		private float m_MinHeight;
		[SerializeField]
		private float m_MaxWidth;
		[SerializeField]
		private float m_MaxHeight;
	}
}
