using UnityEngine.UIElements;

namespace Mushakushi.MenuFramework.Runtime.SerializableUQuery.Selectors
{
    /// <summary>
    /// A CSS-like selector. 
    /// </summary>
    public interface ISelector
    {
        /// <summary>
        /// Applies a selector to a <see cref="UQueryBuilder{T}"/>.
        /// </summary>
        /// <returns>A <see cref="UQueryBuilder{T}"/> with the new selection rules.</returns>
        public UQueryBuilder<T> ApplySelector<T>(UQueryBuilder<T> queryBuilder) where T: VisualElement;
    }
}