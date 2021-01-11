using TMPro;
using UnityEngine;

namespace Tanks.Lobby.ClientBattleSelect.Impl
{
	public class MVPStatElementComponent : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI count;

		[SerializeField]
		private GameObject best;

		private int _count;

		public int Count
		{
			get
			{
				return _count;
			}
			set
			{
				_count = value;
				count.text = _count.ToString();
			}
		}

		public void SetBest(bool isBest)
		{
			best.gameObject.SetActive(isBest);
		}

		public bool ShowIfCan()
		{
			base.gameObject.SetActive(_count > 0);
			return _count > 0;
		}

		public void Hide()
		{
			base.gameObject.SetActive(false);
		}
	}
}
