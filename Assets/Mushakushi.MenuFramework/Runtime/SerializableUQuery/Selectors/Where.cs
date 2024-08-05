using UnityEngine;
using UnityEngine.UIElements;

namespace Mushakushi.MenuFramework.Runtime.SerializableUQuery.Selectors
{
    /// <summary>
    /// Selects elements <see cref="UQueryBuilder{T}.Where"/>.
    /// Uses the same type of as the given <see cref="UQueryBuilder{T}"/>.
    /// </summary>
    [System.Serializable]
    public class Where: ISelector
    {
        [SerializeReference, SubclassSelector]
        private ISelectorPredicate predicate;
        
        public UQueryBuilder<T> ApplySelector<T>(UQueryBuilder<T> queryBuilder) where T : VisualElement
        {
            return queryBuilder.Where(predicate.EvaluatePredicate<T>());
        }
    }
}