using System;
using System.Reflection;
using Hover.Common.Util;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Hover.Common.Edit.Utils {

	/*================================================================================================*/
	public static class EditorUtil {
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static GUIStyle GetVerticalSectionStyle() {
			var style = new GUIStyle();
			style.padding = new RectOffset(16, 0, 0, 0);
			return style;
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static ISettingsControllerMap GetControllerMap(SerializedObject pObject, string pName) {
			Object behaviour = pObject.targetObject;
			Type behaviourType = behaviour.GetType();
			Type mapType = typeof(ISettingsControllerMap);
			PropertyInfo propInfo = behaviourType.GetProperty(pName, mapType);

			if ( propInfo == null ) {
				Debug.LogWarning(
					"The '"+typeof(DisableWhenControlledAttribute).Name+"' could not find "+
						"a '"+pName+"' property of type '"+mapType.Name+"'.",
					behaviour
				);

				return null;
			}

			return (ISettingsControllerMap)propInfo.GetValue(behaviour, null);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public static RangeAttribute GetFieldRangeAttribute(SerializedProperty pProp) {
			Object behaviour = pProp.serializedObject.targetObject;
			Type behaviourType = behaviour.GetType();
			FieldInfo fieldInfo = behaviourType.GetField(pProp.name);
			object[] ranges = fieldInfo.GetCustomAttributes(typeof(RangeAttribute), false);

			return (ranges.Length == 0 ? null : (RangeAttribute)ranges[0]);
		}

	}

}
