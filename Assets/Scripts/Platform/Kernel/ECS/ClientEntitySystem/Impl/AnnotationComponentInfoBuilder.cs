using System;
using System.Reflection;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class AnnotationComponentInfoBuilder<T> : ComponentInfoBuilder where T : ComponentInfo, new()
	{
		private readonly Type annotationType;

		public Type TemplateComponentInfoClass
		{
			get
			{
				return typeof(T);
			}
		}

		public AnnotationComponentInfoBuilder(Type annotationType, Type componentInfoClass)
		{
			this.annotationType = annotationType;
		}

		public bool IsAcceptable(MethodInfo componentMethod)
		{
			return componentMethod.GetCustomAttributes(annotationType, true).Length == 1;
		}

		public ComponentInfo Build(MethodInfo componentMethod, ComponentDescriptionImpl componentDescription)
		{
			return new T();
		}
	}
}
