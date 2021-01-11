using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Platform.Library.ClientDataStructures.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class InputManagerImpl : InputManager
	{
		public static bool SUSPENDED;

		private static float EPS = 0.05f;

		private MultiMap<string, InputAction> contextToActions = new MultiMap<string, InputAction>();

		private MultiMap<InputAction, KeyCode> actionToKeys = new MultiMap<InputAction, KeyCode>();

		private MultiMap<InputAction, string> actionToAxes = new MultiMap<InputAction, string>();

		private MultiMap<string, InputAction> nameToAction = new MultiMap<string, InputAction>();

		private HashSet<int> keysPressed = new HashSet<int>();

		private HashSet<string> activeContexts = new HashSet<string>();

		private Dictionary<InputAction, float> axisVals = new Dictionary<InputAction, float>();

		private HashSet<InputAction> pendingActions = new HashSet<InputAction>();

		private int resumeAtFrame;

		private bool Suspended
		{
			get
			{
				return SUSPENDED || Time.frameCount <= resumeAtFrame;
			}
		}

		public void ClearActions()
		{
			keysPressed.Clear();
			pendingActions.Clear();
		}

		public InputAction GetAction(InputActionId actionId, InputActionContextId contextId)
		{
			HashSet<InputAction> values = nameToAction.GetValues(actionId.actionName);
			foreach (InputAction item in values)
			{
				if (item.contextId.Equals(contextId))
				{
					return item;
				}
			}
			return null;
		}

		public void ChangeInputActionKey(InputActionId actionId, InputActionContextId contextId, int keyId, KeyCode newKeyCode)
		{
			ChangeInputActionKey(actionId, contextId, keyId, new InputKeyCode(newKeyCode));
		}

		private void ChangeInputActionKey(InputActionId actionId, InputActionContextId contextId, int keyId, InputKeyCode newKeyCode)
		{
			HashSet<InputAction> hashSet = nameToAction[actionId.actionName];
			foreach (InputAction item in hashSet)
			{
				if (object.Equals(item.contextId, contextId))
				{
					KeyCode keyCode = ((newKeyCode != null) ? newKeyCode.keyCode : KeyCode.None);
					RemoveKeysFromMap(item);
					SetActionKey(item, keyId, keyCode);
					AddKeysToMap(item);
					SaveKeys(item, keyId, keyCode);
				}
			}
		}

		public void DeleteKeyBinding(InputActionId actionId, InputActionContextId contextId, int id)
		{
			ChangeInputActionKey(actionId, contextId, id, null);
		}

		public InputKeyCode GetCurrentKeyPressed()
		{
			IEnumerator enumerator = Enum.GetValues(typeof(KeyCode)).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					KeyCode keyCode = (KeyCode)current;
					if (Input.GetKey(keyCode))
					{
						return new InputKeyCode(keyCode);
					}
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = enumerator as IDisposable) != null)
				{
					disposable.Dispose();
				}
			}
			return null;
		}

		private void SetActionKey(InputAction action, int id, KeyCode keyCode)
		{
			if (id >= action.keys.Length)
			{
				KeyCode[] keys = action.keys;
				action.keys = new KeyCode[id + 1];
				for (int i = 0; i < keys.Length; i++)
				{
					action.keys[i] = keys[i];
				}
			}
			action.keys[id] = keyCode;
		}

		private void LoadSavedKey(InputAction action, int id)
		{
			string key = GeneratePersistentKey(action, id);
			string @string = PlayerPrefs.GetString(key);
			if (!string.IsNullOrEmpty(@string))
			{
				KeyCode keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), @string);
				SetActionKey(action, id, keyCode);
			}
		}

		private void LoadInputAction(InputAction inputAction)
		{
			LoadSavedKey(inputAction, 0);
			LoadSavedKey(inputAction, 1);
		}

		private void SaveKeys(InputAction action, int id, KeyCode keyCode)
		{
			string key = GeneratePersistentKey(action, id);
			PlayerPrefs.SetString(key, keyCode.ToString());
		}

		private string GeneratePersistentKey(InputAction action, int id)
		{
			return string.Concat(action.contextId.ToString(), action.actionId, id);
		}

		private void RemoveKeysFromMap(InputAction action)
		{
			KeyCode[] keys = action.keys;
			int num = keys.Length;
			for (int i = 0; i < num; i++)
			{
				actionToKeys.Remove(action, keys[i]);
			}
		}

		private void AddKeysToMap(InputAction action)
		{
			KeyCode[] keys = action.keys;
			int num = keys.Length;
			for (int i = 0; i < num; i++)
			{
				actionToKeys.Add(action, keys[i]);
			}
			MultiKeys[] multiKeys = action.multiKeys;
			int num2 = multiKeys.Length;
			for (int j = 0; j < num2; j++)
			{
				KeyCode[] keys2 = multiKeys[j].keys;
				num = keys2.Length;
				for (int k = 0; k < num; k++)
				{
					actionToKeys.Add(action, keys2[k]);
				}
			}
			UnityInputAxes[] axes = action.axes;
			int num3 = axes.Length;
			for (int l = 0; l < num3; l++)
			{
				string enumDescription = GetEnumDescription(action.axes[l]);
				actionToAxes.Add(action, enumDescription);
			}
		}

		public void ResetToDefaultActions()
		{
			foreach (InputAction key in actionToKeys.Keys)
			{
				PlayerPrefs.DeleteKey(GeneratePersistentKey(key, 0));
				PlayerPrefs.DeleteKey(GeneratePersistentKey(key, 1));
				RegisterInputAction(key);
			}
			contextToActions.Clear();
			actionToKeys.Clear();
			actionToAxes.Clear();
			nameToAction.Clear();
			UnityEngine.Object.FindObjectOfType<InputActivator>().LoadDefaultInputActions();
		}

		public void RegisterDefaultInputAction(InputAction action)
		{
			RegisterInputAction(action);
		}

		public void RegisterInputAction(InputAction action)
		{
			string actionName = action.actionId.actionName;
			nameToAction.Add(actionName, action);
			string contextName = action.contextId.contextName;
			contextToActions.Add(contextName, action);
			LoadInputAction(action);
			AddKeysToMap(action);
		}

		private static string GetEnumDescription(Enum value)
		{
			FieldInfo field = value.GetType().GetField(value.ToString());
			DescriptionAttribute[] array = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
			if (array != null && array.Length > 0)
			{
				return array[0].Description;
			}
			return value.ToString();
		}

		public bool CheckAction(string actionName)
		{
			if (Suspended)
			{
				return false;
			}
			HashSet<string>.Enumerator enumerator = activeContexts.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				HashSet<InputAction> hashSet = contextToActions[current];
				HashSet<InputAction>.Enumerator enumerator2 = hashSet.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					InputAction current2 = enumerator2.Current;
					if (!(current2.actionId.actionName == actionName))
					{
						continue;
					}
					KeyCode[] keys = current2.keys;
					int num = keys.Length;
					for (int i = 0; i < num; i++)
					{
						if (keysPressed.Contains((int)keys[i]))
						{
							return true;
						}
					}
					MultiKeys[] multiKeys = current2.multiKeys;
					int num2 = multiKeys.Length;
					for (int j = 0; j < num2; j++)
					{
						MultiKeys multiKeys2 = multiKeys[j];
						keys = multiKeys2.keys;
						num = keys.Length;
						if (num > 0)
						{
							bool flag = true;
							for (int k = 0; k < num; k++)
							{
								flag &= keysPressed.Contains((int)keys[k]);
							}
							if (flag)
							{
								return true;
							}
						}
					}
				}
			}
			HashSet<InputAction>.Enumerator enumerator3 = pendingActions.GetEnumerator();
			while (enumerator3.MoveNext())
			{
				InputAction current3 = enumerator3.Current;
				if (current3.actionId.actionName == actionName)
				{
					return true;
				}
			}
			return false;
		}

		public float GetAxisOrKey(string actionName)
		{
			int num = (CheckAction(actionName) ? 1 : 0);
			if (num == 1)
			{
				return num;
			}
			return GetAxis(actionName, false);
		}

		public bool GetActionKeyDown(string actionName)
		{
			if (Suspended)
			{
				return false;
			}
			HashSet<string>.Enumerator enumerator = activeContexts.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				HashSet<InputAction> hashSet = contextToActions[current];
				HashSet<InputAction>.Enumerator enumerator2 = hashSet.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					InputAction current2 = enumerator2.Current;
					if (!(current2.actionId.actionName == actionName))
					{
						continue;
					}
					KeyCode[] keys = current2.keys;
					int num = keys.Length;
					for (int i = 0; i < num; i++)
					{
						if (Input.GetKeyDown(keys[i]))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public bool GetActionKeyUp(string actionName)
		{
			if (Suspended)
			{
				return false;
			}
			HashSet<string>.Enumerator enumerator = activeContexts.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				HashSet<InputAction> hashSet = contextToActions[current];
				HashSet<InputAction>.Enumerator enumerator2 = hashSet.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					InputAction current2 = enumerator2.Current;
					if (!(current2.actionId.actionName == actionName))
					{
						continue;
					}
					KeyCode[] keys = current2.keys;
					int num = keys.Length;
					for (int i = 0; i < num; i++)
					{
						if (Input.GetKeyUp(keys[i]))
						{
							return true;
						}
					}
				}
			}
			HashSet<InputAction>.Enumerator enumerator3 = pendingActions.GetEnumerator();
			while (enumerator3.MoveNext())
			{
				InputAction current3 = enumerator3.Current;
				if (!(current3.actionId.actionName == actionName))
				{
					continue;
				}
				KeyCode[] keys2 = current3.keys;
				int num2 = keys2.Length;
				for (int j = 0; j < num2; j++)
				{
					if (Input.GetKeyUp(keys2[j]))
					{
						return true;
					}
				}
			}
			return false;
		}

		public float GetUnityAxis(string axisName)
		{
			return (!Suspended) ? Input.GetAxis(axisName) : 0f;
		}

		public float GetAxis(string name, bool mustExistForAllContext)
		{
			if (Suspended)
			{
				return 0f;
			}
			HashSet<string>.Enumerator enumerator = activeContexts.GetEnumerator();
			float num = 0f;
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				HashSet<InputAction> hashSet = contextToActions[current];
				HashSet<InputAction>.Enumerator enumerator2 = hashSet.GetEnumerator();
				bool flag = false;
				while (enumerator2.MoveNext())
				{
					InputAction current2 = enumerator2.Current;
					if (current2.actionId.actionName == name)
					{
						flag = true;
						float value;
						if (axisVals.TryGetValue(current2, out value) && value != 0f)
						{
							num = value;
						}
					}
				}
				if (mustExistForAllContext && !flag)
				{
					return 0f;
				}
			}
			if (num == 0f && CheckAction(name))
			{
				num = 1f;
			}
			return num;
		}

		public bool GetMouseButton(int mouseButton)
		{
			return !Suspended && Input.GetMouseButton(mouseButton);
		}

		public bool GetMouseButtonDown(int mouseButton)
		{
			return !Suspended && Input.GetMouseButtonDown(mouseButton);
		}

		public bool GetMouseButtonUp(int mouseButton)
		{
			return !Suspended && Input.GetMouseButtonUp(mouseButton);
		}

		public bool CheckMouseButtonInAllActiveContexts(string actionName, int mouseButton)
		{
			if (Suspended)
			{
				return false;
			}
			if (!Input.GetMouseButton(mouseButton))
			{
				return false;
			}
			return AllActiveContextsContainAction(actionName);
		}

		private bool AllActiveContextsContainAction(string name)
		{
			bool result = false;
			HashSet<string>.Enumerator enumerator = activeContexts.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				HashSet<InputAction> hashSet = contextToActions[current];
				HashSet<InputAction>.Enumerator enumerator2 = hashSet.GetEnumerator();
				bool flag = false;
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current.actionId.actionName == name)
					{
						flag = true;
						result = true;
						break;
					}
				}
				if (!flag)
				{
					return false;
				}
			}
			return result;
		}

		public bool GetKey(KeyCode keyCode)
		{
			if (Suspended)
			{
				return false;
			}
			return keysPressed.Contains((int)keyCode);
		}

		public bool GetKeyDown(KeyCode keyCode)
		{
			if (Suspended)
			{
				return false;
			}
			return Input.GetKeyDown(keyCode);
		}

		public bool GetKeyUp(KeyCode keyCode)
		{
			if (Suspended)
			{
				return false;
			}
			return Input.GetKeyUp(keyCode);
		}

		public bool IsAnyKey()
		{
			if (Suspended)
			{
				return false;
			}
			return Input.anyKeyDown || AnyAxisInput();
		}

		private bool AnyAxisInput()
		{
			return IsAxisActive(MoveActions.FORWARD) || IsAxisActive(MoveActions.BACK) || IsAxisActive(MoveActions.LEFT) || IsAxisActive(MoveActions.RIGHT) || IsAxisActive(ShotActions.SHOT) || IsAxisActive(WeaponActions.WEAPON_LEFT) || IsAxisActive(WeaponActions.WEAPON_RIGHT);
		}

		private float AbsAxisVal(string axisName)
		{
			return Math.Abs(GetAxisOrKey(axisName));
		}

		private bool IsAxisActive(string axisName)
		{
			return AbsAxisVal(axisName) > EPS;
		}

		public void ActivateContext(string contextName)
		{
			activeContexts.Add(contextName);
			Update();
		}

		public void DeactivateContext(string contextName)
		{
			if (!activeContexts.Contains(contextName))
			{
				return;
			}
			HashSet<InputAction> hashSet = contextToActions[contextName];
			activeContexts.Remove(contextName);
			HashSet<InputAction>.Enumerator enumerator = hashSet.GetEnumerator();
			while (enumerator.MoveNext())
			{
				InputAction current = enumerator.Current;
				KeyCode[] keys = current.keys;
				int num = keys.Length;
				for (int i = 0; i < num; i++)
				{
					if (keysPressed.Contains((int)keys[i]))
					{
						pendingActions.Add(current);
					}
				}
			}
			ResetAxes(contextName);
		}

		public void Suspend()
		{
			ClearActions();
			SUSPENDED = true;
		}

		public void Resume()
		{
			SUSPENDED = false;
			resumeAtFrame = 0;
		}

		public void ResumeAtNextFrame()
		{
			SUSPENDED = false;
			resumeAtFrame = Time.frameCount;
		}

		private void ResetAxes(string contextName)
		{
			HashSet<InputAction> hashSet = contextToActions[contextName];
			HashSet<InputAction>.Enumerator enumerator = hashSet.GetEnumerator();
			while (enumerator.MoveNext())
			{
				InputAction current = enumerator.Current;
				if (axisVals.ContainsKey(current))
				{
					axisVals[current] = 0f;
				}
			}
		}

		private void UpdateKeysInActiveContext(InputAction action)
		{
			if (!actionToKeys.ContainsKey(action))
			{
				return;
			}
			HashSet<KeyCode> hashSet = actionToKeys[action];
			HashSet<KeyCode>.Enumerator enumerator = hashSet.GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyCode current = enumerator.Current;
				int item = (int)current;
				bool flag = keysPressed.Contains(item);
				if (Input.GetKey(current))
				{
					if (!flag)
					{
						keysPressed.Add(item);
						action.StartInputAction();
					}
				}
				else if (flag)
				{
					keysPressed.Remove(item);
					action.StopInputAction();
				}
			}
		}

		private void UpdateAxisInActiveContext(InputAction action)
		{
			if (!actionToAxes.ContainsKey(action))
			{
				return;
			}
			HashSet<string> hashSet = actionToAxes[action];
			HashSet<string>.Enumerator enumerator = hashSet.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				float axis = Input.GetAxis(current);
				bool flag = action.onlyNegativeAxes && !action.onlyPositiveAxes;
				bool flag2 = !action.onlyNegativeAxes && action.onlyPositiveAxes;
				float num = ((!action.invertAxes) ? 1 : (-1));
				if (flag)
				{
					if (axis * num < 0f)
					{
						axisVals[action] = Mathf.Abs(axis);
					}
					else
					{
						axisVals[action] = 0f;
					}
				}
				else if (flag2)
				{
					if (axis * num > 0f)
					{
						axisVals[action] = Mathf.Abs(axis);
					}
					else
					{
						axisVals[action] = 0f;
					}
				}
				else
				{
					axisVals[action] = axis * num;
				}
			}
		}

		public void Update()
		{
			if (Suspended)
			{
				return;
			}
			HashSet<string>.Enumerator enumerator = activeContexts.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				HashSet<InputAction> hashSet = contextToActions[current];
				HashSet<InputAction>.Enumerator enumerator2 = hashSet.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					InputAction current2 = enumerator2.Current;
					UpdateKeysInActiveContext(current2);
					UpdateAxisInActiveContext(current2);
				}
			}
			if (pendingActions.Count <= 0)
			{
				return;
			}
			pendingActions.RemoveWhere((InputAction action) => !action.keys.Any((KeyCode key) => Input.GetKey(key) || Input.GetKeyUp(key)));
		}
	}
}
