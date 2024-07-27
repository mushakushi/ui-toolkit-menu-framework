namespace Mushakushi.MenuFramework.Runtime.SerializableUQuery
{
    /// <summary>
    /// A CSS-like selector. 
    /// </summary>
    [System.Serializable]
    public class Selector
    {
        public SelectorType type;
        
        public PseudoSelector state;
        
        /// <summary>
        /// The name(s) that will be selected. 
        /// </summary>
        public string[] names;

        /// <summary>
        /// The class(es) that will be selected.
        /// </summary>
        public string[] classes;
        
        /// <param name="type">
        /// The type of selector.
        /// </param>
        /// <param name="state">
        /// The <see cref="PseudoSelector"/> that will be selected.
        /// </param>
        public Selector(SelectorType type, PseudoSelector state)
        {
            this.type = type;
            this.state = state;
            names = new string[] { };
            classes = new string[] { };
        }

        /// <inheritdoc />
        public Selector()
            : this(SelectorType.Wildcard, 0) { }
    }
}