using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Platform.Kernel.ECS.ClientEntitySystem.API;
using Platform.Kernel.OSGi.ClientCore.API;
using Platform.Library.ClientDataStructures.API;

namespace Platform.Kernel.ECS.ClientEntitySystem.Impl
{
	public class HandlerArgumentsParser
	{
		private readonly MethodInfo method;

		private Type[] NodeChangeEventTypes = new Type[2]
		{
			typeof(NodeAddedEvent),
			typeof(NodeRemoveEvent)
		};

		[Inject]
		public static NodeDescriptionRegistry NodeDescriptionRegistry
		{
			get;
			set;
		}

		public HandlerArgumentsParser(MethodInfo method)
		{
			this.method = method;
		}

		public HandlerArgumentsDescription Parse()
		{
			HashSet<Type> hashSet = ParseEvents();
			List<HandlerArgument> handlerArguments = ParseHandlerArguments(IsNodeChangeHandler(hashSet));
			HashSet<Type> additionalComponentClasses = ParseComponents(handlerArguments);
			return new HandlerArgumentsDescription(handlerArguments, hashSet, additionalComponentClasses);
		}

		private bool IsNodeChangeHandler(IEnumerable<Type> eventClasses)
		{
			return eventClasses.Any((Type e) => NodeChangeEventTypes.Contains(e));
		}

		private List<HandlerArgument> ParseHandlerArguments(bool isNodeChangeHandler)
		{
			ParameterInfo[] parameters = method.GetParameters();
			HandlerArgument[] array = new HandlerArgument[parameters.Length - 1];
			int num = 0;
			Optional<JoinType> rightJoin = Optional<JoinType>.empty();
			for (int num2 = parameters.Length - 1; num2 > 0; num2--)
			{
				num = num2 - 1;
				ParameterInfo parameterInfo = parameters[num2];
				object[] customAttributes = parameterInfo.GetCustomAttributes(true);
				Optional<JoinType> joinType = GetJoinType(customAttributes);
				HandlerArgument handlerArgument = CreateNodeType(num, parameterInfo.ParameterType, joinType, rightJoin, customAttributes, isNodeChangeHandler);
				rightJoin = joinType;
				if (handlerArgument == null)
				{
					throw new ArgumentMustBeNodeException(method, parameterInfo);
				}
				array[num] = handlerArgument;
			}
			CheckArguments(array);
			return array.ToList();
		}

		private static HandlerArgument CreateNodeType(int position, Type type, Optional<JoinType> join, Optional<JoinType> rightJoin, object[] annotatedTypes, bool isNodeChangeHandler)
		{
			Type nodeType = GetNodeType(type);
			if (nodeType == null)
			{
				return null;
			}
			HashSet<Type> hashSet = new HashSet<Type>();
			bool flag = IsContextNode(annotatedTypes, join);
			if (isNodeChangeHandler && flag)
			{
				CollectGroupComponent(join, hashSet);
				CollectGroupComponent(rightJoin, hashSet);
			}
			NodeClassInstanceDescription orCreateNodeClassDescription = NodeDescriptionRegistry.GetOrCreateNodeClassDescription(nodeType, hashSet);
			return new HandlerArgumentBuilder().SetPosition(position).SetType(type).SetJoinType(join)
				.SetContext(flag)
				.SetCollection(IsCollection(type))
				.SetNodeClassInstanceDescription(orCreateNodeClassDescription)
				.SetMandatory(IsMandatory(annotatedTypes))
				.SetCombine(IsCombine(annotatedTypes))
				.SetOptional(IsOptional(type))
				.Build();
		}

		private static void CollectGroupComponent(Optional<JoinType> join, HashSet<Type> components)
		{
			if (join.IsPresent())
			{
				Optional<Type> contextComponent = join.Get().ContextComponent;
				if (contextComponent.IsPresent())
				{
					components.Add(contextComponent.Get());
				}
			}
		}

		private HashSet<Type> ParseEvents()
		{
			return ParseClasses(typeof(Event));
		}

		private static Type GetNodeType(Type type)
		{
			if (IsOptional(type))
			{
				return GetNodeType(type.GetGenericArguments()[0]);
			}
			if (IsNode(type))
			{
				return type;
			}
			if (IsCollection(type))
			{
				Type type2 = type.GetGenericArguments()[0];
				if (IsNode(type2))
				{
					return type2;
				}
				if (type2.IsSubclassOf(typeof(AbstractSingleNode)))
				{
					Type type3 = type2.GetGenericArguments()[0];
					if (IsNode(type3))
					{
						return type3;
					}
				}
			}
			return null;
		}

