using System.Globalization;
using UnityEditor;
using UnityEngine;

namespace UnityModule
{
    // refs: https://forum.unity.com/threads/how-to-change-the-name-of-list-elements-in-the-inspector.448910/#post-3027279
    [CustomPropertyDrawer(typeof(ElementTitleAttribute))]
    public sealed class ElementTitleDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        private ElementTitleAttribute ElementTitleAttribute => (ElementTitleAttribute) attribute;

        private SerializedProperty TitleNameProperty { get; set; }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var propertyPath = $"{property.propertyPath}.{ElementTitleAttribute.FieldName}";
            TitleNameProperty = property.serializedObject.FindProperty(propertyPath);
            var title = GetTitle();
            if (string.IsNullOrEmpty(title))
            {
                title = label.text;
            }
            EditorGUI.PropertyField(position, property, new GUIContent(title, label.tooltip), true);
        }

        private string GetTitle()
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (TitleNameProperty.propertyType)
            {
                case SerializedPropertyType.Generic:
                    break;
                case SerializedPropertyType.Integer:
                    return TitleNameProperty.intValue.ToString();
                case SerializedPropertyType.Boolean:
                    return TitleNameProperty.boolValue.ToString();
                case SerializedPropertyType.Float:
                    return TitleNameProperty.floatValue.ToString(CultureInfo.CurrentCulture);
                case SerializedPropertyType.String:
                    return TitleNameProperty.stringValue;
                case SerializedPropertyType.Color:
                    return TitleNameProperty.colorValue.ToString();
                case SerializedPropertyType.ObjectReference:
                    return
                        TitleNameProperty.objectReferenceValue != null
                            ? TitleNameProperty.objectReferenceValue.ToString()
                            : string.Empty;
                case SerializedPropertyType.ExposedReference:
                    return
                        TitleNameProperty.exposedReferenceValue != null
                            ? TitleNameProperty.exposedReferenceValue.ToString()
                            : string.Empty;
                case SerializedPropertyType.LayerMask:
                    break;
                case SerializedPropertyType.Enum:
                    return TitleNameProperty.enumNames[TitleNameProperty.enumValueIndex];
                case SerializedPropertyType.Vector2:
                    return TitleNameProperty.vector2Value.ToString();
                case SerializedPropertyType.Vector3:
                    return TitleNameProperty.vector3Value.ToString();
                case SerializedPropertyType.Vector4:
                    return TitleNameProperty.vector4Value.ToString();
                case SerializedPropertyType.Rect:
                    break;
                case SerializedPropertyType.ArraySize:
                    break;
                case SerializedPropertyType.Character:
                    break;
                case SerializedPropertyType.AnimationCurve:
                    break;
                case SerializedPropertyType.Bounds:
                    break;
                case SerializedPropertyType.Gradient:
                    break;
                case SerializedPropertyType.Quaternion:
                    break;
            }

            return string.Empty;
        }
    }
}