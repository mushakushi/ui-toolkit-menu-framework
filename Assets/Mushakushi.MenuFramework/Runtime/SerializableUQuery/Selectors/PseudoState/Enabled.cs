using UnityEngine.UIElements;

namespace Mushakushi.MenuFramework.Runtime.SerializableUQuery.Selectors.PseudoState
{
    /// <summary>
    /// Selects by <see cref="UQueryBuilder{T}.Enabled"/> status.
    /// </summary>
    [System.Serializable]
    public class Enabled: ISelector
    {
        public UQueryBuilder<T> ApplySelector<T>(UQueryBuilder<T> queryBuilder) where T : VisualElement
        {
            return queryBuilder.Enabled();
        }
    }
}