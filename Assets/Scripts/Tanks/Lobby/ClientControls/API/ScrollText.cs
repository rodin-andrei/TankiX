using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	public class ScrollText : MonoBehaviour
	{
		[SerializeField]
		private Text text;

		public virtual string Text
		{
			get
			{
				return text.text;
			}
			set
			{
				text.text = value;
			}
		}
	}
}
