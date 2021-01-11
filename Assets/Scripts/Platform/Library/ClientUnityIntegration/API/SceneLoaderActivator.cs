using System.Collections;
using System.Collections.Generic;
using Platform.Kernel.OSGi.ClientCore.API;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platform.Library.ClientUnityIntegration.API
{
	public class SceneLoaderActivator : UnityAwareActivator<ManuallyCompleting>
	{
		public List<string> environmentSceneNames;

		public float progress;

		protected override void Activate()
		{
			StartCoroutine(LoadScenes());
		}

		private IEnumerator LoadScenes()
		{
			for (int i = 0; i < environmentSceneNames.Count; i++)
			{
				yield return SceneManager.LoadSceneAsync(environmentSceneNames[i], LoadSceneMode.Additive);
				progress += 1f / (float)environmentSceneNames.Count;
			}
			progress = 1f;
			yield return new WaitForEndOfFrame();
			Complete();
		}
	}
}
