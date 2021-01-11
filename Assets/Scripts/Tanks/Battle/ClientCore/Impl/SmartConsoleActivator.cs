using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class SmartConsoleActivator : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		[SerializeField]
		private GameObject smartConsole;

		public GameObject SmartConsole
		{
			get
			{
				return smartConsole;
			}
			set
			{
				smartConsole = value;
			}
		}
	}
}
