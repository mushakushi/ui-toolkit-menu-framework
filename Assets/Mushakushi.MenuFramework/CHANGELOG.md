# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.3] - 2024-08-09

### Added 
### Changed 
### Removed 

### Fixed 
- Fixed package.json 
- Moved example folder to samples. 

## [1.0.2] - 2024-08-05

### Added
- Better documentation.
- Missing selectors. You now have access to the same amount of selectors as the built-in UQueryBuilder, including OfType.

### Changed
- Revised example scene 
- Selectors are now ISelectors and can be selected in a menu using a dropdown like an IMenuExtension. 
- Converted NameClassSelector to use UIToolkit.
- MenuConnectionButtonExtension only operates on one button at a time and the dictionary is removed.

### Removed
- MenuEventExtensionWithDictionary
- SelectorDrawer

### Fixed
- UQueryBuilderSerializable only applied the last selector. It now applies all of them sequentially.
- Mistakes in package structure.

## [1.0.1] - 2024-07-26

### Added
### Changed

### Removed 
- Serializable UQuery property drawer
- Menu Connection Extension not added and unremovable by default

### Fixed 
- UQueryBuilderSerializable building on children, making the selector not work.

## [1.0.0] - 2024-02-20

### Added
- Initial commit

