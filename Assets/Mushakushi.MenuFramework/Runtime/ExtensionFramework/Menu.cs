using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

namespace Mushakushi.MenuFramework.Runtime.ExtensionFramework
{
    [UsedImplicitly, CreateAssetMenu(fileName = nameof(Menu), menuName = "ScriptableObjects/UI/Menu", order = 0)]
    public class Menu: ScriptableObject
    {
        /// <summary>
        /// The <see cref="VisualTreeAsset"/> of the submenu. 
        /// </summary>
        [field: SerializeField] 
        public VisualTreeAsset Asset { get; private set; }

        /// <summary>
        /// The <see cref="IMenuExtension"/>(s). 
        /// </summary>
        [field: SerializeReference, SubclassSelector] 
        public IMenuExtension[] Extensions { get; [UsedImplicitly] protected set; }
    }
}