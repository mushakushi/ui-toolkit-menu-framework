using System;
using System.Collections.Generic;
using System.Linq;
using Mushakushi.MenuFramework.Runtime.SerializableUQuery;
using UnityEditor;
using UnityEngine.UIElements;

namespace Mushakushi.MenuFramework.Editor.SerializableUQuery
{
    /// <summary>
    /// Utility for drawing popups for selectors. 
    /// </summary>
    public static class SelectorPopupUtility
    {
        /// <summary>
        /// Option to display in pop up when there is no selectors to show,
        /// wrapped in an array.
        /// </summary>
        /// <remarks>This can happen if there is no visual element selected.</remarks>
        private static readonly List<string> EmptyPopoutText = new (){ "No Selectors Available!" };

        /// <summary>
        /// Option name when to select a null option.
        /// </summary>
        private static readonly string[] NullPopupFieldOption = { "<null>" };
        
        /// <summary>
        /// The selectors in <see cref="selectorsContainer"/>,
        /// null otherwise. 
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="mode"/> is invalid.
        /// </exception>
        /// <remarks>
        /// See documentation for <see cref="NameClassSelectorAttribute"/> for valid types of containers. 
        /// </remarks>
        public static List<string> GetSelectorNameClassOptions(object selectorsContainer, SelectorMode mode)
        {
            VisualElement visualElement; 
            switch (selectorsContainer)
            {
                case VisualTreeAsset visualTreeAsset:
                    visualElement = visualTreeAsset.CloneTree();
                    break;
                case UIDocument uiDocument:
                    visualElement = uiDocument.rootVisualElement;
                    break;
                case List<string> selectors:
                    return selectors;
                case IEnumerable<string> selectors:
                    return selectors.ToList();
                default:
                    return null;
            }
            
            return mode switch
            {
                SelectorMode.Name => GetAllNames(visualElement).ToList(),
                SelectorMode.Class => GetAllStyleClasses(visualElement).ToList(),
                SelectorMode.All => GetAllNames(visualElement).Concat(GetAllStyleClasses(visualElement)).ToList(),
                _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, null)
            };
        }
        
        public static VisualElement GetNameClassPopupField(SerializedProperty property, List<string> nameClassOptions)
        {
            if (nameClassOptions == null || nameClassOptions.Count == 0)
            {
                return new PopupField<string>(property.displayName, EmptyPopoutText, 0);
            }

            var popup = new PopupField<string>(property.displayName, NullPopupFieldOption.Concat(nameClassOptions).ToList(), 0);
            popup.RegisterValueChangedCallback(changeEvent =>
            {
                if (changeEvent.newValue != NullPopupFieldOption[0]) return;
                property.stringValue = null;
                property.serializedObject.ApplyModifiedProperties();
            });

            return popup;
        }

        /// <returns>
        /// All the names on a visual element including its children.
        /// </returns>
        private static IEnumerable<string> GetAllNames(VisualElement element)
        {
            return element?.Query().ToList().Select(x => x.name) ?? Enumerable.Empty<string>();
        }

        /// <returns>
        /// All style classes on a visual element including its children.
        /// </returns>
        private static IEnumerable<string> GetAllStyleClasses(VisualElement element)
        {
            return element?.Query().ToList()
                .SelectMany(x => x.GetClasses())
                .Distinct() ?? Enumerable.Empty<string>();
        }

        // private static IEnumerable<string> GetAllNamesAndStyleClasses(VisualElement element)
        // {
        //     return GetAllNames(element).Select(x => $"Names/{x}")
        //         .Concat(GetAllStyleClasses(element).Select(x => $"Classes/{x}"));
        // }
    }
}