		private static Optional<JoinType> GetJoinType(object[] annotatedTypes)
		{
			List<object> list = new List<object>();
			foreach (object obj in annotatedTypes)
			{
				list.Add(obj);
				object[] customAttributes = obj.GetType().GetCustomAttributes(true);
				list.AddRange(customAttributes);
			}
			foreach (object item in list)
			{
				if (item is JoinAll)
				{
					return Optional<JoinType>.of(new JoinAllType());
				}
				if (item is JoinBy)
				{
					JoinBy joinBy = (JoinBy)item;
					return Optional<JoinType>.of(new JoinByType(joinBy.value));
				}
				if (item is JoinSelf)
				{
					return Optional<JoinType>.of(new JoinSelfType());
				}
			}
			return Optional<JoinType>.empty();
		}

		private void CheckArguments(IList<HandlerArgument> arguments)
		{
			CheckFirstNotJoin(arguments);
		}

		private void CheckFirstNotJoin(IList<HandlerArgument> arguments)
		{
			if (arguments.Count > 0)
			{
				HandlerArgument handlerArgument = arguments[0];
				if (handlerArgument.JoinType.IsPresent() && handlerArgument.JoinType.Get().ContextComponent.IsPresent())
				{
					throw new JoinFirstNodeArgumentException(method, handlerArgument);
				}
			}
		}

		private HashSet<Type> ParseComponents(IList<HandlerArgument> handlerArguments)
		{
			HashSet<Type> s = ParseClasses(typeof(Component));
			HashSet<Type> componentsFromNodes = GetComponentsFromNodes(handlerArguments);
			return Concat(s, componentsFromNodes);
		}

		private static HashSet<Type> GetComponentsFromNodes(IList<HandlerArgument> handlerArguments)
		{
			HashSet<Type> hashSet = new HashSet<Type>();
			foreach (HandlerArgument handlerArgument in handlerArguments)
			{
				NodeDescription nodeDescription = handlerArgument.NodeDescription;
				foreach (Type component in nodeDescription.Components)
				{
					hashSet.Add(component);
				}
				foreach (Type notComponent in nodeDescription.NotComponents)
				{
					hashSet.Add(notComponent);
				}
			}
			return hashSet;
		}

		private HashSet<Type> ParseClasses(Type clazz)
		{
			HashSet<Type> hashSet = new HashSet<Type>();
			ParameterInfo[] parameters = method.GetParameters();
			ParameterInfo[] array = parameters;
			foreach (ParameterInfo parameterInfo in array)
			{
				hashSet.Add(parameterInfo.ParameterType);
				Type[] genericArguments = parameterInfo.ParameterType.GetGenericArguments();
				Type[] array2 = genericArguments;
				foreach (Type item in array2)
				{
					hashSet.Add(item);
				}
			}
			HashSet<Type> hashSet2 = new HashSet<Type>();
			foreach (Type item2 in hashSet)
			{
				if (item2.IsSubclassOf(clazz))
				{
					hashSet2.Add(item2);
				}
			}
			return hashSet2;
		}

		private static bool IsContextNode(object[] annotatedTypes, Optional<JoinType> joinType)
		{
			if (HasAttrubte(annotatedTypes, typeof(Context)))
			{
				return true;
			}
			return !joinType.IsPresent();
		}

		private static bool IsCollection(Type type)
		{
			if (IsOptional(type))
			{
				return IsCollection(type.GetGenericArguments()[0]);
			}
			if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ICollection<>))
			{
				return true;
			}
			return false;
		}

		private static bool IsNode(Type type)
		{
			return type.IsSubclassOf(typeof(Node)) || type == typeof(Node);
		}

		private static bool IsMandatory(object[] annotatedTypes)
		{
			if (TestContext.IsTestMode && TestContext.Current.IsDataExists(typeof(MandatoryDisabled)))
			{
				return false;
			}
			return HasAttrubte(annotatedTypes, typeof(Mandatory));
		}

		private static bool IsCombine(object[] annotatedTypes)
		{
			return HasAttrubte(annotatedTypes, typeof(Combine));
		}

		private static bool HasAttrubte(object[] attrubtes, Type type)
		{
			foreach (object obj in attrubtes)
			{
				if (obj.GetType() == type)
				{
					return true;
				}
			}
			return false;
		}

		private static bool IsOptional(Type type)
		{
			return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Optional<>);
		}

		private static HashSet<Type> Concat(HashSet<Type> s1, HashSet<Type> s2)
		{
			HashSet<Type> hashSet = new HashSet<Type>(s1);
			foreach (Type item in s2)
			{
				hashSet.Add(item);
			}
			return hashSet;
		}
	}
}
