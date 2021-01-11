using System;
using System.Collections.Generic;
using System.Reflection;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class Handler : IComparable<Handler>
	{
		private class NodeDescriptionState
		{
			public int count;
		}

		private static int activeHandlersCount;

		private readonly MethodHandle _methodHandle;

		private string _fullMethodName;

		public HandlerInvokeGraph HandlerInvokeGraph;

		private readonly int _profilerIndex;

		public int Version
		{
			get;
			private set;
		}

		public IList<HandlerArgument> ContextArguments
		{
			get;
			private set;
		}

		public bool IsContextOnlyArguments
		{
			get;
			private set;
		}

		public bool IsEventOnlyArguments
		{
			get;
			private set;
		}

		public MethodInfo Method
		{
			get;
			internal set;
		}

		public HandlerArgumentsDescription HandlerArgumentsDescription
		{
			get;
			internal set;
		}

		public bool Mandatory
		{
			get;
			internal set;
		}

		public bool SkipInfo
		{
			get;
			internal set;
		}

		public EventPhase EventPhase
		{
			get;
			internal set;
		}

		public Type EventType
		{
			get;
			internal set;
		}

		public string ProjectName
		{
			get;
			internal set;
		}

		public string Name
		{
			get;
			internal set;
		}

		public string FullMethodName
		{
			get
			{
				if (string.IsNullOrEmpty(_fullMethodName))
				{
					_fullMethodName = GetFullMethodName();
				}
				return _fullMethodName;
			}
		}

		public Handler(EventPhase eventPhase, Type eventType, MethodInfo method, MethodHandle methodHandle, HandlerArgumentsDescription handlerArgumentsDescription)
		{
			EventPhase = eventPhase;
			EventType = eventType;
			Method = method;
			_methodHandle = methodHandle;
			HandlerArgumentsDescription = handlerArgumentsDescription;
			Mandatory = IsMandatory(method);
			SkipInfo = IsSkipInfo(method);
			ProjectName = GetProjectName();
			Name = GetHandlerName();
			bool isContextOnlyArguments = true;
			ContextArguments = new List<HandlerArgument>();
			foreach (HandlerArgument handlerArgument in HandlerArgumentsDescription.HandlerArguments)
			{
				if (handlerArgument.Context)
				{
					ContextArguments.Add(handlerArgument);
				}
				if (handlerArgument.JoinType.IsPresent())
				{
					isContextOnlyArguments = false;
				}
			}
			IsContextOnlyArguments = isContextOnlyArguments;
			IsEventOnlyArguments = HandlerArgumentsDescription.HandlerArguments.Count == 0;
			HandlerInvokeGraph = new HandlerInvokeGraph(this);
		}

		private static bool IsMandatory(MethodInfo method)
		{
			if (TestContext.IsTestMode && TestContext.Current.IsDataExists(typeof(MandatoryDisabled)))
			{
				return false;
			}
			return method.GetCustomAttributes(typeof(Mandatory), true).Length == 1;
		}

		private static bool IsSkipInfo(MethodInfo method)
		{
			return method.GetCustomAttributes(typeof(SkipInfo), true).Length == 1;
		}

		public object Invoke(object[] args)
		{
			try
			{
				return _methodHandle.Invoke(args);
			}
			finally
			{
			}
		}

		public void ChangeVersion()
		{
			Version++;
		}

		private string GetProjectName()
		{
			Type declaringType = Method.DeclaringType;
			if (declaringType != null)
			{
				string @namespace = declaringType.Namespace;
				if (!string.IsNullOrEmpty(@namespace))
				{
					int num = @namespace.IndexOf('.');
					return (num < 0) ? @namespace : @namespace.Substring(0, num);
				}
			}
			return string.Empty;
		}

		public string GetHandlerName()
		{
			Type declaringType = Method.DeclaringType;
			if (declaringType != null)
			{
				return declaringType.Name + "." + Method.Name;
			}
			return Method.Name;
		}

		public int CompareTo(Handler other)
		{
			return getKey().CompareTo(other.getKey());
		}

		private string getKey()
		{
			return Method.ToString();
		}

		private string GetFullMethodName()
		{
			ParameterInfo[] parameters = Method.GetParameters();
			string text = string.Format("{0}(", Name);
			ParameterInfo[] array = parameters;
			foreach (ParameterInfo parameterInfo in array)
			{
				text = ((!parameterInfo.ParameterType.IsGenericType) ? (text + parameterInfo.ParameterType.Name + ", ") : string.Concat(text, parameterInfo.ParameterType, ", "));
			}
			if (parameters.Length > 0)
			{
				text = text.Remove(text.Length - 2);
			}
			return text + ")";
		}

		public override string ToString()
		{
			return string.Format("[{0} {1}.{2}]", GetType().Name, ProjectName, Name);
		}
	}
}
