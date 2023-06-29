# Changelog

## 1.1.1
* Fixed a bug when opening application with an empty appdata json file.
* Fixed a bug that input fields would not be disabled when there were no script types upon opening the configure scripts form. 
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