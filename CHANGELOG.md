# Changelog

## 1.3.0
* Updated the main window to have slight color variations if a macro is VALID, INVALID or EMPTY.
  * VALID is green
  * INVALID is red
  * EMPTY is gray
  * DEFAULT is white
* Updated README to reflect these changes.
* Updated file selection dialog so it will filter by configured script types.

## 1.2.0
* Changed the macro configuration window to follow an OK APPLY CANCEL pattern.
* Changed the macro list so it will display all the macro information: the key combination, followed by the command that will be ran in the terminal.
* Added the ability to set custom key combinations for each macro, instead of being limited to Ctrl + Alt + Number Key.
* The application will let you know if a key combination is VALID or INVALID.Check the README for more info.
* Changed the main window to have a more dynamic list, which expands and allows for many macros.
* Fixed err with the executable path for Text files in the README.
* Updated README with the new user interfaces.
* Updated README with more examples.

## 1.1.1
* Fixed a bug when opening application with an empty appdata json file.
* Fixed a bug that input fields would not be disabled when there were no script types upon opening the configure scripts window. 
* Changed the way macros are added, so that they can be edited instead of reset from scratch.
* Changed terminal showing customization from the script type level to the individual macro level.
* Updated README with more examples.

## 1.1.0
* Added application icon.
* Added a Configure window, which will allow the user to customize script types that can be ran:
  * Name of type.
  * Extension(s) for type.
  * Executable for type (e.g. python.exe path).
  * Customizable command format.
  * Toggle if the terminal should be visible.
* Changed save data, which is now stored in a json file, in the local application data folder.

## 1.0.0
* Initial release.