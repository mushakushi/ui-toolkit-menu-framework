using System;
using Mushakushi.MenuFramework.Runtime.ExtensionFramework;
using Mushakushi.MenuFramework.Runtime.SerializableUQuery;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace Mushakushi.MenuFramework.Runtime.Extensions
{
    /// <summary>
    /// Connects multiple menus together with one extension. 
    /// </summary>
    [Serializable]
    public class MenuConnectionButtonExtension: MenuEventExtension<Button>
    {
        /// <summary>
        /// The menu that will be opened.
        /// </summary>
        [SerializeField] 
        private Menu openMenu;
        
        [SerializeField] 
        private MenuEventChannel menuEventChannel;
        
        [field: SerializeField] 
        public override UQueryBuilderSerializable Query { get; protected set; } 
        
        protected override Action OnAttach(Button button, PlayerInput playerInput)
        {
            button.clicked += PopulateMenu;
            return () => button.clicked -= PopulateMenu;

            void PopulateMenu()
            {
                menuEventChannel.RaiseOnPopulateRequested(openMenu);
            }
        }

    }
}