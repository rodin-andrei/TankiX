using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientGarage.API
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(GridLayoutGroup))]
	public class FlexibleWidthColumnGridLayout : UIBehaviour
	{
		[SerializeField]
		private RectTransform viewport;

		protected override void Awake()
		{
			if (viewport == null)
			{
				viewport = (RectTransform)base.transform.parent;
			}
		}

		protected override void OnEnable()
		{
			CalculateWidthCell();
		}

		protected override void OnRectTransformDimensionsChange()
		{
			CalculateWidthCell();
		}

		protected override void OnTransformParentChanged()
		{
			CalculateWidthCell();
		}

		private void CalculateWidthCell()
		{
			float width = viewport.rect.width;
			GridLayoutGroup component = GetComponent<GridLayoutGroup>();
			if (component.constraint == GridLayoutGroup.Constraint.FixedColumnCount)
			{
				int constraintCount = component.constraintCount;
				float num = (width - component.spacing.x * (float)(constraintCount - 1)) / (float)constraintCount;
				component.cellSize = new Vector2((int)num, component.cellSize.y);
			}
		}
	}
}
