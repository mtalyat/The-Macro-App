using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TheMacroApp
{
    /// <summary>
    /// Manages the application data.
    /// </summary>
    internal static class Manager
    {
        /// <summary>
        /// The location of the app data folder.
        /// </summary>
        private static readonly string SAVE_FOLDER = Path.Join(Application.UserAppDataPath, "../");

        /// <summary>
        /// The location of the app data.
        /// </summary>
        private static readonly string SAVE_FILE = Path.Join(SAVE_FOLDER, @"appdata.json");

        /// <summary>
        /// The data of the application.
        /// </summary>
        public static AppData Data { get; private set; } = new AppData();

        #region Saving and Loading

        /// <summary>
        /// Saves the app data.
        /// </summary>
        public static void Save()
        {
            // sort scripts by name
            Data.Scripts.Sort();

            Data.Save(SAVE_FILE);
        }

        /// <summary>
        /// Loads the app data.
        /// </summary>
        public static void Load()
        {
            // load data from disc
            AppData? loadedData = AppData.Load(SAVE_FILE);

            if(loadedData == null)
            {
                // load app data from resources
                // if all else fails, create new empty app data (shouldn't have to do that)
                Data = JsonSerializer.Deserialize<AppData>(Resources.DefaultAppData) ?? new AppData();
            }
            else
            {
                // data loaded fine from disk, use that
                Data = loadedData;
            }

            // sort scripts by name
            Data.Scripts.Sort();
        }

        #endregion

        #region Running

        /// <summary>
        /// Runs the macro with the given key.
        /// </summary>
        /// <param name="key">The key of the macro to run.</param>
        public static void RunMacro(MacroKey key)
        {
            // use key to find macro data
            MacroData? macroData = Data.FindMacro(key);

            // do nothing if not found
            if(macroData == null)
            {
                return;
            }

            // run macro
            RunMacro(macroData);
        }

        /// <summary>
        /// Runs the macro using the given macro data.
        /// </summary>
        /// <param name="macroData">The data of the macro to run.</param>
        public static void RunMacro(MacroData macroData)
        {
            // if no data saved, do nothing
            if (macroData == null || string.IsNullOrEmpty(macroData.Path))
            {
                return;
            }

            // run it, according to the file extension
            string extension = Path.GetExtension(macroData.Path);

            // get the data
            ScriptData? scriptData = Data.FindScript(extension);

            if(scriptData != null)
            {
                // found script data, so run it
                RunCommand(macroData, scriptData);
            }
            else
            {
                // invalid file type
                ShowError($"Extension \"{extension}\" not recognized. Make sure you add it to the configuration settings.", "Unknown extension.", true);
            }
        }

        /// <summary>
        /// Runs a command from a macro.
        /// </summary>
        /// <param name="macroData">The macro data of the macro to run.</param>
        /// <param name="scriptData">The script data associated with the given macro.</param>
        private static void RunCommand(MacroData macroData, ScriptData scriptData)
        {
            Process process = new Process();

            // figure out the file name and arguments...
            /*
             * If no executable provided, assume script is an executable:
             * - FileName = MacroData.Path
             * - Arguments = MacroData.Args
             * 
             * 
             * 
             * If executable provided:
             * - FileName = ScriptData.ExecutablePath
             * - Arguments = MacroData.ToCommand()
             */

            string fileName, arguments;
            if (string.IsNullOrEmpty(scriptData.ExecutablePath))
            {
                fileName = macroData.Path;
                arguments = macroData.Args;
            }
            else
            {
                fileName = scriptData.ExecutablePath;
                arguments = macroData.ToCommand(scriptData.Format);
            }

            bool showTerminal = macroData.TerminalOption == TerminalShowOptions.Show;

            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = fileName,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardInput = false,
                RedirectStandardOutput = false,
                RedirectStandardError = false,
                CreateNoWindow = !showTerminal,
            };

            // run command
            process.StartInfo = info;

            try
            {
                process.Start();
            }
            catch (Exception ex)
            {
                ShowError($"Process failed to start: {ex.Message}", "Process failed.");
            }

            process.Dispose();
        }

        #endregion

        #region Utility

        /// <summary>
        /// Shows an error message box.
        /// </summary>
        /// <param name="text">The text to display.</param>
        /// <param name="caption">The title of the message box.</param>
        /// <param name="warning">Display a warning icon if true, otherwise displays an error icon.</param>
        private static void ShowError(string text, string caption, bool warning = false)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, warning ? MessageBoxIcon.Warning : MessageBoxIcon.Error);
        }

        #endregion
    }
}
