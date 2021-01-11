using UnityEngine;

namespace Tanks.Battle.ClientGraphics.Impl
{
	public class UpdateRankEffectFixShaderQueue : MonoBehaviour
	{
		public int AddQueue = 1;

		private void Start()
		{
			if (GetComponent<Renderer>() != null)
			{
				GetComponent<Renderer>().sharedMaterial.renderQueue += AddQueue;
			}
			else
			{
				Invoke("SetProjectorQueue", 0.1f);
			}
		}

		private void SetProjectorQueue()
		{
			GetComponent<Projector>().material.renderQueue += AddQueue;
		}

		private void Update()
		{
		}
	}
}
