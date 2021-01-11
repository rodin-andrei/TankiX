using System;
using System.Linq;
using Platform.Library.ClientUnityIntegration.API;
using UnityEngine;

namespace Tanks.Lobby.ClientSettings.API
{
	public class CompactScreenBehaviour : MonoBehaviour
	{
		private enum State
		{
			IDLE,
			COMPACT,
			DESTRUCTION
		}

		private State state;

		private Resolution avgRes;

		public void InitCompactMode()
		{
			int avgWidth = Convert.ToInt32(GraphicsSettings.INSTANCE.ScreenResolutions.Average((Resolution r) => r.width));
			int avgHeight = Convert.ToInt32(GraphicsSettings.INSTANCE.ScreenResolutions.Average((Resolution r) => r.height));
			avgRes = GraphicsSettings.INSTANCE.ScreenResolutions.OrderBy((Resolution r) => Mathf.Abs(r.width - avgWidth) + Mathf.Abs(r.height - avgHeight)).First();
			Resolution currentResolution = GraphicsSettings.INSTANCE.CurrentResolution;
			if (currentResolution.width + currentResolution.height < avgRes.width + avgRes.height)
			{
				avgRes = currentResolution;
			}
			ApplyCompactScreenData();
			state = ((!ApplicationFocusBehaviour.INSTANCE.Focused) ? State.COMPACT : State.IDLE);
		}

		public void DisableCompactMode()
		{
			ApplyInitialScreenData();
			if (ApplicationFocusBehaviour.INSTANCE.Focused)
			{
				UnityEngine.Object.Destroy(this);
			}
			else
			{
				state = State.DESTRUCTION;
			}
		}

		private void Update()
		{
			if (ApplicationFocusBehaviour.INSTANCE.Focused)
			{
				switch (state)
				{
				case State.COMPACT:
					ApplyCompactScreenData();
					state = State.IDLE;
					break;
				case State.DESTRUCTION:
					ApplyInitialScreenData();
					UnityEngine.Object.Destroy(this);
					break;
				}
			}
		}

		private void OnApplicationQuit()
		{
			GraphicsSettings.INSTANCE.SaveWindowModeOnQuit();
		}

		private void ApplyCompactScreenData()
		{
			Screen.SetResolution(avgRes.width, avgRes.height, false);
		}

		private void ApplyInitialScreenData()
		{
			GraphicsSettings.INSTANCE.ApplyInitialScreenResolutionData();
		}
	}
}
