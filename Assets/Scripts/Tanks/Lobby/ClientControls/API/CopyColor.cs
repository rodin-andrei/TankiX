using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Lobby.ClientControls.API
{
	[RequireComponent(typeof(Graphic))]
	public class CopyColor : MonoBehaviour
	{
		[SerializeField]
		private List<Graphic> targets;

		private Graphic source;

		private void Awake()
		{
			source = GetComponent<Graphic>();
		}

		private void Update()
		{
			foreach (Graphic target in targets)
			{
				target.color = source.color;
			}
		}
	}
}
