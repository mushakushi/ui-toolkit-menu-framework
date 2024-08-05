using Menu = Mushakushi.MenuFramework.Runtime.ExtensionFramework.Menu;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Mushakushi.MenuFramework.Editor.SerializableUQuery
{
    [CustomEditor(typeof(Menu)), CanEditMultipleObjects]
    public class MenuDrawer : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();
            
            var serializedPropertyIterator = serializedObject.GetIterator();
            serializedPropertyIterator.NextVisible(enterChildren: true);
            
            while (serializedPropertyIterator.NextVisible(enterChildren: false))
            {
                if (serializedPropertyIterator.name != ReflectionUtilityEditor.GetBackingFieldName(nameof(Menu.Extensions)))
                {
                    root.Add(CreateBoundedPropertyField(serializedPropertyIterator));
                    continue;
                }

                // TODO - how do I access each serialized property in a serialized property array element...?
                root.Add(CreateBoundedPropertyField(serializedPropertyIterator));
            }

            return root; 
        }

        private static VisualElement CreateBoundedPropertyField(SerializedProperty property)
        {
            var propertyField = new PropertyField(property);
            propertyField.BindProperty(property);
            return propertyField;
        }
    }
}