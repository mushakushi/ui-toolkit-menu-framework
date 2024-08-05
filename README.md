# UI Toolkit Menu Framework 
A framework for expediting the creation of menus using UI toolkit. 

## Installation 

**Install via git URL**

from the Add package from git URL option, enter:

```bash
https://github.com/Mushakushi/UIToolkitMenuFramework.git?path=Assets/Mushakushi.MenuFramework
```

If you are specifying a version, append #{VERSION} to the end of the git URL. 

```bash
https://github.com/Mushakushi/UIToolkitMenuFramework.git?path=Assets/Mushakushi.MenuFramework#{VERSION}
```

When using the git URL, install the following upm dependencies:

https://openupm.com/packages/com.mackysoft.serializereference-extensions/

https://openupm.com/packages/com.rotaryheart.serializabledictionarylite/

https://openupm.com/packages/com.solidalloy.type-references/

> ⚠️ For the above package, navigate to 
> "ProjectSettings > Packages > TypeReferences > Search bar minimum items count. 
> Change that from 10 to 99999."
> 
> https://github.com/SolidAlloy/ClassTypeReference-for-Unity/issues/43

## Usage

### Menu Controller 
The menu controller provides a simple way to process input (using the Unity Input System) to navigate to 
and process the data within menus. It also contains a global set of extensions 
which will be applied to each menu.

1. Create a `UI Document` and assign it a source asset.
2. Create a `Menu Event Channel`, which is responsible for communicating menu events, and a `PlayerInput` component, which will be used by certain extensions to understand in what context the current menu was opened in. 
3. Attach  the `MenuController` script to some GameObject. Assign it the previous UI Document and select the `RootContainerName` (if left empty it will use the entire UI Document as the root container) and the `InitialFocusedElementClassName` (if left empty nothing will be focused on any menu, otherwise the first Visual Element with this class name will be focused on every menu when it first populates).

A basic setup would look something like this: 
![image](https://github.com/Mushakushi/UIToolkitMenuFramework/assets/60948236/556c93bb-57bf-412f-8929-a83aa9880842)

### Menu
A menu is a Scriptable Object containing a reference to a UXML document and a collection of extensions to apply to it.

### Menu Extensions
An extension is some piece of code that is called when the menu is attached
to the Menu Controller's root document. For example, a `MenuConnectionButtonExtension`
will trigger a menu to be populated on the screen based on a button press, to which multiple
of these connections can exist.

A global extension on a `MenuController` is an extension that is applied to every menu.

> ⚠️ The `InputIconExtension` is intended to be a global extension, because it should
> impact all menus in the same way. Copying this extension to every menu is repetitive.

### UQueryBuilderSerializable
Extensions are applied to VisualElements that initially match a `UQueryBuilderSerializable` query, 
which is a query builder that applies selectors from the first to last selector sequentially. 
Evaluate the query into a usable UQueryBuilder using `UQueryBuiilderSerializable.EvaluateQuery`.

You can also use this class independently of the menu framework.

### Basic Usage
Use the `Menu Event Channel` to subscribe and invoke menu events. Example usage can be found in the [Example folder](https://github.com/Mushakushi/UIToolkitMenuFramework/tree/main/Assets/Example).

## Attributes

### NameClassSelectorAttribute
Add this attribute to a string or string collection, in order to get a list of 
name or classes from a `VisualTreeAsset`, `UIDocument` or a string collection. 
This is used throughout the project to avoid having to give hard-coded strings. 

```csharp
public UIDocument document; 

[NameClassSelector(nameof(document), SelectorMode.Class)]
public string className; 
```

