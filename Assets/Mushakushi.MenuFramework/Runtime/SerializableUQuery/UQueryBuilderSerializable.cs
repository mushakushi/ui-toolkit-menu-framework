using System;
using System.Linq;
using Mushakushi.MenuFramework.Runtime.SerializableUQuery.Selectors;
using UnityEngine;
using UnityEngine.UIElements;

namespace Mushakushi.MenuFramework.Runtime.SerializableUQuery
{
    /// <summary>
    /// Creates and serializes a pseudo-<see cref="UQueryBuilder{T}"/>. 
    /// </summary>
    [Serializable]
    public struct UQueryBuilderSerializable
    {
        [SerializeReference, SubclassSelector]
        public ISelector[] selectors;

        /// <summary>
        /// Converts a <see cref="UQueryBuilderSerializable"/> into a <see cref="UQueryBuilder{T}"/>
        /// based on the current selectors. 
        /// </summary>
        /// <param name="visualElement">
        /// The <see cref="VisualElement"/> to build the query on. 
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="VisualElement"/> to query for.
        /// </typeparam>
        /// <returns>
        /// A <see cref="UQueryBuilder{T}"/> representation of the current object. 
        /// </returns>
        /// <remarks>
        /// The resulting query is built in sequential order based on the <see cref="selectors"/>.
        /// </remarks>
        public UQueryBuilder<T> EvaluateQuery<T>(VisualElement visualElement) where T : VisualElement
        {
            var uQueryBuilder = new UQueryBuilder<T>(visualElement);
            return selectors.Aggregate(uQueryBuilder, (current, selector) => selector.ApplySelector(current));
        }
        
       // https://docs.unity3d.com/ScriptReference/UIElements.UQueryBuilder_1.html 
    }
}