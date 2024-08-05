using UnityEngine;
using UnityEngine.UIElements;

namespace Mushakushi.MenuFramework.Runtime.SerializableUQuery.Selectors
{
    /// <summary>
    /// Selects element by name.
    /// </summary>
    [System.Serializable]
    public class Name: ISelector
    {
        [SerializeField] 
        private string name;
        
        public UQueryBuilder<T> ApplySelector<T>(UQueryBuilder<T> queryBuilder) where T : VisualElement
        {
            return queryBuilder.Name(name);
        }
    }
}