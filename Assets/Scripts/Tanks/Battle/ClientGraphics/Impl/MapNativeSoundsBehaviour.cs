using Platform.Library.ClientDataStructures.API;
using Tanks.Battle.ClientGraphics.API;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class MapNativeSoundsBehaviour : MonoBehaviour
	{
		[SerializeField]
		private FadeSoundFilter[] sounds;

		private void Update()
		{
			if (base.transform.childCount <= 0)
			{
				Object.DestroyObject(base.gameObject);
			}
		}

		public void Play()
		{
			sounds.ForEach(delegate(FadeSoundFilter s)
			{
				s.Play();
			});
		}

		public void Stop()
		{
			base.enabled = true;
			sounds.ForEach(delegate(FadeSoundFilter s)
			{
				s.Stop();
			});
		}
	}
}
