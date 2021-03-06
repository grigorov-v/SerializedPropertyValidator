﻿using UnityEditor;
using UnityEngine;
using Grigorov.Unity.SerializedPropertyValidator.Attributes;

namespace Grigorov.Unity.SerializedPropertyValidator.Editor.ValidateTriggers {
	[CustomPropertyDrawer(typeof(ValidationAttribute), true)]
	public class PropertyDrawerValidateTrigger : PropertyDrawer {
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			EditorGUI.BeginChangeCheck();
			EditorGUI.PropertyField(position, property, label, true);
			if ( EditorGUI.EndChangeCheck() ) {
				Validator.Validate(property, fieldInfo, attribute as ValidationAttribute);
			}
		}
 
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
			return EditorGUI.GetPropertyHeight(property);
		}
	}
}

