using System.Collections.Generic;
using Mushakushi.MenuFramework.Runtime.SerializableUQuery;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Mushakushi.MenuFramework.Editor.SerializableUQuery
{
    /// <summary>
    /// Makes a selector for a name and/or class a dropdown with prefilled options. 
    /// </summary>
    [CustomPropertyDrawer(typeof(NameClassSelectorAttribute))]
    public class NameClassSelectorAttributeDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var fieldType = fieldInfo.FieldType;
            if (fieldType != typeof(string) && fieldType != typeof(string[]) && fieldType != typeof(IList<string>))
                return GetAlignedPropertyField(property);
            
            var uiSelectorAttribute = (NameClassSelectorAttribute)attribute;
            var selectorsContainerObject = ReflectionUtilityEditor.FindPropertyRelativeAsObject(property, uiSelectorAttribute.selectorsContainerName);
            if (selectorsContainerObject == null) return GetAlignedPropertyField(property);

            var nameClassOptions = SelectorPopupUtility.GetSelectorNameClassOptions(selectorsContainerObject, uiSelectorAttribute.mode);
            var popup = SelectorPopupUtility.GetNameClassPopupField(property, nameClassOptions);
            popup.AddToClassList(BaseField<PopupField<string>>.alignedFieldUssClassName);
            return popup;
        }

        private static PropertyField GetAlignedPropertyField(SerializedProperty property)
        {
            var propertyField = new PropertyField(property);
            propertyField.AddToClassList(BaseField<PopupField<string>>.alignedFieldUssClassName);
            return propertyField;
        }
    }
}