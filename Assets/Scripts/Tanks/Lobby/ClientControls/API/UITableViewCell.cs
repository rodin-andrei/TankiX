using UnityEngine;

namespace Tanks.Lobby.ClientControls.API
{
	[RequireComponent(typeof(RectTransform))]
	public class UITableViewCell : MonoBehaviour
	{
		private TableViewCellRemoved cellRemoved;

		[SerializeField]
		private int index;

		public bool removed;

		private float moveSpeed = 600f;

		private UITableView tableView;

		private RectTransform cellRect;

		private Vector2 targetPosition;

		private Animator animator;

		private bool moveToPosition;

		public TableViewCellRemoved CellRemoved
		{
			get
			{
				return cellRemoved;
			}
			set
			{
				cellRemoved = value;
			}
		}

		public int Index
		{
			get
			{
				return index;
			}
			set
			{
				index = value;
				targetPosition = tableView.PositionForRowAtIndex(index);
			}
		}

		public RectTransform CellRect
		{
			get
			{
				return cellRect;
			}
		}

		private void Awake()
		{
			cellRect = GetComponent<RectTransform>();
			RectTransform rectTransform = cellRect;
			Vector2 vector = new Vector2(0f, 1f);
			cellRect.anchorMax = vector;
			vector = vector;
			cellRect.anchorMin = vector;
			rectTransform.pivot = vector;
			tableView = GetComponentInParent<UITableView>();
			animator = GetComponent<Animator>();
		}

		public void UpdatePositionImmidiate()
		{
			cellRect.anchoredPosition = targetPosition;
		}

		public void UpdatePosition()
		{
			moveToPosition = true;
		}

		private void Update()
		{
			if (moveToPosition)
			{
				float num = Vector2.Distance(cellRect.anchoredPosition, targetPosition);
				if (num > 0.1f)
				{
					cellRect.anchoredPosition = Vector2.Lerp(cellRect.anchoredPosition, targetPosition, Time.deltaTime / num * moveSpeed);
				}
				else
				{
					moveToPosition = false;
				}
			}
		}

		public void Remove(bool toRight)
		{
			if (base.gameObject.activeSelf)
			{
				animator.SetBool("toRight", toRight);
				animator.SetBool("remove", true);
			}
			else
			{
				Removed();
			}
		}

		private void Removed()
		{
			if (cellRemoved != null)
			{
				cellRemoved(this);
			}
		}

		protected void OnDisable()
		{
			animator.SetBool("show", false);
			animator.SetBool("remove", false);
			if (cellRemoved != null)
			{
				cellRemoved(this);
			}
		}

		protected void OnDestroy()
		{
			cellRemoved = null;
		}
	}
}
