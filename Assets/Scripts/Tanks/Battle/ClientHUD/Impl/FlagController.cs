using System;
using UnityEngine;

namespace Tanks.Battle.ClientHUD.Impl
{
	[RequireComponent(typeof(Animator))]
	public class FlagController : MonoBehaviour
	{
		private Action onReset;

		private string lastState;

		public void TurnIn(Action onReset)
		{
			this.onReset = (Action)Delegate.Combine(this.onReset, onReset);
			SetState("TurnIn");
		}

		public void Drop()
		{
			SetState("Drop");
		}

		public void Return(Action onReset)
		{
			this.onReset = (Action)Delegate.Combine(this.onReset, onReset);
			SetState("Return");
		}

		public void PickUp()
		{
			SetState("PickUp");
		}

		private void SetState(string state)
		{
			lastState = state;
			if (base.gameObject.activeInHierarchy)
			{
				GetComponent<Animator>().SetTrigger(state);
			}
		}

		private void OnEnable()
		{
			if (lastState != null)
			{
				GetComponent<Animator>().SetTrigger(lastState);
			}
		}

		private void OnDisable()
		{
			lastState = null;
		}

		private void Reset()
		{
			if (onReset != null)
			{
				onReset();
			}
			onReset = null;
		}
	}
}
