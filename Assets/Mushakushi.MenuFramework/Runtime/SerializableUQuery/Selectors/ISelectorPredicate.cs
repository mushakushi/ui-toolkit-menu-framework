using System;
using UnityEngine.UIElements;

namespace Mushakushi.MenuFramework.Runtime.SerializableUQuery.Selectors
{
    /// <summary>
    /// Evaluates a predicate on a <see cref="VisualElement"/>.
    /// </summary>
    public interface ISelectorPredicate
    {
        /// <summary>
        /// Selects all elements that match the predicate.
        /// </summary>
        public Func<T, bool> EvaluatePredicate<T>() where T : VisualElement;
    }
}