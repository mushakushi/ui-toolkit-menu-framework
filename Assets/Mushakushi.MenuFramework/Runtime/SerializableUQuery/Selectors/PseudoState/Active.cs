using UnityEngine.UIElements;

namespace Mushakushi.MenuFramework.Runtime.SerializableUQuery.Selectors.PseudoState
{
    /// <summary>
    /// Selects by <see cref="UQueryBuilder{T}.Active"/> status.
    /// </summary>
    [System.Serializable]
    public class Active: ISelector
    {
        public UQueryBuilder<T> ApplySelector<T>(UQueryBuilder<T> queryBuilder) where T : VisualElement
        {
            return queryBuilder.Active();
        }
    }
}