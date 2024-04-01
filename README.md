# UI Toolkit Menu Framework 
A framework for expediting the creation of menus using UI toolkit. 

## Installation 
**Install via git URL**
from the Add package from git URL option, enter:

```bash
https://github.com/Mushakushi/UIToolkitMenuFramework/Assets/Mushakushi.UIAddons.git
```

If you are specifying a version, append #{VERSION} to the end of the git URL. 

## Usage

### Setup the Menu Controller 
The menu controller provides a simple way to process input (using the Unity Input System) to navigate to 
and process the data within menus. It also contains a global set of extensions 
which will be applied to each menu.

### About Extensions
An extension is some piece of code that is called when an UXML menu is attached
to the Menu Controller's root document. For example, a `MenuConnectionButtonExtension`
will trigger a menu to be populated on the screen based on a query, to which multiple 
of these connections can exist.  

### Create a Menu
A menu is a Scriptable Object containing a UXML menu and any extensions applied to it.
A `MenuConnectionButtonExtension` is added by default. 

### NameClassSelectorAttribute
Add this attribute to a string or string collection, in order to get a list of 
name or classes from a `VisualTreeAsset`, `UIDocument` or a string collection. 
This is used throughout the project to avoid having to give hard-coded strings. 

```csharp
public UIDocument document; 

[NameClassSelector(nameof(document), SelectorMode.Class)]
public string className; 
```

### UQueryBuilderSerializable
In combination with the `NameClassSelectorAttribute`, this class creates a psuedo-`UQueryBuilder`
that allows you to use much of the same selectors within the editor and then build into 
the actual class. 