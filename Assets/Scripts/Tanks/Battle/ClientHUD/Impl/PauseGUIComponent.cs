using Platform.Kernel.ECS.ClientEntitySystem.API;
using Tanks.Battle.ClientGraphics.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	public class PauseGUIComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public bool ShowMessage
		{
			get;
			set;
		}

		public string MessageText
		{
			get;
			set;
		}

		private void OnGUI()
		{
			if (ShowMessage)
			{
				Vector3 vector = new Vector3(500f, 200f);
				Rect screenRect = new Rect((float)Screen.width / 2f - vector.x / 2f, (float)Screen.height / 2f - vector.y / 2f, vector.x, vector.y);
				GUILayout.BeginArea(screenRect);
				GUILayout.BeginVertical();
				GUILayout.Label(MessageText, ClientGraphicsActivator.guiStyle);
				GUILayout.EndVertical();
				GUILayout.EndArea();
			}
		}
	}
}
