using System;
using System.Linq;
using TypeReferences;
using UnityEngine;
using UnityEngine.UIElements;

namespace Mushakushi.MenuFramework.Runtime.SerializableUQuery.Selectors
{
    /// <summary>
    /// Selects elements <see cref="UQueryBuilder{T}.OfType{T}(System.String, System.String[])"/>.
    /// </summary>
    [Serializable]
    public class OfType: ISelector
    {
        [SerializeField, Inherits(typeof(VisualElement), IncludeAdditionalAssemblies = new[] { "Assembly-CSharp" }, ShortName = true)]
        private TypeReference type;
        
        public UQueryBuilder<T> ApplySelector<T>(UQueryBuilder<T> queryBuilder) where T : VisualElement
        {
            var methodInfo = typeof(UQueryBuilder<T>)
                .GetMethods()
                .Where(x => x.Name == nameof(UQueryBuilder<T>.OfType))
                .FirstOrDefault(x => x.IsGenericMethod);
            
            if (methodInfo == null) return queryBuilder;
            var genericMethod = methodInfo.MakeGenericMethod(type);
            return (UQueryBuilder<T>)genericMethod.Invoke(queryBuilder, new object[methodInfo.GetParameters().Length]);
        }
    }
}