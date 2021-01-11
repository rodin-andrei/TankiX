using Platform.Kernel.ECS.ClientEntitySystem.API;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Battle.ClientHUD.API
{
	public class ServiceMessageComponent : MonoBehaviour, Platform.Kernel.ECS.ClientEntitySystem.API.Component
	{
		public Animator animator;

		public Text MessageText;
	}
}
