using System;
using System.Collections.Generic;
using System.Reflection;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class ComponentDescriptionImpl : ComponentDescription
	{
		private readonly IDictionary<Type, ComponentInfo> infos;

		private readonly MethodInfo componentMethod;

		private readonly string fieldName;

		private readonly Type componentType;

		public string FieldName
		{
			get
			{
				return fieldName;
			}
		}

		public Type ComponentType
		{
			get
			{
				return componentType;
			}
		}

		public ComponentDescriptionImpl(MethodInfo componentMethod)
		{
			infos = new Dictionary<Type, ComponentInfo>();
			fieldName = componentMethod.Name;
			this.componentMethod = componentMethod;
			componentType = _getComponentType(componentMethod);
		}

		public void CollectInfo(ICollection<ComponentInfoBuilder> builders)
		{
			foreach (ComponentInfoBuilder builder in builders)
			{
				if (builder.IsAcceptable(componentMethod))
				{
					infos[builder.TemplateComponentInfoClass] = builder.Build(componentMethod, this);
				}
			}
		}

		public T GetInfo<T>() where T : ComponentInfo
		{
			Type typeFromHandle = typeof(T);
			if (!infos.ContainsKey(typeFromHandle))
			{
				throw new ComponentInfoNotFoundException(typeFromHandle, componentMethod);
			}
			return (T)infos[typeFromHandle];
		}

		public bool IsInfoPresent(Type infoType)
		{
			return infos.ContainsKey(infoType);
		}

		private Type _getComponentType(MethodInfo componentMethod)
		{
			Type returnType = componentMethod.ReturnType;
			if (!typeof(Component).IsAssignableFrom(returnType))
			{
				throw new WrongComponentTypeException(returnType);
			}
			return returnType;
		}
	}
}
