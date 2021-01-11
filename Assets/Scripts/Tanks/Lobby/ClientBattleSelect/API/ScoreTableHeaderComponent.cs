using System;
using System.Collections;
using System.Collections.Generic;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientBattleSelect.API
{
	public class ScoreTableHeaderComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public List<ScoreTableRowIndicator> headers = new List<ScoreTableRowIndicator>();

		[SerializeField]
		private RectTransform headerTitle;

		[SerializeField]
		private RectTransform scoreHeaderContainer;

		public void Clear()
		{
			IEnumerator enumerator = scoreHeaderContainer.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Transform transform = (Transform)enumerator.Current;
					if (transform != headerTitle)
					{
						UnityEngine.Object.Destroy(transform.gameObject);
					}
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = enumerator as IDisposable) != null)
				{
					disposable.Dispose();
				}
			}
		}

		public void AddHeader(ScoreTableRowIndicator headerPrefab)
		{
			ScoreTableRowIndicator scoreTableRowIndicator = UnityEngine.Object.Instantiate(headerPrefab);
			scoreTableRowIndicator.transform.SetParent(scoreHeaderContainer, false);
		}

		public void SetDirty()
		{
			LayoutRebuilder.MarkLayoutForRebuild(scoreHeaderContainer);
		}
	}
}
