using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Library.ClientProtocol.API;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	[SerialVersionUID(635827527455935281L)]
	public class ScoreTableRowComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private RectTransform indicatorsContainer;

		[SerializeField]
		private Text position;

		[SerializeField]
		private Image background;

		private int positionNumber;

		public Dictionary<ScoreTableRowIndicator, ScoreTableRowIndicator> indicators = new Dictionary<ScoreTableRowIndicator, ScoreTableRowIndicator>();

		public int Position
		{
			get
			{
				return positionNumber;
			}
			set
			{
				positionNumber = value;
				if (value == 0)
				{
					position.text = string.Empty;
					base.transform.SetAsLastSibling();
				}
				else
				{
					position.text = value.ToString();
					base.transform.SetSiblingIndex(positionNumber);
				}
				SetLayoutDirty();
			}
		}

		public Color Color
		{
			get
			{
				return background.color;
			}
			set
			{
				background.color = value;
			}
		}

		public void SetLayoutDirty()
		{
			base.transform.parent.GetComponent<ScoreTableComponent>().SetDirty();
		}

		public void AddIndicator(ScoreTableRowIndicator indicatorPrefab)
		{
			ScoreTableRowIndicator scoreTableRowIndicator = Object.Instantiate(indicatorPrefab);
			indicators.Add(indicatorPrefab, scoreTableRowIndicator);
			scoreTableRowIndicator.transform.SetParent(indicatorsContainer, false);
			EntityBehaviour component = scoreTableRowIndicator.GetComponent<EntityBehaviour>();
			if (component != null)
			{
				component.BuildEntity(GetComponent<EntityBehaviour>().Entity);
			}
			Sort();
		}

		public void AddIndicators(List<ScoreTableRowIndicator> indicatorsList)
		{
			foreach (ScoreTableRowIndicator indicators2 in indicatorsList)
			{
				ScoreTableRowIndicator scoreTableRowIndicator = Object.Instantiate(indicators2);
				indicators.Add(indicators2, scoreTableRowIndicator);
				scoreTableRowIndicator.transform.SetParent(indicatorsContainer, false);
			}
			Sort();
		}

		private void Sort()
		{
			foreach (ScoreTableRowIndicator value in indicators.Values)
			{
				value.transform.SetSiblingIndex(value.index);
			}
		}

		public void RemoveIndicator(ScoreTableRowIndicator indicatorPrefab)
		{
			ScoreTableRowIndicator scoreTableRowIndicator = indicators[indicatorPrefab];
			Object.Destroy(scoreTableRowIndicator.gameObject);
			indicators.Remove(indicatorPrefab);
		}

		public void HidePosition()
		{
			position.gameObject.SetActive(false);
		}
	}
}
