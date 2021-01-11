using System;
using System.Collections;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientQuests.Impl
{
	public class InBattleQuestsContainerGUIComponent : BehaviourComponent
	{
		[SerializeField]
		private GameObject questPrefab;

		[SerializeField]
		private GameObject questsContainer;

		public GameObject CreateQuestItem()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(questPrefab);
			gameObject.transform.SetParent(questsContainer.transform, false);
			SendMessage("RefreshCurve", SendMessageOptions.DontRequireReceiver);
			return gameObject;
		}

		public void DeleteAllQuests()
		{
			IEnumerator enumerator = questsContainer.transform.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Transform transform = (Transform)enumerator.Current;
					UnityEngine.Object.Destroy(transform.gameObject);
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

		public void CreateQuest()
		{
			CreateQuestItem();
		}

		public void RemoveQuest()
		{
			UnityEngine.Object.Destroy(questsContainer.transform.GetChild(questsContainer.transform.childCount - 1).gameObject);
		}
	}
}
