using Tanks.Battle.ClientCore.API;
using Tanks.Battle.ClientGraphics.Impl;
using UnityEngine;

namespace Tanks.Battle.ClientGraphics.API
{
	public static class TankBuilderUtil
	{
		private const string HULL_RENDERER_NAME = "body";

		private const string WEAPON_RENDERER_NAME = "weapon";

		private const string CONTAINER_RENDERER_NAME = "container";

		public static Renderer GetHullRenderer(GameObject hull)
		{
			TankVisualRootComponent componentInChildren = hull.GetComponentInChildren<TankVisualRootComponent>();
			GameObject gameObject = componentInChildren.transform.Find("body").gameObject;
			return GraphicsBuilderUtils.GetRenderer(gameObject);
		}

		public static Renderer GetWeaponRenderer(GameObject weapon)
		{
			WeaponVisualRootComponent componentInChildren = weapon.GetComponentInChildren<WeaponVisualRootComponent>();
			GameObject gameObject = componentInChildren.transform.Find("weapon").gameObject;
			return GraphicsBuilderUtils.GetRenderer(gameObject);
		}

		public static Renderer GetContainerRenderer(GameObject hull)
		{
			GameObject gameObject = hull.transform.Find("container").gameObject;
			return GraphicsBuilderUtils.GetRenderer(gameObject);
		}
	}
}
