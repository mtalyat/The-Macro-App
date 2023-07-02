# Changelog

## 1.4.1
* Updated the README to better reflect how the application is used.
* Removed the Hot Keys list from the README.
* Changed invalid keys so they will no longer display "INVALID" when they are invalid. Instead, they will display the current key selection for that key. Invalid or valid hot keys will be distinguishable by the red or green color.
* Added a setting to change VALID and INVALID key colors, so they do not have to be green and red. They will default to green and red.
* If the macro to open the application is pressed while the window is minimized, it will return the window state to normal.

## 1.4.0
* Renamed to just "The Macro App".
* Updated the icon so it is sage green colored, instead of black, to make it pop more.
* Changed the Configure button to Configure Scripts Button.
* Changed the Open Folder button to Open Scripts Folder.
* Created a settings window, and a way to edit the following settings:
  * Change if the app should be included in the startup apps list.
  * Change the default script folder location.
  * Change the main window open hot key.
* Moved the app data folder from Local app data to Roaming app data.
* Moved the app data json file into the general app data folder, so that the version number does not cause issues with saving and loading.
* Removed the Apply button from the macro configuration window.
* Added default a script data configuration for the following file types:
  * Batch
  * Executable
  * Python
  * Text
  * Image
  * Video
  * Audio
* There is also a constant default for when no script has been set up. It will be opened with explorer.exe, which will default to opening each file type with its respective default application.
* Made it so the args field for macros will be unable to be edited, if the {args} have been omitted from the format of the script data.
* Added support for case-insensitive extensions.
* Changes how buttons are reloaded on the main window.
* Changed the macro button text to be more informative.
* Updated the README:
  * Reflect the new way to add the app to the startup apps list.
  * New examples of script datas.

## 1.3.0
* Updated the main window to have slight color variations if a macro is VALID, INVALID or EMPTY.
  * VALID is green.
  * INVALID is red.
  * EMPTY is gray.
  * DEFAULT is white.
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