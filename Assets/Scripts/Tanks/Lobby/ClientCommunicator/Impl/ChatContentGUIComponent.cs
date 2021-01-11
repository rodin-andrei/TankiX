using System;
using System.Collections;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.Serialization;

namespace Tanks.Lobby.ClientCommunicator.Impl
{
	public class ChatContentGUIComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[FormerlySerializedAs("messageAsset")]
		[SerializeField]
		private GameObject messagePrefab;

		public GameObject MessagePrefab
		{
			get
			{
				return messagePrefab;
			}
		}

		public void ClearMessages()
		{
			IEnumerator enumerator = base.transform.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Transform transform = (Transform)enumerator.Current;
					if (transform.GetComponent<ChatMessageUIComponent>() != null)
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
	}
}
