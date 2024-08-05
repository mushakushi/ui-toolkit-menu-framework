using UnityEngine;
using UnityEngine.UIElements;

namespace Mushakushi.MenuFramework.Runtime.SerializableUQuery.Selectors
{
    /// <summary>
    /// Selects element by class name.
    /// </summary>
    [System.Serializable]
    public class ClassName: ISelector
    {
        [SerializeField] 
        private string className;
        
        public UQueryBuilder<T> ApplySelector<T>(UQueryBuilder<T> queryBuilder) where T : VisualElement
        {
            return queryBuilder.Class(className);
        }
    }
}