using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientControls.API
{
	public class ItemNotExistsException : ArgumentException
	{
		public ItemNotExistsException(Entity entity)
		{
		}

	}
}
