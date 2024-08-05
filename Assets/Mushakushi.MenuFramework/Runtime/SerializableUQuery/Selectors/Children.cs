using UnityEngine.UIElements;

namespace Mushakushi.MenuFramework.Runtime.SerializableUQuery.Selectors
{
    /// <summary>
    /// Selects by <see cref="UQueryBuilder{T}.Children{T}(System.String, System.String)"/> status.
    /// Uses the same type of as the given <see cref="UQueryBuilder{T}"/>.
    /// </summary>
    [System.Serializable]
    public class Children: ISelector
    {
        public UQueryBuilder<T> ApplySelector<T>(UQueryBuilder<T> queryBuilder) where T : VisualElement
        {
            return queryBuilder.Children<T>();
        }
    }
}