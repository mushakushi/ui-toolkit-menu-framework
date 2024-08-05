using UnityEngine.UIElements;

namespace Mushakushi.MenuFramework.Runtime.SerializableUQuery.Selectors.PseudoState
{
    /// <summary>
    /// Selects by <see cref="UQueryBuilder{T}.Checked"/> status.
    /// </summary>
    [System.Serializable]
    public class Checked: ISelector
    {
        public UQueryBuilder<T> ApplySelector<T>(UQueryBuilder<T> queryBuilder) where T : VisualElement
        {
            return queryBuilder.Checked();
        }
    }
}