using System;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.ECS.ClientEntitySystem.Impl;
using Tanks.Lobby.ClientGarage.API;
using UnityEngine;

namespace Tanks.Lobby.ClientGarage.Impl
{
	public class ModulesUtils
	{
		public static Color StringToColor(string s)
		{
			System.Random random = new System.Random(s.GetHashCode());
			return new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
		}

		public static bool EarlyIsUserItem(Entity item)
		{
			return typeof(UserItemTemplate).IsAssignableFrom(((EntityImpl)item).TemplateAccessor.Get().TemplateDescription.TemplateClass);
		}
	}
}
