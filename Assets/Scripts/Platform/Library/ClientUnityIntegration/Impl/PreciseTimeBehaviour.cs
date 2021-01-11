using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Platform.Kernel.OSGi.ClientCore.API;
using UnityEngine;

namespace Platform.Library.ClientUnityIntegration.Impl
{
	public class PreciseTimeBehaviour : MonoBehaviour
	{
		private bool sendAfterFixedUpdateEvent;

		[Inject]
		public static EngineServiceInternal EngineServiceInternal
		{
			get;
			set;
		}

		private void FixedUpdate()
		{
			SendAfterFixedUpdateEventIfNeed();
			InternalPreciseTime.FixedUpdate(Time.fixedDeltaTime);
			sendAfterFixedUpdateEvent = true;
		}

		private void Update()
		{
			SendAfterFixedUpdateEventIfNeed();
			InternalPreciseTime.Update(Time.deltaTime);
		}

		private void SendAfterFixedUpdateEventIfNeed()
		{
			if (sendAfterFixedUpdateEvent)
			{
				InternalPreciseTime.AfterFixedUpdate();
				Flow flow = EngineServiceInternal.GetFlow();
				Invoke();
				sendAfterFixedUpdateEvent = false;
			}
		}

		private static void Invoke()
		{
			Flow current = Flow.Current;
			current.TryInvoke(AfterFixedUpdateEvent.Instance, typeof(AfterFixedUpdateEventFireHandler));
			current.TryInvoke(AfterFixedUpdateEvent.Instance, typeof(AfterFixedUpdateEventCompleteHandler));
		}
	}
}
