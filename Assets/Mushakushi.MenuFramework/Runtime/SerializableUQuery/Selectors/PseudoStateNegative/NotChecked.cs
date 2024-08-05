using UnityEngine.UIElements;

namespace Mushakushi.MenuFramework.Runtime.SerializableUQuery.Selectors.PseudoStateNegative
{
    /// <summary>
    /// Selects by <see cref="UQueryBuilder{T}.NotChecked"/> status.
    /// </summary>
    [System.Serializable]
    public class NotChecked: ISelector
    {
        public UQueryBuilder<T> ApplySelector<T>(UQueryBuilder<T> queryBuilder) where T : VisualElement
        {
            return queryBuilder.NotChecked();
        }
    }
}