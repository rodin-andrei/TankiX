using UnityEngine;
using System.Collections.Generic;
using Tanks.Battle.ClientGraphics.Impl;

namespace Tanks.Battle.ClientGraphics.API
{
	public class MyShadowSystem : MonoBehaviour
	{
		public List<CharacterShadowComponent> characters;
		public Camera camera;
	}
}
